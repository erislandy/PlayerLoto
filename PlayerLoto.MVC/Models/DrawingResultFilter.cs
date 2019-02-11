using PlayerLoto.Data;
using PlayerLoto.Domain;
using PlayerLoto.Services.FilterOperation;
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
            Parameter = null;
        }

        [Display(Name = "Tiro")]
        public DrawingState DrawingState { get; set; }

        [Display(Name = "Fecha Inicial")]
        [DataType(DataType.Date)]
        public DateTime InitialDate { get; set; }

        [Display(Name = "Fecha Final")]
        [DataType(DataType.Date)]
        public DateTime FinalDate { get; set; }

        [Display(Name = "Parámetro")]
        public int? Parameter { get; set; }

        [Display(Name = "Tipo de parámetro")]
        public ParameterType ParameterType { get; set; }


        public List<DrawingResult> DrawingResults { get; set; }

       
    }
    
    
}