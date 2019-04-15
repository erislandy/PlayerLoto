using PlayerLoto.Services.FilterOperation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLocalService.Filters
{
    public class DrawingResultLocalFilterByType : DrawingResultFilterByType
    {
        public DrawingResultLocalFilterByType(
            IDrawingResultFilter drawing,
            DrawingState state) : base(drawing, state)
        {
     
        }
    }
}
