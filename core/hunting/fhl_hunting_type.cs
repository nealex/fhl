using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fhl.core.hunting
{
    enum fhl_hunting_type
    {
        /// <summary>
        /// Переполнение буфера в приложении.
        /// </summary>
        BufferOverflow,

        /// <summary>
        /// Внедрение операторов SQL
        /// </summary>
        SQLInjection,

        /// <summary>
        /// Межсайтовое выполнение сценариев.
        /// </summary>
        CrossSiteScripting,

        /// <summary>
        /// Обратный путь в директориях.
        /// </summary>
        PathTraversal,

        /// <summary>
        /// Выполнение команд ОС.
        /// </summary>
        OSCommanding,       //+

        /// <summary>
        /// Предсказуемое расположение ресурсов на сервере.
        /// </summary>
        PredictableResourceLocation,    //+

        ////////////////////////////////////////////////////////////////////////////////////////
        //// Нестандартные признаки/события возможно характеризируемые как атака
        ////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Попытка обращения к файлу потациально являющемуся бэекдором.
        /// </summary>
        BackdoorExecute,            //+

    }
}
