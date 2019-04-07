using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerLoto.Domain
{
    public class GameOfday
    {
        public DateTime Date { get; set; }
        public List<int> ArrayPic3 { get; set; }
        public DrawType DrawType { get; set; }
    }
}
