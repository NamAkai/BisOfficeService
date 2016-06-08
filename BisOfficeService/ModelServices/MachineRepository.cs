using System.Collections.Specialized;
using PublishSolution.Service.Entities;
using PublishSolution.Service.Repositories;

namespace PublishSolution.Service.ModelServices
{
    internal class MachineRepository : Repository, IMachineRepository<Machine>
    {
        public MachineRepository(Setting setting)
            : base(setting)
        {
            ServiceUrl = setting.ServiceUrl + "/machine";
        }

        public Machine[] GetAll()
        {
            var res = Get<Machine[]>(ServiceUrl);
            return res.data;
        }

        public void Insert(Machine machine)
        {
            var postData = new NameValueCollection
                {
                    {"nfc_code", machine.nfc_code},
                    {"machine_code", machine.machine_code},
                    {"name", machine.name},
                    {"description", machine.description}
                };
            var res = Post<Machine>(ServiceUrl, postData);

            var machineDb = res.data;
            machine.id = machineDb.id;
            machine.updated_at = machineDb.updated_at;
            machine.created_at = machineDb.created_at;
        }

        public bool Update(Machine machine)
        {
            var postData = new NameValueCollection
                {
                    //{"nfc_code", machine.nfc_code},
                    {"machine_code", machine.machine_code},
                    {"name", machine.name},
                    {"description", machine.description},
                    {"id", machine.id.ToString()}
                };
            var res = Put<Machine>(ServiceUrl, postData);
            if (res.data == null)
                return false;
            var machineDb = res.data;
            machine.updated_at = machineDb.updated_at;
            machine.created_at = machineDb.created_at;
            return true;
        }

        public bool Delete(int id)
        {
            var postData = new NameValueCollection
                {
                    {"id", id.ToString()}
                };

            var responseData = Delete<bool>(ServiceUrl, postData);
            return responseData.data;
        }
    }
}
