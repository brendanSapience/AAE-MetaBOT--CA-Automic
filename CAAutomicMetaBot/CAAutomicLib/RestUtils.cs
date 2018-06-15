using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using RestSharp;

namespace CAAutomicLib
{
    public class RestUtils
    {
        private static String ARAAPIPATH = "/ara/api/data/v";
        private static String AEAPIPATH = "/ae/api/v";
        private static String EDDAPATH = "/analytics/api/v";

        public String FormARAURL(Boolean isHttps,String Hostname, int Port, int ApiVersion)
        {
            String URL = "";
            URL = getUrlBeginning(isHttps) + Hostname + ":" + Port + ARAAPIPATH + ApiVersion + "/";
            return URL;
        }

        public String FormAEURL(Boolean isHttps, String Hostname, int Port, int ApiVersion,int Client)
        {
            String URL = "";
            URL = getUrlBeginning(isHttps) + Hostname + ":" + Port + AEAPIPATH + ApiVersion + "/"+Client+"/";
            return URL;
        }
        public String FormEDDAURL(Boolean isHttps, String Hostname, int Port, int ApiVersion)
        {
            String URL = "";
            URL = getUrlBeginning(isHttps) + Hostname + ":" + Port + EDDAPATH + ApiVersion + "/";
            return URL;
        }

        private String getUrlBeginning(Boolean isHttps)
        {
            if (isHttps)
            {
               return "https://";
            }
            else
            {
                return "http://";
            }
        }

        public String CallRestGETNoAuth(String URL)
        {

            System.Net.HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(URL);
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Method = "GET";
            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new System.IO.StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    return result;
                }
            }
            catch (System.Net.WebException e)
            {
                return "Error:" + e.Message;
            }
        }

        public String CallRestGETWithBasicAuth(String URL, String Login, String Password)
        {

            System.Net.HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(URL);
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Method = "GET";
            httpWebRequest.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(Login + ":" + Password));
            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new System.IO.StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    return result;
                }
            }
            catch (System.Net.WebException e)
            {
                return "Error:" + e.Message;
            }
        }

        public String CallRestPOSTWithBasicAuth(String URL, String Login, String Password, String JSONBody)
        {
            var client = new RestClient(URL);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(Login + ":" + Password)));
            request.AddParameter("application/json", JSONBody, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }
    }
}
