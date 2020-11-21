using fhl.core.dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fhl.core
{
    class fhl_websrv_conf
    {
        public string log_format;
        public string log_format_regxPattern;
        public List<fhl_websrv_var> existVariable;
        public fhl_websrv_var[] log_vars;
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
