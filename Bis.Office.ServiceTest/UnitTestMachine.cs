using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublishSolution.Service;
using PublishSolution.Service.Entities;

namespace Bis.Office.ServiceTest
{
    [TestClass]
    public class UnitTestMachine
    {
        [TestMethod]
        public void TestMethod1()
        {
            var service = new BisService("http://api2.bisoffice.kloon.net/web/");
            service.Login("rRZs9cMSPXputzMF6QF2zeWP");
            var test = service.Machines.GetAll();

        }

        [TestMethod]
        public void TestMethodInsert()
        {
            var service = new BisService("http://api2.bisoffice.kloon.net/web/");
            service.Login("rRZs9cMSPXputzMF6QF2zeWP");
            var machine = new Machine
            {
                nfc_code = "ab3d4bba615e742684c46b4701fdd5b8",
                machine_code = "M01",
                name = "Machine 1",
                description = "Machine 1 description"
            };

            service.Machines.Insert(machine);

        }

        [TestMethod]
        public void TestMethodUpdate()
        {
            var service = new BisService("http://api2.bisoffice.kloon.net/web/");
            service.Login("rRZs9cMSPXputzMF6QF2zeWP");
            var machine = new Machine
            {
                id=24,
                nfc_code = "ab3d4bba615e742684c46b4701fdd5b8",
                machine_code = "M01",
                name = "nam-name",
                description = "nam-description"
            };

            var test = service.Machines.Update(machine);

        }

        [TestMethod]
        public void TestMethodDelete()
        {
            var service = new BisService("http://api2.bisoffice.kloon.net/web/");
            service.Login("rRZs9cMSPXputzMF6QF2zeWP___");
            var test = service.Machines.Delete(35);

        }
    }
}
