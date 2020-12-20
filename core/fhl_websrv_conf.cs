using fhl.core.dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fhl.core
{
    class fhl_websrv_conf
    {
        public string log_format;                   // Строка формата лога для текущей веб платформы.
        public string log_format_regxPattern;       // Строка в виде регулярного выражения полученная из строки формата лога.
        public List<fhl_websrv_var> existVariable;  // Список найденных перменных для текущего формата лога.
        public fhl_websrv_var[] log_vars;           // Список вохможных перменных для текущей веб платформы.

        /// <summary>
        /// Метод (get) для получения списка переменных формата для текущей веб платформы.
        /// </summary>
        /// <returns></returns>
        public string[] getLogVars()
        {
            List<string> t1 = new List<string>();
            foreach (fhl_websrv_var v in log_vars)
            {
                t1.Add(v.var);
            }

            return t1.ToArray();
        }

        /// <summary>
        /// Метод (set) для установки нового списка переменных формата для текущей веб платформы.
        /// </summary>
        /// <param name="vars"></param>
        public void setLogVars(string[] vars)
        {
            var tvm = new List< fhl_websrv_var>();
            foreach (string v in vars)
            {
               tvm.Add(new fhl_websrv_var(v, "(.*)"));
            }
            log_vars = tvm.ToArray();
        }

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="ws_name"></param>
        public fhl_websrv_conf(string ws_name)
        {
            if (ws_name == "Nginx")
            {
                log_format = fhl_dic_nginx.default_format_string;
                log_vars = fhl_dic_nginx.default_format_log_vars;
                existVariable = new List<fhl_websrv_var>();
            }
            // Add сюда and another сервера 
        }

    }
}
