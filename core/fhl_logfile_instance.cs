using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fhl.core
{
    /// <summary>
    /// Класс описывающий объект в котором находитяться данные непосредтсвенно текущего файла лога
    /// </summary>
    class fhl_logfile_instance
    {
        /// <summary>
        /// Имя файла лога
        /// </summary>
        public string filename;
        /// <summary>
        /// Исходный текст файла
        /// </summary>
        public string sourceText;
        /// <summary>
        /// Лист с разобраными на объекты строками закпросов к веб серверу.
        /// </summary>
        public List<fhl_logfile_instance_node> rows = new List<fhl_logfile_instance_node>();

        public fhl_logfile_instance(string f, string s)
        {
            filename = f;
            sourceText = s;
            //MessageBox.Show(s);
            string[] tempRows = s.Split(new string[] { fhl_core.EndLineString }, StringSplitOptions.RemoveEmptyEntries);
            //MessageBox.Show(tempRows[1]);
            int iterActiveRequest = 0;
            foreach (string ss in tempRows)
            {
                ///
                /// Закоментировано по причине возможных оибочных срабатываний.
                /// Так как проверяется вся строка запроса и в ней может находиться важная информация.
                ///

                //if (fhl_core.FilteringOnOpeningFiles)   // Фильтрация запросов на этапе открытия
                //{
                //    var tAdd_success = false;
                //    foreach (string wip in fhl_core.WhiteIPList)
                //    {
                //        if (ss.IndexOf(wip) == -1)
                //        {
                //            tAdd_success = true;
                //        }
                //    }
                //    if (tAdd_success)
                //    {
                //        rows.Add(new fhl_logfile_instance_node(ss));
                //    }
                //}
                //else
                //{
                    rows.Add(new fhl_logfile_instance_node(ss));
                //}
            }
            fhl_core.AllCountRequest += rows.Count;
        }

    }
}
