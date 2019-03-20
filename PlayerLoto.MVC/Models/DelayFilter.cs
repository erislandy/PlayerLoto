using PlayerLoto.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlayerLoto.MVC.Models
{
    public class DelayFilter
    {
        public DelayFilter()
        {
            DelayList = new List<Delay>();
            DrawType = DrawType.Midday;
            InitialDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            FinalDate = DateTime.Now;
        }
        public List<Delay> DelayList { get; set; }

        [Display(Name = "Tiro")]
        public DrawType DrawType { get; set; }

        [Display(Name = "Fecha Inicial")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "the field {0} is required")]
        public DateTime InitialDate { get; set; }

        [Display(Name = "Fecha Final")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "the field {0} is required")]
        public DateTime FinalDate { get; set; }
    }
}