using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace fhl.core.dispatchers
{
    class fhl_load_data_from_files
    {
        public static void OpenFiles_RunWorker(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            fhl_core.Files.Clear();     // Очищаем список файлов с логами.
                                        // fhl_core.AllCountRequest = 0;
            int i = 0;
            foreach (string file in fhl_core.FileNames)
            {
                //fhl_dispatcher.messages.Add("Начата обработка файла файла ()");
                i++;
                List<string> tempFileRows = new List<string>();

                // Выполение отмены на выполение разбора файлов.
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    fhl_core.Files.Clear(); // Чистим список загруженных файлов.
                    fhl_dispatcher.messages.Add("Задача (открытие лог файлов) отменена пользователем!");
                    break;
                }
                else
                {
                    using (var streamReader = new StreamReader(new BufferedStream(File.OpenRead(file), 10 * 1024 * 1024))) // буфер в 1 мегабайт (Эксперементально)
                    {
                        string temp_string = "";    // Строка лога из файла.
                        while (!streamReader.EndOfStream)
                        {
                            char temp_next_char = '\0';   // Текущий символ из потока.
                            if ((temp_next_char = (char)streamReader.Read()) == '\n')
                            {
                                // Если строка оказалась пустой или исключительно состоящей из пробелов.
                                if (String.IsNullOrEmpty(temp_string) | String.IsNullOrWhiteSpace(temp_string))
                                {
                                    continue;
                                    worker.ReportProgress(i++);
                                }
                                if (!worker.CancellationPending)
                                {
                                    // Текущая строка, разобранная на параметр:значение
                                    //fhl_logfile_instance_node temp_inst_node = new fhl_logfile_instance_node(temp_string);

                                    //Regex rg = new Regex(fhl_core.ws_cfg.log_format_regxPattern);   // Создаем экземпляр Regex  
                                    //MatchCollection matchedAuthors = rg.Matches(temp_string);  // Получаем все совпадения  

                                    //for (int count = 0; count < matchedAuthors.Count; count++)
                                    //{
                                    //    for (int j = 1, param_iter = 0; j < matchedAuthors[count].Groups.Count; j++, param_iter++)
                                    //    {
                                    //        temp_inst_node.params_list
                                    //            .Add(new fhl_websrv_var(fhl_core.ws_cfg.existVariable[param_iter].var, matchedAuthors[count].Groups[j].Value));
                                    //    }
                                    //}
                                    worker.ReportProgress(i++);
                                    tempFileRows.Add(temp_string);

                                }
                                else
                                {
                                    e.Cancel = true;
                                    fhl_core.Files.Clear(); // Чистим список загруженных файлов.
                                    fhl_dispatcher.messages.Add("Задача (открытие лог файлов) отменена пользователем!");
                                    worker.ReportProgress(i++);
                                    break;
                                }
                                temp_string = "";
                            }
                            else
                            {
                                temp_string += temp_next_char;  // Если символ не '\n' то плюсуем символ в строку и журчим дальше. 
                            }
                        }
                    }
                }
                fhl_core.Files.Add(new fhl_logfile_instance(file, tempFileRows));
                fhl_dispatcher.messages.Add(String.Format("Окончание чтения файла :)\"{0}\"", file));
            }

        }

        public static void ParseFiles_RunWorker(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            int allRequestIter = 0; // Счетчик обработанных запросов

            // Файлы логов будет обрабатываться параллельно
            foreach (fhl_logfile_instance f in fhl_core.Files)
            {
                var rangeRequestPartitioner = Partitioner.Create(0, f.sourceRows.Count, fhl_core.ThreadParse);
                //var rangePartitioner = Partitioner.Create(0, _dArray.Length, _dArray.Length / Environment.ProcessorCount);

                Parallel.ForEach(rangeRequestPartitioner, (range, loopState) =>
                {
                    if (!worker.CancellationPending)
                    {
                        for (int iter0 = range.Item1; iter0 < range.Item2; iter0++)
                        {
                            if (worker.CancellationPending == true)
                            {
                                e.Cancel = true;
                                break;
                            }
                            else
                            {
                                Regex rg = new Regex(fhl_core.ws_cfg.log_format_regxPattern);   // Создаем экземпляр Regex  
                                MatchCollection matchedAuthors = rg.Matches(f.sourceRows[iter0]);  // Получаем все совпадения  
                                List<fhl_websrv_var> req = new List<fhl_websrv_var>();  // Массив с результатами
                                //MessageBox.Show(f.sourceRows[iter0]);
                                for (int count = 0; count < matchedAuthors.Count; count++)
                                {
                                    for (int j = 1, param_iter = 0; j < matchedAuthors[count].Groups.Count; j++, param_iter++)
                                    {
                                        req.Add(new fhl_websrv_var(fhl_core.ws_cfg.existVariable[param_iter].var, matchedAuthors[count].Groups[j].Value));
                                    }
                                }

                                bool continue_request = false;
                                if (fhl_core.FilteringOnOpeningFiles)
                                {
                                    foreach (string wip in fhl_core.WhiteIPList)
                                    {
                                        if (f.sourceRows[iter0].IndexOf(wip) != -1)
                                        {
                                            continue_request = true;
                                        }
                                    }
                                }
                                if (continue_request)
                                {
                                    continue;
                                }
                                fhl_logfile_instance_node t1 = new fhl_logfile_instance_node(f.sourceRows[iter0]);
                                t1.params_list = req;
                                f.rows.Add(t1);
                                worker.ReportProgress(allRequestIter++);
                            }
                        }
                    }
                    else
                    {
                        fhl_core.Files.Clear(); // Чистим список загруженных файлов.
                        fhl_dispatcher.messages.Add("Задача (подготовки лог файлов) отменена пользователем!");
                        worker.ReportProgress(allRequestIter++);
                        loopState.Break();
                    }
                });
            }
        }

        /// <summary>
        /// Устарел
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void doParse(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            int i = 0;

            foreach (fhl_logfile_instance f in fhl_core.Files)
            {
                var rangePartitioner = Partitioner.Create(0, f.rows.Count, fhl_core.ThreadParse);
                //var rangePartitioner = Partitioner.Create(0, _dArray.Length, _dArray.Length / Environment.ProcessorCount);

                Parallel.ForEach(rangePartitioner, (range, loopState) =>
                {
                    if (!worker.CancellationPending)
                    {
                        for (int iter0 = range.Item1; iter0 < range.Item2; iter0++)
                        {
                            if (worker.CancellationPending == true)
                            {
                                e.Cancel = true;
                                break;
                            }
                            else
                            {
                                Regex rg = new Regex(fhl_core.ws_cfg.log_format_regxPattern);   // Создаем экземпляр Regex  
                                MatchCollection matchedAuthors = rg.Matches(f.rows[iter0].request);  // Получаем все совпадения  
                                List<fhl_websrv_var> req = new List<fhl_websrv_var>();  // Массив с результатами

                                for (int count = 0; count < matchedAuthors.Count; count++)
                                {
                                    for (int j = 1, param_iter = 0; j < matchedAuthors[count].Groups.Count; j++, param_iter++)
                                    {
                                        req.Add(new fhl_websrv_var(fhl_core.ws_cfg.existVariable[param_iter].var, matchedAuthors[count].Groups[j].Value));
                                    }
                                }
                                f.rows[iter0].params_list = req;
                                worker.ReportProgress(i++);
                            }
                        }
                    }
                    else
                    {
                        worker.ReportProgress(i++);
                    }
                });
            }
        }
    }
}
