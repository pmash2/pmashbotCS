using System;
using Microsoft.EntityFrameworkCore;

namespace pmashbotCS.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
