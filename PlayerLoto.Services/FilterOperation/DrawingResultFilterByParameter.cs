using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayerLoto.Domain;

namespace PlayerLoto.Services.FilterOperation
{
    public class DrawingResultFilterByParameter : IDrawingResultFilter
    {
        IDrawingResultFilter _drawing;
        int? _parameter;
        public DrawingResultFilterByParameter(IDrawingResultFilter drawing, int? parameter)
        {
            _parameter = parameter;
            _drawing = drawing;

        }
        public List<DrawingResult> Filter()
        {
            var list = _drawing.Filter();
            if(_parameter != null)
            {
                list.RemoveAll(d => d.Pick3 != _parameter);

            }
            return list;
        }
  
    }
}
