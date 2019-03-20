using PlayerLoto.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlayerLoto.MVC.Models
{
    public class PathNumberFilter
    {
        public PathNumberFilter()
        {
            PathList = new List<int>();
        }
        [Display(Name = "Lista de numeros")]
        public string NumberList { get; set; }

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

        public List<int> PathList { get; set; }
    }
}