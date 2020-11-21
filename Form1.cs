using fhl.core;
using fhl.core.dictionaries;
using fhl.core.dispatchers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fhl
{
    public partial class MainForm : Form
    {
        void addDataToCoreLog(string str, Color c)
        {
            CoreLog.AppendText(str);
            CoreLog.Select(CoreLog.TextLength - str.Length, CoreLog.TextLength);
            CoreLog.SelectionColor = c;
            CoreLog.AppendText("\n");
        }

        public MainForm()
        {
            InitializeComponent();
            addDataToCoreLog("Запуск программы!!!", Color.Black);
            addDataToCoreLog("___________________________________________________________________", Color.Gray);
            addDataToCoreLog("                      ", Color.White);
            addDataToCoreLog("   ▄▄█▄▄             ", Color.White);
            addDataToCoreLog(" ▄▀██████▌▄▄█▀ ▄▄▄   ", Color.White);
            addDataToCoreLog(" █ ▐███████▀   ███▀▌ ", Color.White);
            addDataToCoreLog("  ▀▀█████▀      ███▀  ", Color.White);
            addDataToCoreLog("", Color.White);
            addDataToCoreLog("", Color.White);
            addDataToCoreLog("Завариваем чаек, и начинаем смотреть на скучные и длинные логи :)", Color.Gray);
            addDataToCoreLog("___________________________________________________________________", Color.Gray);
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void валидацияФорматаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addDataToCoreLog("____________________________________________________________________", Color.Green);
            addDataToCoreLog("Начата валидация формата для лога.", Color.Green);
            addDataToCoreLog(string.Format("Пользовательская строка (без ковычек): \"{0}\"", fhl_core.ws_cfg.log_format), Color.Green);
            addDataToCoreLog("Получена следующая строка RegEx выражения: " + fhl_core.getLogFormatPatternRegex(fhl_core.ws_cfg.log_format, fhl_core.ws_cfg.log_vars), Color.Green);
            addDataToCoreLog("Производим диагностический вывод переменных попорядку, которые были найдены и будут использованы при сканировании:", Color.Green);
            addDataToCoreLog(string.Format("Всего найдено {0} переменных!", fhl_core.ws_cfg.existVariable.Count), Color.Green);
            for (int i = 0; i < fhl_core.ws_cfg.existVariable.Count; i++)
            {
                addDataToCoreLog(fhl_core.ws_cfg.existVariable[i].var + " -> " + fhl_core.ws_cfg.existVariable[i].value, Color.Green);
            }

            //foreach (logVariable ll in CoreScanObject.existVariable)
            //{
            //    addDataToCoreLog(ll.var + " -> " + ll.value, Color.Green);
            //}
            addDataToCoreLog("____________________________________________________________________", Color.Green);
        }




        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog_mainForm.Multiselect = true;
            openFileDialog_mainForm.Filter = "Log files(*.log)|*.log|Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (openFileDialog_mainForm.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            toolStripProgressBar1.Minimum = 0;
            toolStripProgressBar1.Maximum = openFileDialog_mainForm.FileNames.Length + 1;

            fhl_core.FileNames = openFileDialog_mainForm.FileNames;
            fhl_core.getLogFormatPatternRegex(fhl_core.ws_cfg.log_format, fhl_core.ws_cfg.log_vars);
            if (backgroundWorker_loaddata.IsBusy != true)
            {
                backgroundWorker_loaddata.DoWork += fhl_load_data_from_files.DoWork;
                backgroundWorker_loaddata.ProgressChanged += loadData_ProgressChanged;
                backgroundWorker_loaddata.RunWorkerCompleted += loadData_RunWorkerCompleted;
                backgroundWorker_loaddata.RunWorkerAsync();

                toolStripProgressBar1.Value = 0;
                toolStripProgressBar1.Visible = true;
                toolStripStatusLabel2.Visible = true;

            }
        }


        public void loadData_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                toolStripProgressBar1.Value = e.ProgressPercentage;
            }
            catch (System.NullReferenceException ex)
            {

            }
        }

        private void loadData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                addDataToCoreLog("", Color.Red);
                addDataToCoreLog("Операция загрузки файлов отменена пользователем!", Color.Red);

                toolStripProgressBar1.Value = 0;
                toolStripProgressBar1.Visible = false;
                toolStripStatusLabel2.Visible = false;
            }
            else if (e.Error != null)
            {
                addDataToCoreLog("", Color.Red);
                addDataToCoreLog(string.Format("При загрузке возникла следующая ошибка: {0}", e.Error.Message), Color.Red);

                toolStripProgressBar1.Value = 0;
                toolStripProgressBar1.Visible = false;
                toolStripStatusLabel2.Visible = false;
            }
            else
            {
                foreach (fhl_logfile_instance f in fhl_core.Files)
                {
                    addDataToCoreLog("", Color.Red);
                    addDataToCoreLog(string.Format("Добавлен файл {0} для анализа на предмет аномалий и угроз", f.filename), Color.Red);
                    addDataToCoreLog(string.Format("Количество строк: {0}", f.rows.Count()), Color.Red);
                    addDataToCoreLog("", Color.Red);
                }


                using (BackgroundWorker bw = new BackgroundWorker())
                {
                    if (backgroundWorker_loaddata.IsBusy != true)
                    {
                        addDataToCoreLog("Начат процесс забора строка в соответсвии с шаблном:", Color.Black);
                        addDataToCoreLog(fhl_core.ws_cfg.log_format, Color.Black);

                        toolStripProgressBar1.Maximum = fhl_core.AllCountRequest;
                        toolStripProgressBar1.Value = 0;
                        bw.WorkerReportsProgress = true;
                        bw.WorkerSupportsCancellation = true;
                        bw.DoWork += fhl_load_data_from_files.doParse;
                        bw.ProgressChanged += loadData_ProgressChanged;
                        bw.RunWorkerCompleted += loadData_RunWorkerParseDataCompleted;
                        bw.RunWorkerAsync();
                    }
                }


            }
        }

        private void loadData_RunWorkerParseDataCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                addDataToCoreLog("", Color.Red);
                addDataToCoreLog("Операция загрузки файлов отменена пользователем!", Color.Red);

                toolStripProgressBar1.Value = 0;
                toolStripProgressBar1.Visible = false;
                toolStripStatusLabel2.Visible = false;
            }
            else
            {
                addDataToCoreLog("Все файлы логов загружены", Color.Blue);
                foreach (fhl_logfile_instance f in fhl_core.Files)
                {
                    addDataToCoreLog(string.Format("В файле {0} найдено {1} строк запрос к веб серверу", f.filename, f.rows.Count), Color.Blue);
                }
            }

            toolStripProgressBar1.Value = 0;
            toolStripProgressBar1.Visible = false;
            toolStripStatusLabel2.Visible = false;

        }


        private void шаблонСтрокиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditFormatLogForm lff = new EditFormatLogForm();
            lff.Owner = this;
            lff.textBox1.Text = fhl_core.ws_cfg.log_format;
            lff.ShowDialog();
        }

        private void windowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            windowsToolStripMenuItem.Checked = true;
            unixToolStripMenuItem.Checked = false;
            fhl_core.EndLineString = "\r\n";


        }

        private void unixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            windowsToolStripMenuItem.Checked = false;
            unixToolStripMenuItem.Checked = true;
            fhl_core.EndLineString = "\t\n";
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

            if (backgroundWorker_loaddata.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                backgroundWorker_loaddata.CancelAsync();
            }
        }

        private void начатьАнализToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addDataToCoreLog("Выпускаем охотника!", Color.GreenYellow);
            using (BackgroundWorker bw = new BackgroundWorker())
            {
                toolStripProgressBar1.Maximum = fhl_core.AllCountRequest;
                toolStripProgressBar1.Value = 0;

                bw.WorkerReportsProgress = true;
                bw.WorkerSupportsCancellation = true;
                bw.DoWork += fhl_hunting.doHuntind;
                bw.ProgressChanged += loadData_ProgressChanged;
                bw.RunWorkerCompleted += HuntingWorker_compled;
                bw.RunWorkerAsync();
            }
        }



        private void HuntingWorker_compled(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                addDataToCoreLog("", Color.Red);
                addDataToCoreLog("Операция загрузки файлов отменена пользователем!", Color.Red);

                toolStripProgressBar1.Value = 0;
                toolStripProgressBar1.Visible = false;
                toolStripStatusLabel2.Visible = false;
            }
            else
            {
                addDataToCoreLog("Анализ логов завершен", Color.Blue);
                if (fhl_hunting.error_5xx.Count > 0)
                {
                    addDataToCoreLog("Найденые 5xx коды ответа сервера:", Color.Red);
                    foreach (fhl_logfile_instance_node r_5xx in fhl_hunting.error_5xx)
                    {
                        addDataToCoreLog(r_5xx.request, Color.Black);
                    }
                }
                else
                {
                    addDataToCoreLog("5xx коды ответа сервера не найдены!", Color.Green);

                }
                if (fhl_hunting.attach_Path_Traversal.Count > 0)
                {
                    addDataToCoreLog("Найдены Path_Traversal атаки:", Color.Red);
                    foreach (fhl_logfile_instance_node ia in fhl_hunting.attach_Path_Traversal)
                    {
                        addDataToCoreLog(ia.request, Color.Black);
                    }
                }
                else
                {
                    addDataToCoreLog("Path_Traversal атаки не найдены!", Color.Green);
                }
                if (fhl_hunting.attach_XSS.Count > 0)
                {
                    addDataToCoreLog("Найденые Path_Traversal попытки:", Color.Red);
                    foreach (fhl_logfile_instance_node ia in fhl_hunting.attach_XSS)
                    {
                        addDataToCoreLog(ia.request, Color.Black);
                    }
                }
                else
                {
                    addDataToCoreLog("XSS атаки не найдены!", Color.Green);
                }
            }

            toolStripProgressBar1.Value = 0;
            toolStripProgressBar1.Visible = false;
            toolStripStatusLabel2.Visible = false;

        }

        private void тестовыйВыводСтрокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fhl_core.AllCountRequest > 10)
            {
                DialogResult dialogResult = MessageBox.Show("Строк очень много (более 10) выдейтсвительно хотите их все вывести в консоль?!", "Предупреждение", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    foreach (fhl_logfile_instance f in fhl_core.Files)
                    {
                        for (int i = 0, j = 0; i < f.rows.Count; i++)
                        {
                            addDataToCoreLog(f.rows[i].request, Color.Blue);
                            addDataToCoreLog(string.Format("Всего параметров: {0}", f.rows[i].params_list.Count), Color.Blue);
                            foreach (fhl_websrv_var cp in f.rows[i].params_list)
                            {
                                addDataToCoreLog(string.Format("[{0}]\t{1}\t\t\t\t\t \"{2}\"", j++, cp.var, cp.value), Color.Blue);
                            }
                            addDataToCoreLog("", Color.Transparent);
                        }
                        //foreach(fhl_logfile_instance_node cr in f.rows)
                        //{
                        //    addDataToCoreLog(cr.), Color.Blue);
                        //}

                    }
                }
            }

        }

        private void горизонтальнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (горизонтальнаяToolStripMenuItem.Checked)
            {
                CoreLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
            }
            else
            {
                CoreLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            }
        }

        private void очиститьКонсольToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CoreLog.Clear();
        }

        private void вОзможностиСистемыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addDataToCoreLog(string.Format("Количество процессоров в системе: {0}", Environment.ProcessorCount), Color.Blue);
            addDataToCoreLog(string.Format("Количество потоков рекоммендованное для этой системы: {0}", Environment.ProcessorCount * 32), Color.Blue);
            addDataToCoreLog(string.Format("Максимальное количестов потоков для этой системы: {0}", Environment.ProcessorCount * 64), Color.Blue);
        }
    }
}
