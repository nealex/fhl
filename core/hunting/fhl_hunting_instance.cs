using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fhl.core.hunting
{
    /// <summary>
    /// Объект содержащий информацию о результате атаки и самом вредоносном запросе.
    /// </summary>
    class fhl_hunting_instance
    {
        public fhl_hunting_instance(fhl_hunting_result_type r, fhl_hunting_type t, fhl_logfile_instance_node s)
        {
            final_attack = r;
            type = t;
            request = s;
            signature = "";
        }
        public fhl_hunting_instance(fhl_hunting_result_type r, fhl_hunting_type t, fhl_logfile_instance_node s, string sign)
        {
            final_attack = r;
            type = t;
            request = s;
            signature = sign;
        }

        public string signature;

        /// <summary>
        /// Результат выполения атаки.
        /// </summary>
        public fhl_hunting_result_type final_attack;

        /// <summary>
        /// Тип атаки по классификации Fox Hunter Log.
        /// </summary>
        public fhl_hunting_type type;

        /// <summary>
        /// Объект с данными об атаке.
        /// </summary>
        public fhl_logfile_instance_node request;
    }
}
