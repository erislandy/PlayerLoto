using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlayerLoto.MVC.Models
{
    public class SimulationFilter
    {
        public SimulationFilter()
        {
            MatchGameList = new List<MatchGame>();
        }

        [Display(Name = "Opcion de Juego")]
        public GameOption GameOption { get; set; }
        public List<MatchGame>  MatchGameList { get; set; }

        [Display(Name = "Fecha Inicial")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "the field {0} is required")]
        public DateTime InitialDate { get; set; }

        [Display(Name = "Fecha Final")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "the field {0} is required")]
        public DateTime FinalDate { get; set; }

        public int AllMatch
        {
            get
            {
               return MatchGameList.Where(g => g.Matched == true)
                             .Count();
            }
        }

    }

    public enum GameOption
    {
        Ultimos50NumerosDemorados, Primeros50NumerosDemorados, Conmutar50NumerosDemorados
    }
}