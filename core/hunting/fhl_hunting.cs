using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using fhl.core.dictionaries;
namespace fhl.core.hunting
{
    class fhl_hunting
    {
        //public static List<fhl_logfile_instance_node> error_5xx = new List<fhl_logfile_instance_node>();
        //public static List<fhl_logfile_instance_node> attach_Path_Traversal = new List<fhl_logfile_instance_node>();
        //public static List<fhl_logfile_instance_node> attach_XSS = new List<fhl_logfile_instance_node>();
        //public static List<fhl_logfile_instance_node> attack_access_admin_panel = new List<fhl_logfile_instance_node>();
        public static List<fhl_hunting_instance> results;
        public static void doHuntind(object sender, DoWorkEventArgs e)
        {
            results = new List<fhl_hunting_instance>();
            // int i = 0;
            // error_5xx = new List<fhl_logfile_instance_node>();

            for (int iterFile = 0; iterFile < fhl_core.Files.Count; iterFile++)
            {
                /// Если это веб сервер NGINX
                for (int iterRequest = 0; iterRequest < fhl_core.Files[iterFile].rows.Count; iterRequest++)
                {

                    fhl_logfile_instance_node tempRequest = fhl_core.Files[iterFile].rows[iterRequest];
                    var REMOTE_ADDR = tempRequest.params_list.Find(item => item.var == "$remote_addr").value;

                    // Если IP входит в белый список исключений, то пропускаем итерацию.
                    if (fhl_core.FilteringOnHunting)
                        if (fhl_core.WhiteIPList.Any(s => s.Contains(REMOTE_ADDR)))
                        {
                            // MessageBox.Show("Пропущен запрос с ip адреса: " + REMOTE_ADDR);
                            continue;
                        }

                    int HTTP_CODE = Int32.Parse(tempRequest.params_list.Find(item => item.var == "$status").value);
                    var REQUEST = tempRequest.params_list.Find(item => item.var == "$request");

                    // Проверка на доступ к админ панели
                    foreach (string cp in fhl_dic_admin_panels.list)
                    {
                        if (REQUEST.value.IndexOf(cp) != -1)
                        {
                            //  MessageBox.Show(REQUEST.value);
                            switch (HTTP_CODE)
                            {
                                case 500:
                                case 200:
                                    fhl_hunting.results.Add(new fhl_hunting_instance(fhl_hunting_result_type.Success, fhl_hunting_type.PredictableResourceLocation, tempRequest, "Предсказуемое расположение ресурсов")); break;
                                case 301:
                                case 302:
                                case 400:
                                case 404:
                                    fhl_hunting.results.Add(new fhl_hunting_instance(fhl_hunting_result_type.Failed, fhl_hunting_type.PredictableResourceLocation, tempRequest, "Предсказуемое расположение ресурсов")); break;
                            };
                        }
                    }

                    // Проверка на php шелы.
                    foreach (string ab in fhl_dic_php_shell.list)
                    {
                        if (REQUEST.value.IndexOf(ab) != -1)
                        {
                            switch (HTTP_CODE)
                            {
                                case 500:
                                case 200:
                                    fhl_hunting.results.Add(new fhl_hunting_instance(fhl_hunting_result_type.Success, fhl_hunting_type.BackdoorExecute, tempRequest, ab)); break;
                                case 301:
                                case 302:
                                case 400:
                                case 404:
                                    fhl_hunting.results.Add(new fhl_hunting_instance(fhl_hunting_result_type.Failed, fhl_hunting_type.BackdoorExecute, tempRequest, ab)); break;
                            };
                        }
                    }

                    // Проверка на ASP шелы.
                    foreach (string ab in fhl_dic_asp_shell.list)
                    {
                        if (REQUEST.value.IndexOf(ab) != -1)
                        {
                            switch (HTTP_CODE)
                            {
                                case 500:
                                case 200:
                                    fhl_hunting.results.Add(new fhl_hunting_instance(fhl_hunting_result_type.Success, fhl_hunting_type.BackdoorExecute, tempRequest, ab)); break;
                                case 301:
                                case 302:
                                case 400:
                                case 404:
                                    fhl_hunting.results.Add(new fhl_hunting_instance(fhl_hunting_result_type.Failed, fhl_hunting_type.BackdoorExecute, tempRequest, ab)); break;
                            };
                        }
                    }


                    // Проверка на выполнение универсальных комманд ОС
                    foreach (string ab in fhl_dic_os_commanding.list)
                    {
                        if ((ab.Length > 4) ? (REQUEST.value.IndexOf(ab) != -1) : (REQUEST.value.IndexOf(ab + " ") != -1) || (REQUEST.value.IndexOf(ab + "%20") != -1))
                        {
                            switch (HTTP_CODE)
                            {
                                case 500:
                                case 200:
                                    fhl_hunting.results.Add(new fhl_hunting_instance(fhl_hunting_result_type.Success, fhl_hunting_type.OSCommanding, tempRequest, ab)); break;
                                case 301:
                                case 302:
                                case 400:
                                case 404:
                                    fhl_hunting.results.Add(new fhl_hunting_instance(fhl_hunting_result_type.Failed, fhl_hunting_type.OSCommanding, tempRequest, ab)); break;
                            };
                        }
                    }

                    // Проверка на выполнение Unix комманд ОС
                    foreach (string ab in fhl_dic_os_unix.list)
                    {
                        //   if (REQUEST.value.IndexOf(ab) != -1)
                        if ((ab.Length > 4) ? (REQUEST.value.IndexOf(ab) != -1) : (REQUEST.value.IndexOf(ab + " ") != -1) || (REQUEST.value.IndexOf(ab + "%20") != -1))
                        {
                            switch (HTTP_CODE)
                            {
                                case 500:
                                case 200:
                                    fhl_hunting.results.Add(new fhl_hunting_instance(fhl_hunting_result_type.Success, fhl_hunting_type.OSCommanding, tempRequest, ab)); break;
                                case 301:
                                case 302:
                                case 400:
                                case 404:
                                    fhl_hunting.results.Add(new fhl_hunting_instance(fhl_hunting_result_type.Failed, fhl_hunting_type.OSCommanding, tempRequest, ab)); break;
                            };
                        }
                    }
                    // Проверка на выполнение Windows комманд ОС
                    foreach (string ab in fhl_dic_os_windows.list)
                    {
                        if ((ab.Length > 4) ? (REQUEST.value.IndexOf(ab) != -1) : (REQUEST.value.IndexOf(ab + " ") != -1) || (REQUEST.value.IndexOf(ab + "%20") != -1))
                        {
                            switch (HTTP_CODE)
                            {
                                case 500:
                                case 200:
                                    fhl_hunting.results.Add(new fhl_hunting_instance(fhl_hunting_result_type.Success, fhl_hunting_type.OSCommanding, tempRequest, ab)); break;
                                case 301:
                                case 302:
                                case 400:
                                case 404:
                                    fhl_hunting.results.Add(new fhl_hunting_instance(fhl_hunting_result_type.Failed, fhl_hunting_type.OSCommanding, tempRequest, ab)); break;
                            };
                        }

                    }
                }
            }


        }



    }
}
