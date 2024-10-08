﻿using System.ComponentModel.DataAnnotations;

namespace DmlStarterkit.Domain.Entities
{
    public class LogEntity
    {
        [Key]
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string ip { get; set; }
        public DateTime logdate { get; set; }
        public string controller { get; set; }
        public string parameters { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public string type { get; set; }
    }
}
