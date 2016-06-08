using System;

namespace PublishSolution.Service.Entities
{
    public class Login
    {
        public string token { get; set; }
        public string city { get; set; }
    }

    public class Worker
    {
        public int id { get; set; }
        public int supervisor_id { get; set; }
        public string nfc_code { get; set; }
        public string personal_code { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public decimal price { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public DateTime birthday { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime created_at { get; set; }
    }

    public class Machine
    {
        public int id { get; set; }
        public string nfc_code { get; set; }
        public string machine_code { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime birthday { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime created_at { get; set; }
    }
}
