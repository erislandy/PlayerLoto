using PlayerLoto.Domain;
using PlayerLoto.Services.FilterOperation;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueryDrawingResultsModule.Models
{
    public class DrawingResultFilter
    {
        public DrawingResultFilter()
        {
            DrawingState = DrawingState.All;
            InitialDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            FinalDate = DateTime.Now;
            Parameter = null;
        }

        public DrawingState DrawingState { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        public int? Parameter { get; set; }
        public ParameterType ParameterType { get; set; }

        public List<string> DrawingStateList
        {
            get
            {
                return new List<string>()
                {
                    DrawingState.All.ToString(),
                    DrawingState.Midday.ToString(),
                    DrawingState.Evening.ToString(),
                };
            }
        }
        public List<string> ParameterTypeList
        {
            get
            {
                return new List<string>()
                {
                    ParameterType.FijoCentena.ToString(),
                    ParameterType.FijoDecena.ToString(),
                    ParameterType.Corrido.ToString(),
                };
            }
        }



    }


}
