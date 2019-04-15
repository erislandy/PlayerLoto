using PlayerLoto.Domain;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLocalService.Models
{
    public class DrawingResultLocal : DrawingResult
    {
        [PrimaryKey, AutoIncrement]
        public int DrawingResultLocalId { get; set; }

        public override int GetHashCode()
        {
            return DrawingResultLocalId;
        }
    }
}
