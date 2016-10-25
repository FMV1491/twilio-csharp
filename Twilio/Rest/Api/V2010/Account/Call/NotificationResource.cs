using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Call {

    public class NotificationResource : Resource {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="callSid"> The call_sid </param>
        /// <param name="sid"> The sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> NotificationFetcher capable of executing the fetch </returns> 
        public static NotificationFetcher Fetcher(string callSid, string sid, string accountSid=null) {
            return new NotificationFetcher(callSid, sid, accountSid:accountSid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="callSid"> The call_sid </param>
        /// <param name="sid"> The sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> NotificationDeleter capable of executing the delete </returns> 
        public static NotificationDeleter Deleter(string callSid, string sid, string accountSid=null) {
            return new NotificationDeleter(callSid, sid, accountSid:accountSid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="callSid"> The call_sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="log"> The log </param>
        /// <param name="messageDate"> The message_date </param>
        /// <returns> NotificationReader capable of executing the read </returns> 
        public static NotificationReader Reader(string callSid, string accountSid=null, int? log=null, string messageDate=null) {
            return new NotificationReader(callSid, accountSid:accountSid, log:log, messageDate:messageDate);
        }
    
        /// <summary>
        /// Converts a JSON string into a NotificationResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> NotificationResource object represented by the provided JSON </returns> 
        public static NotificationResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<NotificationResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string accountSid { get; }
        [JsonProperty("api_version")]
        public string apiVersion { get; }
        [JsonProperty("call_sid")]
        public string callSid { get; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; }
        [JsonProperty("error_code")]
        public string errorCode { get; }
        [JsonProperty("log")]
        public string log { get; }
        [JsonProperty("message_date")]
        public DateTime? messageDate { get; }
        [JsonProperty("message_text")]
        public string messageText { get; }
        [JsonProperty("more_info")]
        public Uri moreInfo { get; }
        [JsonProperty("request_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod requestMethod { get; }
        [JsonProperty("request_url")]
        public Uri requestUrl { get; }
        [JsonProperty("request_variables")]
        public string requestVariables { get; }
        [JsonProperty("response_body")]
        public string responseBody { get; }
        [JsonProperty("response_headers")]
        public string responseHeaders { get; }
        [JsonProperty("sid")]
        public string sid { get; }
        [JsonProperty("uri")]
        public string uri { get; }
    
        public NotificationResource() {
        
        }
    
        private NotificationResource([JsonProperty("account_sid")]
                                     string accountSid, 
                                     [JsonProperty("api_version")]
                                     string apiVersion, 
                                     [JsonProperty("call_sid")]
                                     string callSid, 
                                     [JsonProperty("date_created")]
                                     string dateCreated, 
                                     [JsonProperty("date_updated")]
                                     string dateUpdated, 
                                     [JsonProperty("error_code")]
                                     string errorCode, 
                                     [JsonProperty("log")]
                                     string log, 
                                     [JsonProperty("message_date")]
                                     string messageDate, 
                                     [JsonProperty("message_text")]
                                     string messageText, 
                                     [JsonProperty("more_info")]
                                     Uri moreInfo, 
                                     [JsonProperty("request_method")]
                                     Twilio.Http.HttpMethod requestMethod, 
                                     [JsonProperty("request_url")]
                                     Uri requestUrl, 
                                     [JsonProperty("request_variables")]
                                     string requestVariables, 
                                     [JsonProperty("response_body")]
                                     string responseBody, 
                                     [JsonProperty("response_headers")]
                                     string responseHeaders, 
                                     [JsonProperty("sid")]
                                     string sid, 
                                     [JsonProperty("uri")]
                                     string uri) {
            this.accountSid = accountSid;
            this.apiVersion = apiVersion;
            this.callSid = callSid;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.errorCode = errorCode;
            this.log = log;
            this.messageDate = MarshalConverter.DateTimeFromString(messageDate);
            this.messageText = messageText;
            this.moreInfo = moreInfo;
            this.requestMethod = requestMethod;
            this.requestUrl = requestUrl;
            this.requestVariables = requestVariables;
            this.responseBody = responseBody;
            this.responseHeaders = responseHeaders;
            this.sid = sid;
            this.uri = uri;
        }
    }
}