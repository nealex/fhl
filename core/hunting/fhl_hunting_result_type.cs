using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fhl.core.hunting
{
    /// <summary>
    /// Варианты результа выполнения атаки злоумышленником.
    /// </summary>
    enum fhl_hunting_result_type
    {
        /// <summary>
        /// Результат атаки злоумышленника завершился успехом.
        /// </summary>
        Success = 1,
        /// <summary>
        /// Результат атаки злоумышленника привел к неопредленным результатм.
        /// </summary>
        Undefined = 2,
        /// <summary>
        /// Результат атаки злоумышленника заврешился неудачно.
        /// </summary>
        /// 
        Failed = 3
    }
}
