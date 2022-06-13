using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;

namespace Common
{
    public class HTTPClass
    {
        public Response HTTP(string _url, string _type, string _postdata, string _cookie, Encoding _responseEncode)
        {
            try
            {
                TcpClient clientSocket = new TcpClient();
                Uri URI = new Uri(_url);
                clientSocket.Connect(URI.Host, URI.Port);
                StringBuilder RequestHeaders = new StringBuilder();
                RequestHeaders.Append(_type + " " + URI.PathAndQuery + " HTTP/1.1\r\n");
                RequestHeaders.Append("Content-Type:application/x-www-form-urlencoded\r\n");
                RequestHeaders.Append("User-Agent:Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.11 (KHTML, like Gecko) Chrome/23.0.1271.64 Safari/537.11\r\n");
                RequestHeaders.Append("Cookie:" + _cookie + "\r\n");
                RequestHeaders.Append("Accept:*/*\r\n");
                RequestHeaders.Append("Host:" + URI.Host + "\r\n");
                RequestHeaders.Append("Content-Length:" + _postdata.Length + "\r\n");
                RequestHeaders.Append("Connection:close\r\n\r\n");
                byte[] request = Encoding.UTF8.GetBytes(RequestHeaders.ToString() + _postdata);
                clientSocket.Client.Send(request);
                byte[] responseByte = new byte[1024000];
                int len = clientSocket.Client.Receive(responseByte);
                string result = Encoding.UTF8.GetString(responseByte, 0, len);
                clientSocket.Close();
                int headerIndex = result.IndexOf("\r\n\r\n");
                string[] headerStr = result.Substring(0, headerIndex).Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                Dictionary<string, string> responseHeader = new Dictionary<string, string>();
                for (int i = 0; i < headerStr.Length; i++)
                {
                    string[] temp = headerStr[i].Split(new string[] { ": " }, StringSplitOptions.RemoveEmptyEntries);
                    if (temp.Length == 2)
                    {
                        if (responseHeader.ContainsKey(temp[0]))
                        {
                            responseHeader[temp[0]] = temp[1];
                        }
                        else
                        {
                            responseHeader.Add(temp[0], temp[1]);
                        }
                    }
                }
                Response response = new Response();
                response.HTTPResponseHeader = responseHeader;
                string[] httpstatus = headerStr[0].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                if (httpstatus.Length > 2)
                {
                    response.HTTPStatusCode = httpstatus[1];
                }
                else
                {
                    response.HTTPStatusCode = "400";
                }
                response.HTTPResponseText = _responseEncode.GetString(Encoding.UTF8.GetBytes(result.Substring(headerIndex + 4)));
                return response;
            }
            catch
            {
                return null;
            }
        }
    }
    public class Response
    {
        string hTTPStatusCode;
        ///
        /// http状态代码
        ///
        public string HTTPStatusCode
        {
            get { return hTTPStatusCode; }
            set { hTTPStatusCode = value; }
        }
        Dictionary<string,string> hTTPResponseHeader;
        ///
        /// Response的header
        ///
        public Dictionary<string,string> HTTPResponseHeader
        {
            get { return hTTPResponseHeader; }
            set { hTTPResponseHeader = value; }
        }
        string hTTPResponseText;
        ///
        /// html代码
        ///
        public string HTTPResponseText
        {
            get { return hTTPResponseText; }
            set { hTTPResponseText = value; }
        }
    }
}
