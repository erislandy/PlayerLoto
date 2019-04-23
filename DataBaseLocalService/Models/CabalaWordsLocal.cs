using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLocalService.Models
{
    public class CabalaWordsLocal
    {
        [PrimaryKey, AutoIncrement]
        public int CabalaWordsLocalId { get; set; }
        public string Word { get; set; }
        public string Numbers { get; set; }
    }
}
