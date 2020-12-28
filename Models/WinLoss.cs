using System;

namespace pmashbotCS.Models
{
    public class WinLoss
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public bool DidWin { get; set; }
        public DateTime Date { get; set; }
        public string Game { get; set; }
    }
}
