using System;

namespace CoreMicroservice.Model
{
    public class RegisterFile
    {
        public static readonly string DocumentName = "RegisterFile";
        public Guid Id { get; set; }
        public string Status { get; set; }
        public DateTime RegisterDate { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Courier { get; set; }
        public string DocumentPath { get; set; }
    }
}
