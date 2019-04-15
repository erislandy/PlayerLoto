using PlayerLoto.Services.FilterOperation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLocalService.Filters
{
    public class DrawingResultLocalFilterByParameter : DrawingResultFilterByParameter
    {
        public DrawingResultLocalFilterByParameter(
                 IDrawingResultFilter drawing, 
                 int? parameter, 
                 ParameterType parameterType) : base(drawing, parameter,parameterType)
        {
            
        }
    }
}
