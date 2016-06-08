using System;
using System.Collections.Specialized;
using System.Net;
using PublishSolution.Service.Entities;
using PublishSolution.Service.ModelServices;
using PublishSolution.Service.Repositories;

namespace PublishSolution.Service
{
    public class BisService
    {
        private readonly Setting _setting;

        public BisService(string serviceUrl)
        {
            _setting = new Setting(serviceUrl.TrimEnd(new[] { '/' }));
        }

        #region Service call utils

        private ResponseData<T> PostNoneAuthen<T>(string url, NameValueCollection postData)
        {
            byte[] responsebytes;
            using (var client = new BisWebClient())
            {
                responsebytes = client.UploadValues(url, Constant.Method.POST, postData);
            }
            return Util.ConvertTo<ResponseData<T>>(responsebytes);
        }

        #endregion

        #region Model service instance/method

        public bool Login(string key)
        {
            var url = _setting.ServiceUrl + "/login";
            var postData = new NameValueCollection { { "key", key } };
            var responseData = PostNoneAuthen<Login>(url, postData);
            if (responseData.IsOkay())
            {
                _setting.Login = responseData.data;
                return true;
            }
            return false;
        }

        public IWorkerRepository<Worker> Workers
        {
            get { return new WorkerRepository(_setting); }
        }

        public IMachineRepository<Machine> Machines
        {
            get
            {
                return new MachineRepository(_setting);
            }
        }

        #endregion

        #region Response data

        internal class ResponseData<T>
        {
            public int limit { get; set; }

            public int offset { get; set; }

            public string version { get; set; }

            public string status { get; set; }

            public T data { get; set; }

            public ErrorInfo error { get; set; }
        }

        public class ErrorInfo
        {
            public FieldInfo[] fields { get; set; }

            public string message { get; set; }

            public class FieldInfo
            {
                public string field { get; set; }

                public string message { get; set; }
            }
        }

        #endregion
    }

    internal class Setting
    {
        public Setting(string serviceUrl)
        {
            ServiceUrl = serviceUrl;
        }

        internal Login Login { get; set; }

        public string ServiceUrl { get; private set; }
    }
}
