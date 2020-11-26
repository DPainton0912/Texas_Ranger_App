using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Texas_Ranger_App.Models
{
    public class Reservations
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Guests { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
