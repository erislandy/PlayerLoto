using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayerLoto.Data;
using PlayerLoto.Domain;

namespace PlayerLoto.Services.FilterOperation
{
    public class DrawingResultFilterByDate : IDrawingResultFilter
    {
        IRepository _repository;
        DateTime _initialDate;
        DateTime _finalDate;
        
        public DrawingResultFilterByDate(IRepository repository, DateTime initial, DateTime final)
        {
            _initialDate = initial;
            _finalDate = final;
            _repository = repository;
            

        }

        public List<DrawingResult> Filter()
        {
            return _repository.GetList<DrawingResult>(
                                                    d => d.Date >= _initialDate &&
                                                    d.Date <= _finalDate)
                                                    .ToList();
        }
  
    }
}
