using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerLoto.Domain.Interfaces
{
    public interface IDrawingResultManager
    {
        DrawingResult GetDrawingByDate(DateTime date, DrawType drawingType);
      
        List<DrawingResult> Pick3ListFijo(DateTime initialDate, DateTime endDate, DrawType type);
    }
}