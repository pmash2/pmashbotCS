using System;

namespace pmashbotCS.Models
{
    public class TransactionLog
    {
        public int Id { get; set; }
        public int Points { get; set; }
        public string Receiver { get; set; }
        public string Giver { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
    }
}
