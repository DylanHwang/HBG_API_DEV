using HGB_DI_MONI.domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Json;
using System.Text;
using System.Threading.Tasks;

namespace HGB_DI_MONI.service
{
    class HttpConnects
    {
        private string apiUrl;
        private string apiKey;
        private string xSignature;
        private string rqJson;

        public HttpConnects(string apiUrl, string apiKey, string xSignature)
        {
            this.apiUrl = apiUrl;
            this.apiKey = apiKey;
            this.xSignature = xSignature;
        }

        public async Task<RSResult>  searhAllRoomsInHotelS(string rqJson)
        {

            RSResult rsResult = new RSResult();

            try
            {
                Uri url = new Uri(apiUrl);
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Accept = "application/json";
                httpWebRequest.Method = WebRequestMethods.Http.Post;
                httpWebRequest.Headers["Api-key"] = apiKey;
                httpWebRequest.Headers["X-Signature"] = xSignature;
                httpWebRequest.Timeout = 60000;

                JsonTextParser jtp = new JsonTextParser();
                JsonObjectCollection res = (JsonObjectCollection)jtp.Parse(rqJson);

                byte[] data = Encoding.UTF8.GetBytes(res.ToString());
                httpWebRequest.ContentLength = data.Length;

                Stream dataStream = httpWebRequest.GetRequestStream();
                dataStream.Write(data, 0, data.Length);
                dataStream.Close();

                var response = await httpWebRequest.GetResponseAsync();
                Stream responseStream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8);

                rsResult.result = streamReader.ReadToEnd();
                rsResult.rq_status = true;

                streamReader.Close();
                responseStream.Close();
                response.Close();

                Console.WriteLine(rsResult.result);

            }
            catch(Exception ex)
            {                
                rsResult.result = ex.Message;
                rsResult.rq_status = false;
                Console.WriteLine("error -------------: " + ex.ToString());

            }

            return rsResult;
        }
        


    }
}
