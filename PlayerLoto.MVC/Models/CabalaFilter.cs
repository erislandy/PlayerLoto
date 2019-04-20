using PlayerLoto.Domain;
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
            Cabala_Words = new List<Cabala_Word>();
        }
        [Display(Name ="Resultado")]
        public string Result { get; set; }
        [Display(Name = "Numero o palabra")]
        public string Word { get; set; }

        public Cabala_Number CabalaNumber { get; set; }
        public List<Cabala_Word> Cabala_Words { get; set; }

    }
}