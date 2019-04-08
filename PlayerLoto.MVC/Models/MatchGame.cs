using PlayerLoto.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlayerLoto.MVC.Models
{
    public class MatchGame
    {
        public DrawingResult DrawingResult { get; set; } 
        public GameOfday GameOfday { get; set; }

        [Display(Name = "Coincide?")]
        public bool Matched
        {
            get
            {
                int result;
                var decenaFijo = Math.DivRem(DrawingResult.Pick3, 100, out result);
                return GameOfday.ArrayPic3.Contains(result);
               
            }
            
        }
    }
}