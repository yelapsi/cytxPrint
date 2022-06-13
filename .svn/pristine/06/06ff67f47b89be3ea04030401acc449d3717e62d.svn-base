using System.IO;
using System.Net;
using System.Web;
using System.Text;
using Maticsoft.Common.Util;
using System;

namespace Maticsoft.Common
{
    public static class HTTPHelper
    {
        public static string HttpHandler(string message, string strURL)
        {
            string strResponse = "";
            string paraUrlCoded = "";
            string httpResult = "";
            //Stream s = null;
            byte[] payload = null;
            HttpWebRequest request = null;

            try
            {
                request = HTTPRequest(request, strURL, paraUrlCoded, message, payload);
                httpResult = HTTPResponse((HttpWebResponse)request.GetResponse(), strResponse);

                Global.TIME_OUT_TIMES = 0;
            }
            catch (Exception e)
            {
                Global.TIME_OUT_TIMES++;
                throw e;
            }
            return httpResult;
        }

        private static HttpWebRequest HTTPRequest(HttpWebRequest request, string strURL, string paraUrlCoded, string message, byte[] payload)
        {
            try
            {
                request = (HttpWebRequest)WebRequest.Create(strURL);
                request.Method = "POST";//Post请求方式
                request.ContentType = "application/x-www-form-urlencoded";// 内容类型
                paraUrlCoded = HttpUtility.UrlEncode(message);// 参数经过URL编码
                payload = Encoding.UTF8.GetBytes(paraUrlCoded);//将URL编码后的字符串转化为字节
                request.ContentLength = payload.Length;//设置请求的 ContentLength
                using (Stream witer = request.GetRequestStream())
                {
                    witer.Write(payload, 0, payload.Length);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return request;
            //Stream writer = request.GetRequestStream();//获得请 求流
            //writer.Write(payload, 0, payload.Length);//将请求参数写入流
            //writer.Close();// 关闭请求流
        }

        private static string HTTPResponse(HttpWebResponse response, string strResponse)
        {
            try
            {
                Stream stream = response.GetResponseStream();
                if (null != stream)
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        return strResponse = reader.ReadToEnd();
                    }
                }
                else
                {
                    System.Net.WebException webE = new WebException("未找到缓存",WebExceptionStatus.CacheEntryNotFound);
                    throw webE;
                }
            }
            catch (System.Net.WebException webE)
            {
                throw webE;
            }catch(ArgumentException ){
                return "";
            }
        }
    }
}