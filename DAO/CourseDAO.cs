using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using RestSharp;
using System.Net;
using System.Threading;

namespace DAO
{
    public class CourseDAO
    {
        public CourseDAO() { }
        public List<Course> getAllCourse()
        {
            List<Course> result = new List<Course>();

            var client = new RestClient(URL.root);

            var request = new RestRequest(URL.get_all_courses_endpoint, Method.GET);

            try
            {
                EventWaitHandle Wait = new AutoResetEvent(false);
                client.ExecuteAsync(request, response =>
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Course>>(response.Content);
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
        public bool AddNewCourse(TimeTable timetable)
        {
            bool result = true;
            var client = new RestClient(URL.root);

            var request = new RestRequest(URL.add_new_course_endpoint, Method.POST);

            // Json to post.
            string jsonToSend = Newtonsoft.Json.JsonConvert.SerializeObject(timetable);

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
    }
}
