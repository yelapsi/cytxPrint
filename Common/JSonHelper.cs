using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Maticsoft.Common.model;
using Maticsoft.Common.model.httpmodel;
using System.Text.RegularExpressions;

namespace Maticsoft.Common
{
    public class JSonHelper
    {
        public static string ObjectToJson(object obj)
        {
            if (obj == null)
            {
                return string.Empty;
            }

            string myJson = JsonConvert.SerializeObject(obj);
            return myJson;
        }

        //public static object JsonToMessageTemplet(string myJson)
        //{
        //    try
        //    {
        //        MessageTemplet mt = new MessageTemplet();
        //        JObject message = JObject.Parse(myJson);
        //        JToken messageInfo = message;
        //        string temp = null;
        //        mt = JsonConvert.DeserializeObject<MessageTemplet>(messageInfo.ToString());
        //        mt.msg.head = JsonConvert.DeserializeObject<MessageTemplet.Message.Head>(message["msg"]["head"].ToString());
        //        if (message["msg"]["body"]["tickets"] != null)
        //        {
        //            temp = message["msg"]["body"]["tickets"].ToString().Replace("[", "").Replace("]", "");
        //        }
        //        if (!String.IsNullOrEmpty(temp))
        //        {
        //            mt.msg.body = JsonToTicketsList(message["msg"]["body"].ToString());
        //        }
        //        else
        //        {
        //            mt.msg.body = null;
        //        }
        //        return mt;
        //    }
        //    catch (Exception ce)
        //    {
        //        throw new CustomException("", "数据转换失败:" + ce.Message, "");
        //    }

        //}

        //public static MessageTemplet.Message.Head JsonToHead(string jsonHead)
        //{
        //    MessageTemplet.Message.Head head = new MessageTemplet.Message.Head();

        //    JObject jHead = JObject.Parse(jsonHead);
        //    JToken tHead = jHead;
        //    head = JsonConvert.DeserializeObject<MessageTemplet.Message.Head>(tHead.ToString());
        //    return head;
        //}

        public static Body1000Response JsonToTicketsList(string jsonTickets)
        {
            try
            {
                Body1000Response body1000 = new Body1000Response();

                JObject jBody1000 = JObject.Parse(jsonTickets);
                JToken messageInfo = jBody1000;
                body1000 = JsonConvert.DeserializeObject<Body1000Response>(jsonTickets.ToString());

                JObject content = JObject.Parse(jsonTickets);
                JEnumerable<JToken> tickets = content["tickets"].Children();
                IList<lottery_ticket> ticketsList = new List<lottery_ticket>();
                foreach (JToken item in tickets)
                {
                    //lottery_ticket lt = JsonConvert.DeserializeObject<lottery_ticket>(item.ToString());
                    lotteryTicket lT = JsonConvert.DeserializeObject<lotteryTicket>(item.ToString());
                    lottery_ticket lt = new lottery_ticket(lT);
                    lt.order_id = body1000.orderId;
                    lt.license_id = body1000.licenseId;
                    ticketsList.Add(lt);
                }
                //body1000.tickets = ticketsList;
                return body1000;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public static Body1001FeedbackResult JsonToFeedback(string myJson)
        //{
        //    try
        //    {
        //        Body1001FeedbackResult body1001FeedbackResult = new Body1001FeedbackResult();
        //        JObject message = JObject.Parse(myJson);
        //        JToken messageInfo = message;
        //        body1001FeedbackResult = JsonConvert.DeserializeObject<Body1001FeedbackResult>(message["msg"]["body"].ToString());
        //        return body1001FeedbackResult;
        //    }
        //    catch (Exception ce)
        //    {
        //        throw new CustomException("", "数据转换失败:" + ce.Message + "    服务器返回信息：" + myJson, "");
        //    }
        //}




        public static object JsonToC006ContentAck(string test)
        {
            try
            {
                C006ContentAck httpResponseMsg = new C006ContentAck();
                httpResponseMsg = JsonConvert.DeserializeObject<C006ContentAck>(test);

                return httpResponseMsg;
            }
            catch (Exception)
            {
                throw;
            }
            //return JsonConvert.DeserializeObject(myJson);
        }








        public static object JsonToHttpResponseMsg<T>(string httpResponse)
        {
            try
            {
                HttpResponseMsg<T> httpResponseMsg = new HttpResponseMsg<T>();
                //JObject message = JObject.Parse(httpResponse);
                httpResponseMsg = JsonConvert.DeserializeObject<HttpResponseMsg<T>>(httpResponse);

                return httpResponseMsg;
            }
            catch (Exception)
            {
                throw;
            }
            //return JsonConvert.DeserializeObject(myJson);
        }

        public static HttpResponseMsg<BodyLoginResponse> JsonToMessageResponseLogin(string loginResponse)
        {
            try
            {
                HttpResponseMsg<BodyLoginResponse> messageResponseLogin = new HttpResponseMsg<BodyLoginResponse>();
                JObject message = JObject.Parse(loginResponse);
                //string strTemp = message["body"].ToString();
                //messageResponseLogin.body = JsonConvert.DeserializeObject<BodyLoginResponse>(strTemp);
                string strTemp = message.ToString();
                messageResponseLogin = JsonConvert.DeserializeObject<HttpResponseMsg<BodyLoginResponse>>(strTemp);

                return messageResponseLogin;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static IList<SingleUpload.GuessFootball> JsonToGuessFootballList<T1>(string response)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<SingleUpload.GuessFootball>>(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static SingleUploadTemp JsonToSingleUploadTemp<T1>(string response)
        {
            try
            {
                return JsonConvert.DeserializeObject<SingleUploadTemp>(response);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}