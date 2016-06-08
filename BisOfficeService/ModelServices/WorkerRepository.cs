using System.Collections.Specialized;
using PublishSolution.Service.Entities;
using PublishSolution.Service.Repositories;

namespace PublishSolution.Service.ModelServices
{
    internal class WorkerRepository : Repository, IWorkerRepository<Worker>
    {
        public WorkerRepository(Setting setting)
            : base(setting)
        {
            ServiceUrl = setting.ServiceUrl + "/worker";
        }

        public Worker[] GetAll()
        {
            var responseData = Get<Worker[]>(ServiceUrl);
            return responseData.data;
        }

        public void Insert(Worker worker)
        {
            var postData = new NameValueCollection
                {
                    {"supervisor_id", worker.supervisor_id.ToString()},
                    {"nfc_code", worker.nfc_code},
                    {"personal_code", worker.personal_code},
                    {"first_name", worker.first_name},
                    {"last_name", worker.last_name},
                    {"price", worker.price.ToString()},
                    {"address", worker.address},
                    {"phone", worker.phone},
                    {"birthday", worker.birthday.ToString("yyyy-MM-dd")}
                };
            var res = Post<Worker>(ServiceUrl, postData);
            var workerDb = res.data;
            worker.id = workerDb.id;
            worker.updated_at = workerDb.updated_at;
            worker.created_at = workerDb.created_at;
        }

        public bool Update(Worker worker)
        {
            var postData = new NameValueCollection
                {
                    {"id", worker.id.ToString()},
                    {"supervisor_id", worker.supervisor_id.ToString()},
                    //{"nfc_code", worker.nfc_code},
                    {"personal_code", worker.personal_code},
                    {"first_name", worker.first_name},
                    {"last_name", worker.last_name},
                    {"price", worker.price.ToString()},
                    {"address", worker.address},
                    {"phone", worker.phone},
                    {"birthday", worker.birthday.ToString("yyyy-MM-dd")}
                };
            var res = Put<Worker>(ServiceUrl, postData);

            if (res.data == null)
                return false;

            var workerDb = res.data;
            worker.updated_at = workerDb.updated_at;
            worker.created_at = workerDb.created_at;
            return true;
        }

        public bool Delete(int id)
        {
            var postData = new NameValueCollection
                {
                    {"id", id.ToString()}
                };
            var res = Delete<bool>(ServiceUrl, postData);
            return res.data;
        }
    }
}
