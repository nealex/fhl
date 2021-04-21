using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
namespace fhl.core
{
    /// <summary>
    /// Ядро охотника
    /// </summary>
    class fhl_core
    {
        /// <summary>
        /// Режим отладки
        /// </summary>
        public static bool Debug = true;
        public static bool Run = false;
        public static bool MeOpenFiles = false;
        public static bool KernelPanic = false;
        public static int ThreadParse = 1;

        public static BackgroundWorker openFilesWorker;
        public static BackgroundWorker parseFilesWorker;
        public static BackgroundWorker huntingWorker;

        /// <summary>
        /// Конфигурация под тот веб сервер который будет вестись анализ.
        /// </summary>
        public static fhl_websrv_conf ws_cfg = new fhl_websrv_conf("Nginx");
        /// <summary>
        /// Стандартные для RegExp символы которые необходимо игнорировать.
        /// </summary>
        public static List<fhl_websrv_var> defaultRegxEscape = new List<fhl_websrv_var>()
        {
            new fhl_websrv_var("(","\\("),
            new fhl_websrv_var(")","\\)"),
            new fhl_websrv_var("[","\\["),
            new fhl_websrv_var("]","\\]"),
            new fhl_websrv_var(" ","\\s"),
        };
        /// <summary>
        /// Лист с лог файлами и их структурой
        /// </summary>
        public static List<fhl_logfile_instance> Files = new List<fhl_logfile_instance>();
        /// <summary>
        /// Список лог файлов
        /// </summary>
        public static string[] FileNames;
        /// <summary>
        /// Флаг: нужно ли фильтровать запросы по белому списку ip на этапе открытия файлов.
        /// </summary>
        public static bool FilteringOnOpeningFiles = true;

        /// <summary>
        /// Флаг: Фильтрация запросов по IP на этапе анализа
        /// </summary>
        public static bool FilteringOnHunting = false;

        public static List<string> WhiteIPList = new List<string>() {"localhost","127.0.0.1"};

        public static int AllCountRequest = 0;

        public static string EndLineString = Environment.NewLine;


        /// <summary>
        /// Метод получения из пользовательской строки формата лога строки для RegEx выражения
        /// </summary>
        /// <param name="UserFormat"></param>
        /// <param name="ServerVar"></param>
        /// <returns></returns>
        public static string getLogFormatPatternRegex(string UserFormat, fhl_websrv_var[] ServerVar)
        {
            fhl_core.ws_cfg.existVariable.Clear();
            string tempUserFormat = UserFormat;
            // Опеределяем какие переменные сервера есть в пользовательском формате и их порядковые номера
            for (int i = 0; i < ServerVar.Length; i++)
            {
                int num = tempUserFormat.IndexOf(ServerVar[i].var);
                if (num != -1)
                {
                    //// Баг фикс который позволяет исправляет ошибку с однокоренными словами типа $request и $request_body
                    //// заменяя уже найденное слово звездочками той-же длинны слова.
                    string repTempString = "";
                    for(int iterCSVar =0; iterCSVar< ServerVar[i].var.Length; iterCSVar++)
                    {
                        repTempString += "*";
                    }
                    tempUserFormat = tempUserFormat.Replace(ServerVar[i].var, repTempString);
                    fhl_websrv_var tmp_d = new fhl_websrv_var(ServerVar[i].var, num.ToString());
                    //MessageBox.Show(string.Format("{0} - {1}", tmp_d.var, tmp_d.value));
                    fhl_core.ws_cfg.existVariable.Add(tmp_d);
                }
            }
            // Сортировка списка найденных переменных по их положению (порядку) в формате лога
            fhl_core.ws_cfg.existVariable = fhl_core.ws_cfg.existVariable.OrderBy(x => Int32.Parse(x.value)).ToList();

            // Сначала пытаемся убрать те символы которые влияют на корректность Regx
            for (int i = 0; i < defaultRegxEscape.Count; i++)
            {
                UserFormat = UserFormat.Replace(defaultRegxEscape[i].var, defaultRegxEscape[i].value);
            }
            // Далее ищем переменные для веб сервера Nginx
            for (int i = 0; i < ServerVar.Length; i++)
            {
                UserFormat = UserFormat.Replace(ServerVar[i].var, ServerVar[i].value);
            }

            return ws_cfg.log_format_regxPattern = UserFormat;
        }
    }
}
