using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayerLoto.Data;
using PlayerLoto.Domain;

namespace PlayerLoto.Services.FilterOperation
{
    public class DrawingResultFilterByType : IDrawingResultFilter
    {
        IDrawingResultFilter _drawing;
        DrawingState _state;
        
        public DrawingResultFilterByType(IDrawingResultFilter drawing, DrawingState state)
        {
            _drawing = drawing;
            _state = state;
            
        }

     
        public List<DrawingResult> Filter()
        {
            var list = _drawing.Filter();
        
            switch (_state)
            {
                case DrawingState.Midday:
                    {
                        list.RemoveAll(d => d.Type != DrawType.Midday);
                        break;
                    }
                case DrawingState.Evening:
                    {
                        list.RemoveAll(d => d.Type != DrawType.Evening);
                        break;
                    }
            }
            return list;

        }

    }
}
