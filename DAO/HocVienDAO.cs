using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using DTO;
using RestSharp;

namespace DAO
{
    public class HocVienDAO
    {
        public HocVienDAO() { }

        public bool insertHocVien(HocVien hv)
        {
            bool result = true;
            var client = new RestClient("http://10.0.2.2:8001");

            var request = new RestRequest("/add_new_student/", Method.POST);

            // Json to post.
            string jsonToSend = Newtonsoft.Json.JsonConvert.SerializeObject(hv);

            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            try
            {
                client.ExecuteAsync(request, response =>
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                });
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
