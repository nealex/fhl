using fhl.core;
using fhl.core.dictionaries;
using fhl.core.dispatchers;
using fhl.core.hunting;
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

        void previewTeapot(Color ct)
        {
            addDataToCoreLog("                      ", ct);
            addDataToCoreLog("   ▄▄█▄▄             ", ct);
            addDataToCoreLog(" ▄▀██████▌▄▄█▀ ▄▄▄   ", ct);
            addDataToCoreLog(" █ ▐███████▀   ███▀▌ ", ct);
            addDataToCoreLog("  ▀▀█████▀      ███▀  ", ct);
            addDataToCoreLog("", ct);
            addDataToCoreLog("", ct);
        }

        public void valid_format()
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
            addDataToCoreLog("____________________________________________________________________", Color.Green);
        }

        public void test_out_string()
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
                    }
                }
            }
        }

        public MainForm()
        {
            InitializeComponent();
            addDataToCoreLog("Запуск программы!!!", Color.Black);
            addDataToCoreLog("___________________________________________________________________", Color.Black);
            previewTeapot(Color.Silver);
            addDataToCoreLog("Завариваем чаек, и начинаем смотреть на скучные и длинные логи :)", Color.Black);
            addDataToCoreLog("___________________________________________________________________", Color.Black);
        }



        private void Form1_Load(object sender, EventArgs e)
        {

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

            if (backgroundWorker.IsBusy != true)
            {
                if (fhl_core.MeOpenFiles)
                {
                    return;
                }
                fhl_core.MeOpenFiles = true;

                if (fhl_core.FilteringOnOpeningFiles)
                {
                    addDataToCoreLog("Запросы будут отфильтрованы на этапе загрузки файлов!", Color.Black);
                    foreach (string wip in fhl_core.WhiteIPList)
                    {
                        addDataToCoreLog(String.Format("Запросы с ip адреса {0} будут пропущены!", wip), Color.Black);
                    }
                }
                fhl_core.AllCountRequest = 0;
                backgroundWorker.DoWork += fhl_load_data_from_files.DoWork;
                backgroundWorker.ProgressChanged += loadData_ProgressChanged;
                backgroundWorker.RunWorkerCompleted += loadData_RunWorkerCompleted;
                backgroundWorker.RunWorkerAsync();

                toolStripProgressBar1.Value = 0;
                toolStripProgressBar1.Visible = true;
                toolStripStatusLabel2.Visible = true;

            }
        }


        public void loadData_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (fhl_core.KernelPanic)
            {
                return;
            }
            toolStripProgressBar1.Value = e.ProgressPercentage;
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
                // MessageBox.Show("Start !!!" + fhl_core.AllCountRequest.ToString());
                foreach (fhl_logfile_instance f in fhl_core.Files)
                {
                    addDataToCoreLog("", Color.Red);
                    addDataToCoreLog(string.Format("Добавлен файл {0} для анализа на предмет аномалий и угроз", f.filename), Color.Red);
                    addDataToCoreLog(string.Format("Количество строк: {0}", f.rows.Count()), Color.Red);
                    addDataToCoreLog("", Color.Red);
                }
                // MessageBox.Show("break!!!" + fhl_core.AllCountRequest.ToString());
                fhl_core.MeOpenFiles = false;
                using (BackgroundWorker bw = new BackgroundWorker())
                {
                    if (backgroundWorker.IsBusy != true)
                    {
                        addDataToCoreLog("Начат процесс разбора строк в соответсвии с шаблном:", Color.Black);
                        addDataToCoreLog(String.Format("При разборе будет использовано {0} потоков из {1}", fhl_core.ThreadParse, Environment.ProcessorCount), Color.Black);
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
            if (backgroundWorker.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                backgroundWorker.CancelAsync();
            }
        }

        private void начатьАнализToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addDataToCoreLog("Выпускаем охотника!", Color.Green);
            using (BackgroundWorker bw = new BackgroundWorker())
            {
                toolStripProgressBar1.Visible = true;
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
                addDataToCoreLog("", Color.Black);
                addDataToCoreLog("Охота отменена пользователем!", Color.Red);

                toolStripProgressBar1.Value = 0;
                toolStripProgressBar1.Visible = false;
                toolStripStatusLabel2.Visible = false;
            }
            else
            {
                if (fhl_hunting.results.Count > 0)
                {
                    List<fhl_hunting_instance> successAttack = fhl_hunting.results.Where(item => item.final_attack == fhl_hunting_result_type.Success).ToList();
                    if (successAttack.Count > 0)
                    {
                        addDataToCoreLog(String.Format("Хакерам удалось произвести {0} успешных атак!!!", successAttack.Count), Color.Red);
                        foreach (fhl_hunting_instance ia in successAttack)
                        {
                            addDataToCoreLog(String.Format("\nВид атаки: {0} ({1})\nСтрока в лог файле:\n{2}\n", ia.type.ToString(),ia.signature, ia.request.request), Color.Red);
                        }
                    }
                    else
                    {
                        addDataToCoreLog("Успешных атак охотник не обнаружил!!!", Color.Red);
                    }

                    List<fhl_hunting_instance> FailedAttack = fhl_hunting.results.Where(item => item.final_attack == fhl_hunting_result_type.Failed).ToList();
                    if (FailedAttack.Count > 0)
                    {
                        addDataToCoreLog(String.Format("Хакерам удалось произвести {0} подозрительных запросов!!!", FailedAttack.Count), Color.Green);
                        foreach (fhl_hunting_instance ia in FailedAttack)
                        {
                            addDataToCoreLog(String.Format("\nВид атаки: {0} ({1})\nСтрока в лог файле:\n{2}\n", ia.type.ToString(),ia.signature, ia.request.request), Color.Green);
                        }
                    }
                    else
                    {
                        addDataToCoreLog("Безуспешных вредоносных запросов к серверу не найдено!!!", Color.Green);
                    }
                }
                else
                {
                    addDataToCoreLog("Хакерской активности не обнаружено!!!", Color.Blue);
                }
            }

            toolStripProgressBar1.Value = 0;
            toolStripProgressBar1.Visible = false;
            toolStripStatusLabel2.Visible = false;

        }

        private void тестовыйВыводСтрокToolStripMenuItem_Click(object sender, EventArgs e)
        {


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
            addDataToCoreLog("Консоль была очищена!", Color.Black);
        }

        private void вОзможностиСистемыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addDataToCoreLog(string.Format("Количество процессоров в системе: {0}", Environment.ProcessorCount), Color.Blue);
        }

        private void белыеIPадресаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormWhiteIPList IP_form = new FormWhiteIPList();
            IP_form.Owner = this;
            IP_form.textBox1.Text = String.Join(",", fhl_core.WhiteIPList.ToArray());
            IP_form.ShowDialog();
        }

        private void фильтрацияIPНаЭтапеОткрытияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fhl_core.FilteringOnOpeningFiles = ((ToolStripMenuItem)sender).Checked = !((ToolStripMenuItem)sender).Checked;

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            fhl_core.KernelPanic = true;
        }

        private void последниеРезультатыToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void показатьСкрытыеНастройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem thisObj = (ToolStripMenuItem)sender;
            thisObj.Checked = !thisObj.Checked;

        }


        private void валидацияФорматаToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            valid_format();
        }

        private void тестовыйВыводСтрокToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            test_out_string();
        }

        private void производительностьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNumberOfThreadsAtWork thf = new FormNumberOfThreadsAtWork();
            thf.Owner = this;
            thf.label1.Text = "Выбрано потоков: " + fhl_core.ThreadParse;
            thf.trackBar1.Minimum = 1;
            thf.trackBar1.Value = fhl_core.ThreadParse;
            thf.trackBar1.Maximum = Environment.ProcessorCount;
            thf.ShowDialog();
        }

        private void nGINXToolStripMenuItem_Click(object sender1, EventArgs e1)
        {
            FormEditDictionaries form = new FormEditDictionaries();
            form.Owner = this;
            form.boxDictionaries.Text = String.Join("\n", fhl_core.ws_cfg.getLogVars());
            form.button1.Click += new System.EventHandler(delegate (object sender, EventArgs e)
            {
                string[] ts2arr = form.boxDictionaries.Text.Split('\n');
                ts2arr = ts2arr.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                Array.Sort(ts2arr);
                fhl_core.ws_cfg.setLogVars(ts2arr);
                form.Close();
            });
            form.ShowDialog();
        }

        private void pHPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEditDictionaries form = new FormEditDictionaries();
            form.Owner = this;
            form.boxDictionaries.Text = String.Join("\n", fhl_dic_php_shell.list);
            form.button1.Click += new System.EventHandler(delegate (object s, EventArgs ev)
            {
                string[] ts2arr = form.boxDictionaries.Text.Split('\n');
                ts2arr = ts2arr.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                Array.Sort(ts2arr);
                fhl_dic_php_shell.list = ts2arr;
                form.Close();
            });
            form.ShowDialog();
        }
    }
}
