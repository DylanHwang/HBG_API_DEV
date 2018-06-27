using HGB_DI_MONI.domain;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Json;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HGB_DI_MONI.service
{
    class HttpConnects
    {
        private string apiUrl;
        private string apiKey;
        private string secret;
        //private string rqJson;

        public HttpConnects(string apiUrl, string apiKey, string secret)
        {
            this.apiUrl = apiUrl;
            this.apiKey = apiKey;
            this.secret = secret;
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
                httpWebRequest.Headers["X-Signature"] = XSignature_Generate();
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
            catch (WebException e)
            {
                var error_msg = "This program is expected to throw WebException on successful run." +
                                    "\n\nException Message :" + e.Message + "\n";
                //Console.WriteLine(error_msg);

                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    //Console.WriteLine("Status Code : {0}", ((HttpWebResponse)e.Response).StatusCode);
                    //Console.WriteLine("Status Description : {0}", ((HttpWebResponse)e.Response).StatusDescription);
                    var resp =  new StreamReader(e.Response.GetResponseStream()).ReadToEnd();
                    JObject obj = JObject.Parse(resp);

                    Console.WriteLine("Error:" + obj["error"]["message"].ToString());
                    error_msg += "Detail: " + obj["error"]["message"].ToString();

                }

                rsResult.result = error_msg;
                rsResult.rq_status = false;
                // Console.WriteLine("error -------------: " + e.ToString());
            }
            catch (Exception ex)
            {                
                rsResult.result = ex.Message;
                rsResult.rq_status = false;
                //Console.WriteLine("error -------------: " + ex.ToString());
            }

            return rsResult;
        }
        
        public async Task<RSResult> GetHotelContents(int from, int to)
        {          

    

         RSResult rsResult = new RSResult();

        try
        {

        //        do
        //        {
             string numberOfData = "&from=" + from + "&to=" + to;

             Console.WriteLine(apiUrl + numberOfData);

             Uri url = new Uri(apiUrl + numberOfData);
             var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
             httpWebRequest.ContentType = "application/json";
             httpWebRequest.Accept = "application/json";
             httpWebRequest.Method = WebRequestMethods.Http.Get;
             httpWebRequest.Headers["Api-key"] = apiKey;
             httpWebRequest.Headers["X-Signature"] = XSignature_Generate();
             httpWebRequest.Timeout = 100000;

             var response = await httpWebRequest.GetResponseAsync();
             Stream responseStream = response.GetResponseStream();
             StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8);

            //    string json_result = streamReader.ReadToEnd();


            //            if (total_number == 0)
            //            {
            //                List<HotelContent> hotelContentsList = new List<HotelContent>();
            //                JObject obj = JObject.Parse(json_result);
            //                Console.WriteLine(obj["total"].ToString());
            //                total_number = int.Parse(obj["total"].ToString());
            //            }

            //            await Json_Paring(json_result);

            rsResult.result = streamReader.ReadToEnd();
            rsResult.rq_status = true;

             streamReader.Close();
             responseStream.Close();
             response.Close();

        //            current_from = current_to + 1;
        //            current_to = current_from + 999;

        //        } while (total_number > current_from);

            //rsResult.rq_status = true;
        //        rsResult.result = hotelContentsList;

        }
         catch (WebException e)
            {
                var error_msg = "This program is expected to throw WebException on successful run." +
                                    "\n\nException Message :" + e.Message + "\n";
                //Console.WriteLine(error_msg);

                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    //Console.WriteLine("Status Code : {0}", ((HttpWebResponse)e.Response).StatusCode);
                    //Console.WriteLine("Status Description : {0}", ((HttpWebResponse)e.Response).StatusDescription);
                    var resp = new StreamReader(e.Response.GetResponseStream()).ReadToEnd();
                    JObject obj = JObject.Parse(resp);

                    //Console.WriteLine("Error:" + obj["error"]["message"].ToString());
                    error_msg += "Detail: " + obj["error"]["message"].ToString();

                }

                rsResult.result = error_msg;
                rsResult.rq_status = false;
                //Console.WriteLine("error -------------: " + e.ToString());
            }
            catch (Exception ex)
            {
                rsResult.result = ex.Message;
                rsResult.rq_status = false;
                //Console.WriteLine("error -------------: " + ex.ToString());
            }

            return rsResult;
        }

        public string XSignature_Generate()
        {          

            // Compute the signature to be used in the API call (combined key + secret + timestamp in seconds)
            string signature;
            using (var sha = SHA256.Create())
            {
                long ts = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds / 1000;
                Console.WriteLine("Timestamp: " + ts);
                var computedHash = sha.ComputeHash(Encoding.UTF8.GetBytes(apiKey + secret + ts));
                signature = BitConverter.ToString(computedHash).Replace("-", "");
            }

            return signature;
        }

    }
}
