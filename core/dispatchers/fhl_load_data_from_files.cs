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

namespace fhl.core.dispatchers
{
    class fhl_load_data_from_files
    {
        public static void DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            fhl_core.Files.Clear();     // Очищаем список файлов с логами.
            fhl_core.AllCountRequest = 0;
            int i = 0;
            foreach (string file in fhl_core.FileNames)
            {
                //  MessageBox.Show("Начата обработка файла файл");
                i++;
                // ЕСЛИ ПОСТУПИЛА КОММАНДА НА ОТМЕМУ ЗАДАНИЯ
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    fhl_core.Files.Add(new fhl_logfile_instance(file, System.IO.File.ReadAllText(file)));
                    worker.ReportProgress(i);
                }
                // MessageBox.Show("Обработан файл");
            }
            // MessageBox.Show("Completed");
        }

        public static void doParse(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            int i = 0;

            // -------------------------------
            //foreach (fhl_logfile_instance f in fhl_core.Files)
            //{
            //    //foreach (fhl_logfile_instance_node s in f.rows)
            //    for (int iter0 = 0; iter0 < f.rows.Count; iter0++)
            //    {
            //        if (worker.CancellationPending == true)
            //        {
            //            e.Cancel = true;
            //            break;
            //        }
            //        else
            //        {

            //            Regex rg = new Regex(fhl_core.ws_cfg.log_format_regxPattern);   // Создаем экземпляр Regex  
            //            MatchCollection matchedAuthors = rg.Matches(f.rows[iter0].request);  // Получаем все совпадения  
            //            List<fhl_websrv_var> req = new List<fhl_websrv_var>();  // Массив с результатами

            //            for (int count = 0; count < matchedAuthors.Count; count++)
            //            {
            //                for (int j = 1, param_iter = 0; j < matchedAuthors[count].Groups.Count; j++, param_iter++)
            //                {
            //                    req.Add(new fhl_websrv_var(fhl_core.ws_cfg.existVariable[param_iter].var, matchedAuthors[count].Groups[j].Value));
            //                }
            //            }
            //            f.rows[iter0].params_list = req;
            //        }
            //        worker.ReportProgress(i++);
            //    }
            //}
            // -------------------------------

            foreach (fhl_logfile_instance f in fhl_core.Files)
            {
                //foreach (fhl_logfile_instance_node s in f.rows)
                int therd;
                if (Environment.ProcessorCount > 1)
                {
                    therd = Environment.ProcessorCount - 1;
                }
                else
                {
                    therd = Environment.ProcessorCount;
                }
                var rangePartitioner = Partitioner.Create(0, f.rows.Count, therd);
                MessageBox.Show("Оптимальное количестов поток для загрузки: " + therd, "Предупреждение");

                //                var rangePartitioner = Partitioner.Create(0, _dArray.Length, _dArray.Length / Environment.ProcessorCount);


                Parallel.ForEach(rangePartitioner, (range, loopState) =>
                {
                    // Loop over each range element without a delegate invocation.
                    // for (int iter = range.Item1; iter < range.Item2; iter++)
                    for (int iter0 = range.Item1; iter0 < range.Item2; iter0++)
                    {
                        //results[i] = source[i] * Math.PI;
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
                });
            }
        }
    }
}
