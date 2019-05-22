using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using DTO;
using RestSharp;
using System.Threading;

namespace DAO
{
    public class StudentDAO
    {
        public StudentDAO() { }

        public bool insertNewStudent(Student hv)
        {
            bool result = true;
            var client = new RestClient(URL.root);

            var request = new RestRequest(URL.add_new_student_endpoint, Method.POST);

            // Json to post.
            string jsonToSend = Newtonsoft.Json.JsonConvert.SerializeObject(hv);

            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            try
            {
                EventWaitHandle Wait = new AutoResetEvent(false);
                client.ExecuteAsync(request, response =>
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        result = true;
                        Wait.Set();
                    }
                    else
                    {
                        result = false;
                    }
                });
                Wait.WaitOne();
            }
            catch (Exception error)
            {
                // Log
                result = false;
            }

            return result;
        }
        public bool updateStudent(Student hv)
        {
            bool result = true;
            var client = new RestClient(URL.root);

            var request = new RestRequest(URL.update_student_endpoint, Method.PUT);

            // Json to post.
            string jsonToSend = Newtonsoft.Json.JsonConvert.SerializeObject(hv);

            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            try
            {
                EventWaitHandle Wait = new AutoResetEvent(false);
                client.ExecuteAsync(request, response =>
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        result = true;
                        Wait.Set();
                    }
                    else
                    {
                        result = false;
                    }
                });
                Wait.WaitOne();
            }
            catch (Exception error)
            {
                // Log
                result = false;
            }

            return result;
        }

        public List<Student> getAllStudent()
        {
            List<Student> result = new List<Student>();

            var client = new RestClient(URL.root);

            var request = new RestRequest(URL.get_all_student_endpoint, Method.GET);

            try
            {
                EventWaitHandle Wait = new AutoResetEvent(false);
                client.ExecuteAsync(request, response =>
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Student>>(response.Content);
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
