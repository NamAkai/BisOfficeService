using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using PublishSolution.Service.Entities;

namespace PublishSolution.Service
{
    internal static class Util
    {
        public static T ConvertTo<T>(byte[] responseBytes)
        {
            var responseBody = Encoding.UTF8.GetString(responseBytes);
            var res = ConvertTo<T>(responseBody);
            return res;
        }

        public static T ConvertTo<T>(string responseString)
        {
            var res = JsonConvert.DeserializeObject<T>(responseString);
            return res;
        }
    }

    internal class Constant
    {
        public const string AUTHORIZATION_REQUIRED = "Authorization is required.";

        internal class Method
        {
            public const string GET = "GET";
            public const string POST = "POST";
            public const string PUT = "PUT";
            public const string DELETE = "DELETE";
        }
    }

    internal static class Extension
    {
        internal static void AddHeader(this WebClient client, Login login)
        {
            if (login != null)
                client.Headers["Authorization"] = login.token;
            else
                throw new ServiceException(Constant.AUTHORIZATION_REQUIRED);
        }

        internal static bool IsOkay<T>(this BisService.ResponseData<T> responseData)
        {
            return responseData != null && responseData.status.Equals("ok", StringComparison.OrdinalIgnoreCase);
        }
    }

    public class ServiceException : Exception
    {
        public BisService.ErrorInfo ErrorInfo { get; private set; }

        public ServiceException(BisService.ErrorInfo errorInfo)
            : this(errorInfo.message)
        {
            ErrorInfo = errorInfo;
        }

        public ServiceException(string message) : base(message)
        {
        }
    }

    internal class BisWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = (HttpWebRequest)base.GetWebRequest(address);
            request.AllowAutoRedirect = false;
            return request;
        }
    }
}
