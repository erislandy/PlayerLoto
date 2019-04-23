using DataBaseLocalService.Services;
using PlayerLoto.Domain;
using PlayerLoto.Services.FilterOperation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLocalService.Filters
{
    public class DrawingResultLocalFilterByDate : IDrawingResultFilter
    {
        #region Attributes

        DateTime _initialDate;
        DateTime _finalDate;

        #endregion

        #region Services

        IDataAccessService _dataAccessService;

        #endregion

        public DrawingResultLocalFilterByDate(IDataAccessService dataAccessService, DateTime initialDate, DateTime finalDate)
        {
            _initialDate = initialDate;
            _finalDate = finalDate;
            _dataAccessService = dataAccessService;
        }
        public List<DrawingResult> Filter()
        {
            return _dataAccessService.GetDrawingResultHistory(_initialDate, _finalDate);
                                    
        }
    }
}
