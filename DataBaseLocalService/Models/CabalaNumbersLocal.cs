using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLocalService.Models
{
    public class CabalaNumbersLocal 
    {
        [PrimaryKey, AutoIncrement]
        public int CabalaNumbersLocalId { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }

    }
}
