using PlayerLoto.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerLoto.Services
{
    public class WeekResult
    {
        [Display(Name = "Domingo")]
        public int? Sunday { get; set; }

        [Display(Name = "Lunes")]
        public int? Monday { get; set; }

        [Display(Name = "Martes")]
        public int? Tuesday { get; set; }

        [Display(Name = "Miércoles")]
        public int? Wednesday { get; set; }

        [Display(Name = "Jueves")]
        public int? Thursday { get; set; }

        [Display(Name = "Viernes")]
        public int? Friday { get; set; }

        [Display(Name = "Sábado")]
        public int? Saturday { get; set; }

        [Display(Name = "Fecha del domingo")]
        public DateTime DateOfSunday { get; set; }
        [Display(Name="Tipo")]
        public DrawType DrawType { get; set; }

        

    }
}
