using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublishSolution.Service;
using PublishSolution.Service.Entities;

namespace Bis.Office.ServiceTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                var service = new BisService("http://api2.bisoffice.kloon.net/web/");
                service.Login("rRZs9cMSPXputzMF6QF2zeWP");
                var test = service.Workers.GetAll();
            }
            catch (Exception ex)
            {

                var a = ex.ToString();
                var b = a;
            }

        }

        [TestMethod]
        public void TestMethodInsert()
        {
            var service = new BisService("http://api2.bisoffice.kloon.net/web/");
            service.Login("rRZs9cMSPXputzMF6QF2zeWP");
            var worker = new Worker
            {
                supervisor_id = 2016,
                nfc_code = "defecfa2dfc30a93dda0cab110c66ac6",
                personal_code = "nam-personal_code",
                first_name = "nam-first_name",
                last_name = "nam-last_name",
                price = 20,
                address = "Nam-address",
                phone = "nam-phone",
                birthday = DateTime.Now
            };

            service.Workers.Insert(worker);

        }

        [TestMethod]
        public void TestMethodUpdate()
        {
            try
            {
                var service = new BisService("http://api2.bisoffice.kloon.net/web/");
                service.Login("rRZs9cMSPXputzMF6QF2zeWP");
                var worker = new Worker
                {
                    id = 38,
                    supervisor_id = 2016,
                    nfc_code = "defecfa2dfc30a93dda0cab110c66ac6",
                    personal_code = "nam-personal_code",
                    first_name = "nam-first_name 1",
                    last_name = "nam-last_name 1",
                    price = 20,
                    address = "Nam-address",
                    phone = "nam-phone",
                    birthday = DateTime.Now
                };

                var test = service.Workers.Update(worker);

            }
            catch (Exception ex)
            {
                var a = ex.ToString();
                var b = a;
            }
        }

        [TestMethod]
        public void TestMethodDelete()
        {
            var service = new BisService("http://api2.bisoffice.kloon.net/web/");
            service.Login("rRZs9cMSPXputzMF6QF2zeWP");
            var test = service.Workers.Delete(37);

        }
    }
}
