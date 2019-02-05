using PlayerLoto.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlayerLoto.MVC.Models
{
    public class DrawingResultFilter
    {
        public DrawingResultFilter()
        {
            DrawingResults = new List<DrawingResult>();
            DrawingState = DrawingState.All;
            InitialDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            FinalDate = DateTime.Now;
            Pick3Hundred = null;
        }

        [Display(Name = "Tiro")]
        public DrawingState DrawingState { get; set; }

        [Display(Name = "Fecha Inicial")]
        [DataType(DataType.Date)]
        public DateTime InitialDate { get; set; }

        [Display(Name = "Fecha Final")]
        [DataType(DataType.Date)]
        public DateTime FinalDate { get; set; }

        [Display(Name = "Fijo centena")]
        public int Pick3Hundred { get; set; }

        [Display(Name = "Fijo dentena")]
        public int? Pick3Tens { get; set; }

        [Display(Name = "Corrido")]
        public int? Pick4 { get; set; }

        public List<DrawingResult> DrawingResults { get; set; }

    }

    public enum DrawingState
    {
        Midday, Evening, All
    }
}