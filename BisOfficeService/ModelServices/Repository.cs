using System.Collections.Specialized;
using System.Net;
using PublishSolution.Service.Entities;

namespace PublishSolution.Service.ModelServices
{
    internal class Repository
    {
        protected Login Login { get; private set; }

        protected string ServiceUrl { get; set; }

        protected Repository(Setting setting)
        {
            Login = setting.Login;
            ServiceUrl = setting.ServiceUrl;
        }

        protected BisService.ResponseData<T> Get<T>(string url)
        {
            string html;
            using (var client = new BisWebClient())
            {
                client.AddHeader(Login);
                html = client.DownloadString(url);
            }

            return Util.ConvertTo<BisService.ResponseData<T>>(html);
        }

        protected BisService.ResponseData<T> Post<T>(string url, NameValueCollection postData, bool throwError = true)
        {
            byte[] responsebytes;
            using (var client = new BisWebClient())
            {
                client.AddHeader(Login);
                responsebytes = client.UploadValues(url, Constant.Method.POST, postData);
            }
            var res = Util.ConvertTo<BisService.ResponseData<T>>(responsebytes);
            if (throwError && !res.IsOkay())
                throw new ServiceException(res.error);
            return res;
        }

        protected BisService.ResponseData<T> Put<T>(string url, NameValueCollection postData, bool throwError = true)
        {
            byte[] responsebytes;
            using (var client = new BisWebClient())
            {
                client.AddHeader(Login);
                responsebytes = client.UploadValues(url, Constant.Method.PUT, postData);
            }
            var res = Util.ConvertTo<BisService.ResponseData<T>>(responsebytes);
            if (throwError && !res.IsOkay())
                throw new ServiceException(res.error);
            return res;
        }

        protected BisService.ResponseData<T> Delete<T>(string url, NameValueCollection postData, bool throwError = true)
        {
            byte[] responsebytes;
            using (var client = new BisWebClient())
            {
                client.AddHeader(Login);
                responsebytes = client.UploadValues(url, Constant.Method.DELETE, postData);
            }
            var res = Util.ConvertTo<BisService.ResponseData<T>>(responsebytes);
            if (throwError && !res.IsOkay())
                throw new ServiceException(res.error);
            return res;
        }
    }
}
