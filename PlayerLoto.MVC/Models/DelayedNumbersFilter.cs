using PlayerLoto.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlayerLoto.MVC.Models
{
    public class DelayedNumbersFilter
    {
        public DelayedNumbersFilter()
        {
            Date = DateTime.Now;
            DrawType = DrawType.Midday;
            MoreDays = 0;
            LessDays = 100;
            
        }
        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "the field {0} is required")]
        public DateTime Date { get; set; }

        [Display(Name = "Tiro")]
        public DrawType DrawType { get; set; }

        [Display(Name = "Mas de:")]
        public int MoreDays { get; set; }

        [Display(Name = "Menos de:")]
        public int LessDays { get; set; }

        public List<Delay> DelayList { get; set; }


    }
}