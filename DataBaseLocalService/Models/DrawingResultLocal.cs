using PlayerLoto.Domain;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLocalService.Models
{
    public class DrawingResultLocal
    {
        [PrimaryKey, AutoIncrement]
        public int DrawingResultLocalId { get; set; }
        public DateTime Date { get; set; }
        public DrawType Type { get; set; }
        public int Pick3 { get; set; }
        public int Pick4First { get; set; }
        public int Pick4Second { get; set; }
    }
}
