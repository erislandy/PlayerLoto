using PlayerLoto.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerLoto.Services.FilterOperation
{
    public interface IDrawingResultFilter
    {
 
        List<DrawingResult> Filter();
    }
}
