using System;
using System.Collections.Generic;
using System.Text;

namespace CabalaModule.Models
{
    public class CabalaLocalFilter
    {
        public CabalaLocalFilter()
        {
            Word = string.Empty;
            Result = string.Empty;
        }
        public string Word { get; set; }
        public string Result { get; set; }
    }
}
