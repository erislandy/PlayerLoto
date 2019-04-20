using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlayerLoto.MVC.Models
{
    public class CabalaFilter
    {
        public CabalaFilter()
        {
            Result = "";
           
        }
        [Display(Name ="Resultado")]
        public string Result { get; set; }
        [Display(Name = "Numero o palabra")]
        public string Word { get; set; }


    }
}