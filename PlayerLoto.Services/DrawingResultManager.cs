using PlayerLoto.Data;
using PlayerLoto.Domain;
using PlayerLoto.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerLoto.Services
{
    public class DrawingResultManager : IDrawingResultManager
    {
        private IRepository _repository;

        public DrawingResultManager(IRepository repository)
        {
            _repository = repository;
        }
       
        public DrawingResult GetDrawingByDate(DateTime date, DrawType drawingType)
        {
            var list = _repository.GetList<DrawingResult>();
            DrawingResult drawing =list.Where(d => d.Date == date && d.Type == drawingType)
                                             .FirstOrDefault();
            return drawing;
        }

        public List<DrawingResult> Pick3ListFijo(DateTime initialDate, DateTime endDate, DrawType type)
        {
            var list = _repository.GetList<DrawingResult>();
            return list.Where(d => d.Date >= initialDate && 
                                   d.Date <= endDate &&
                                   d.Type == type)
                       .ToList();
                       

        }

        public DrawingResult Save(DrawingResult drawingResult)
        {

            var uow = _repository.UoW;
           
            try
            {
                uow.BeginTransaction();
                _repository.AddEntity(drawingResult);
                uow.CommitTransaction();
            }
            catch (Exception)
            {
                uow.RollbackTransaction();
                return null;
            }
            return drawingResult;

        }

        public DrawingResult Update(DrawingResult drawingResult)
        {

            var uow = _repository.UoW;

            try
            {
                uow.BeginTransaction();
                _repository.UpdateEntity(drawingResult);
                uow.CommitTransaction();
            }
            catch (Exception)
            {
                uow.RollbackTransaction();
                return null;
            }
            return drawingResult;

        }

        public void Delete(DrawingResult drawingResult)
        {
            var uow = _repository.UoW;

            try
            {
                uow.BeginTransaction();
                _repository.DeleteEntity(drawingResult);
                uow.CommitTransaction();
            }
            catch (Exception)
            {
                uow.RollbackTransaction();
                
            }
          
        }
    }
}
