using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fhl.core.dictionaries
{
    class fhl_hunting
    {
        public static List<fhl_logfile_instance_node> error_5xx = new List<fhl_logfile_instance_node>();
        public static List<fhl_logfile_instance_node> attach_Path_Traversal = new List<fhl_logfile_instance_node>();
        public static List<fhl_logfile_instance_node> attach_XSS = new List<fhl_logfile_instance_node>();

        public static void doHuntind(object sender, DoWorkEventArgs e)
        {
            int i = 0;
            error_5xx = new List<fhl_logfile_instance_node>();

            //foreach (fhl_logfile_instance f in fhl_core.Files)
            //{
            //    foreach(fhl_logfile_instance_node cr in f.rows)
            //    {
            //        foreach(fhl_websrv_var r in cr.)
            //    }
            //}
            for (int iterFile = 0; iterFile < fhl_core.Files.Count; iterFile++)
            {
                for(int iterRequest=0; iterRequest < fhl_core.Files[iterFile].rows.Count; iterRequest++)
                {
                    fhl_logfile_instance_node  tempRequest = fhl_core.Files[iterFile].rows[iterRequest];
                   
                    var HTTP_CODE = tempRequest.params_list.Find(item => item.var == "$status");
                    var REQUEST = tempRequest.params_list.Find(item => item.var == "$request");

                    // Проверка на 5xx ошибку
                    if (Int32.Parse(HTTP_CODE.value) >= 500)
                    {
                        fhl_hunting.error_5xx.Add(tempRequest);
                    }

                    //Path Traversal (Обратный путь в директориях )
                    if (REQUEST.value.IndexOf("../") != -1)
                    {
                        attach_Path_Traversal.Add(tempRequest);
                    }   
                    //XSS
                    if (REQUEST.value.IndexOf("%22%3E") != -1)
                    {
                        attach_XSS.Add(tempRequest);
                    }
                }
            }


        }



    }
}
