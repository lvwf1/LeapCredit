using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace SlarkInc.HttpHelper
{
    public class RestUtils
    {
        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }
        public static string SendRestfulRequest(string basePath, string extraPath, string requestMethod, string userAgent, string contentData, Dictionary<string, string> headers)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(basePath);
            sb.Append(extraPath);

            string respStr = string.Empty;

            try
            {
                Uri uri = new Uri(sb.ToString());
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Method = requestMethod;
                request.KeepAlive = true;
                request.Timeout = 2000000;

                SetRequsetHeaders(request, headers);

                if (requestMethod.ToUpper() != "GET" && contentData != null)
                {
                    request.ContentType = "application/xml";
                    byte[] bytes = Encoding.UTF8.GetBytes(contentData);
                    request.ContentLength = bytes.Length;

                    Stream os = null;
                    os = request.GetRequestStream();
                    os.Write(bytes, 0, bytes.Length);
                    os.Flush();
                    os.Close();
                }

                using (HttpWebResponse resp = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(resp.GetResponseStream());
                    respStr = reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                
                if (ex.Response != null)
                {
                    string responseString = "";
                    using (Stream responseStream = ex.Response.GetResponseStream())
                    {
                        using (StreamReader responseReader = new System.IO.StreamReader(responseStream, Encoding.UTF8))
                        {
                            responseString = responseReader.ReadToEnd();
                        }
                    }
                    
                }
                
            }
            return respStr;
        }

        public static WebHeaderCollection ToGetHeadersSendRestfulRequest(string basePath, string extraPath, string requestMethod, string accept, string contentType, string userAgent, string contentData, Dictionary<string, string> headers)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(basePath);
            sb.Append(extraPath);

            string respStr = string.Empty;

            try
            {
                Uri uri = new Uri(sb.ToString());
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Method = requestMethod;
                request.KeepAlive = true;
                request.Timeout = 2000000;
                if (!String.IsNullOrEmpty(contentType)) request.ContentType = contentType;
                if (!String.IsNullOrEmpty(accept)) request.Accept = accept;
                if (!String.IsNullOrEmpty(userAgent)) request.UserAgent = userAgent;

                foreach (var item in headers)
                {
                    request.Headers.Add(item.Key, item.Value);
                }
                if ((requestMethod.ToUpper() == "POST" || requestMethod.ToUpper() == "PUT") && contentData != null)
                {
                    request.ContentType = "application/x-www-form-urlencoded";
                    byte[] bytes = Encoding.UTF8.GetBytes(contentData);
                    request.ContentLength = bytes.Length;

                    Stream os = null;
                    os = request.GetRequestStream();
                    os.Write(bytes, 0, bytes.Length);
                    os.Flush();
                    os.Close();
                }

                using (HttpWebResponse resp = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(resp.GetResponseStream());
                    WebResponse response = request.GetResponse();
                    return response.Headers;
                }
            }
            catch (WebException ex)
            {
                
                if (ex.Response != null)
                {
                    String responseString = "";
                    using (Stream responseStream = ex.Response.GetResponseStream())
                    {
                        using (StreamReader responseReader = new System.IO.StreamReader(responseStream, Encoding.UTF8))
                        {
                            responseString = responseReader.ReadToEnd();
                            
                        }
                        
                    }
                    
                }
                return new WebHeaderCollection();
                
            }
        }

        public static void SetRequsetHeaders(HttpWebRequest request, Dictionary<string, string> headers)
        {
            foreach (var item in headers)
            {
                switch (item.Key.ToLower())
                {
                    case "accept":
                        request.Accept = item.Value;
                        break;
                    case "connection":
                        request.Connection = item.Value;
                        break;
                    case "contentlength":
                        request.ContentLength = Convert.ToInt64(item.Value);
                        break;
                    case "contenttype":
                        request.ContentType = item.Value;
                        break;
                    case "agent":
                        request.UserAgent = item.Value;
                        break;
                    case "transferencoding":
                        //request.SendChunked = true;
                        //request.TransferEncoding = item.Value;
                        break;
                    case "expect":
                        request.Expect = item.Value;
                        break;
                    case "x-auth-token":
                        request.Headers.Add(item.Key, item.Value);
                        break;
                    case "to_host":
                        request.Headers.Add(item.Key, item.Value);
                        break;
                    case "authorization":
                        request.Headers.Add(item.Key, item.Value);
                        break;
                }
            }
        }

        public static Stream GetStream_SendRestfulRequest(string basePath, string extraPath, string requestMethod, string userAgent, string contentData, Dictionary<string, string> headers)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(basePath);
            sb.Append(extraPath);


            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sb.ToString());
                request.Method = requestMethod;
                request.KeepAlive = true;
                request.Timeout = 2000000;

                SetRequsetHeaders(request, headers);
                if (requestMethod.ToUpper() != "GET" && contentData != "")
                {
                    request.ContentType = "application/json";
                    byte[] bytes = Encoding.UTF8.GetBytes(contentData);
                    request.ContentLength = bytes.LongLength;

                    Stream os = null;
                    os = request.GetRequestStream();
                    os.Write(bytes, 0, bytes.Length);
                    os.Flush();
                    os.Close();
                }

                WebResponse resp = request.GetResponse();

                Stream responseStream = resp.GetResponseStream();

                return responseStream;

            }
            catch (WebException ex)
            {
               
                if (ex.Response != null)
                {
                    string responseStr = "";
                    using (Stream responseStream = ex.Response.GetResponseStream())
                    {
                        StreamReader responseReader = new StreamReader(responseStream, Encoding.UTF8);
                        responseStr = responseReader.ReadToEnd();
                        
                    }
                   
                }
                return ex.Response.GetResponseStream();
            }
        }

        public static T SerialObject<T>(T tObj, string basePath, string extraPath, string requestMethod, string userAgent, string contentData, Dictionary<string, string> headers) where T : class
        {
            Stream stream = GetStream_SendRestfulRequest(basePath, extraPath, requestMethod, userAgent, contentData, headers);
            StreamReader reader = new StreamReader(stream);
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
                tObj = ser.ReadObject(reader.BaseStream) as T;
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                reader.Close();
                stream.Close();
            }
            return tObj;
        }

        public static void SendHttpWebRequest(string basePath, string extraPath, string requestMethod, string userAgent, string contentData, Dictionary<string, string> headers)
        {
            string strId = "guest";
            string strPassword = "123456";

            ASCIIEncoding encoding = new ASCIIEncoding();
            string postData = "userid=" + strId;
            postData += ("&password=" + strPassword);

            byte[] data = encoding.GetBytes(postData);

            // Prepare web request...
            HttpWebRequest myRequest =
             (HttpWebRequest)WebRequest.Create("http://www.here.com/login.asp");

            myRequest.Method = "POST";
            myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.ContentLength = data.Length;
            Stream newStream = myRequest.GetRequestStream();

            // Send the data.
            newStream.Write(data, 0, data.Length);
            newStream.Close();

            // Get response
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.Default);
            string content = reader.ReadToEnd();
            Console.WriteLine(content);
        }

        public static string SendGetRestfulRequestWithDefaultHeaders(string basePath, string extraPath, string contentData, string requestMethod, string accept = "", string contentType = "")
        {

            StringBuilder sb = new StringBuilder();
            sb.Append(basePath);
            sb.Append(extraPath);

            //string encodedUrl = RestUtils.RealUrlEncode(sb.ToString());

            string respStr = string.Empty;
            try
            {
                // Ignore SSL cert errors
                // System.Net.ServicePointManager.CertificatePolicy = new TrustAllCertificatePolicy();
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sb.ToString());
                request.Method = requestMethod;
                request.KeepAlive = true;
                request.Timeout = 2000000;
                request.CookieContainer = new CookieContainer();

                if (!String.IsNullOrEmpty(contentType)) request.ContentType = contentType;
                if (!String.IsNullOrEmpty(accept)) request.Accept = accept;
                // contentData (form data) is only applicable to POST and PUT (not GET or DELETE)
                if ((requestMethod.ToUpper() == "POST" || requestMethod.ToUpper() == "PUT") && contentData != null)
                {
                    request.ContentType = "application/x-www-form-urlencoded";
                    byte[] bytes = Encoding.ASCII.GetBytes(contentData);
                    request.ContentLength = bytes.Length;

                    Stream os = null;
                    os = request.GetRequestStream();
                    os.Write(bytes, 0, bytes.Length);
                    os.Flush();
                    os.Close();
                }

                using (HttpWebResponse resp = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(resp.GetResponseStream());

                    respStr = reader.ReadToEnd();
                    
                }
            }
            catch (Exception ex)
            {
                //respStr = string.Format("{0}: {1}", ConfigHelper.GLOBAL_ERROR_NAME, ex.ToString());
                throw new ApplicationException(ex.Message, ex);
            }

           
            Console.Write(respStr);
            Console.Read();
            return respStr;
        }

    }
}