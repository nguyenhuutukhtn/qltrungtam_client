using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using RestSharp;
using System.Threading;
using System.Net;

namespace DAO
{
    public class TeacherDAO
    {
        public TeacherDAO() { }
        public List<Staff> getAllTeachers()
        {
            List<Staff> result = new List<Staff>();

            var client = new RestClient(URL.root);

            var request = new RestRequest(URL.get_all_teachers_endpoint, Method.GET);

            try
            {
                EventWaitHandle Wait = new AutoResetEvent(false);
                client.ExecuteAsync(request, response =>
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Staff>>(response.Content);
                        Wait.Set();
                    }
                    else
                    {

                    }
                });
                Wait.WaitOne();
            }
            catch (Exception error)
            {
                // Log

            }
            return result;
        }
    }
}
