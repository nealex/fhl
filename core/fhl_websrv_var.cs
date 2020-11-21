using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fhl.core
{
    // Структура для хранения одной переменной в формате лога веб сервера.
    struct fhl_websrv_var
    {
        // Конструктор
        public fhl_websrv_var(string a, string b)
        {
            var = a;
            value = b;
        }
        public string var;
        public string value;
    }
}
