using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fhl.core
{
    /// <summary>
    /// Класс описывающий структуру кокретного файла лога
    /// </summary>
    class fhl_logfile_instance_node
    {
        public fhl_logfile_instance_node(string s)
        {
            request = s;
            params_list = new List<fhl_websrv_var>();
        }

        public string request;       // Строка в оригинале
        public List<fhl_websrv_var> params_list; // Разобранные переменные со значениямии из строки запроса.
    }
}
