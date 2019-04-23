using DataBaseLocalService.Helpers;
using DataBaseLocalService.Services;
using PlayerLoto.Domain;
using PlayerLoto.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CabalaModule.Implementations
{
    public class CabalaLocalManager : ICabalaManager
    {
        #region Services

        IDataAccessService _dataAccessService;

        #endregion

        #region Constructors
        public CabalaLocalManager(IDataAccessService dataAccessService)
        {
            _dataAccessService = dataAccessService;
        }

        #endregion

        #region Methods
        public Cabala_Number FindByNumber(int number)
        {
            return _dataAccessService.FindByNumber(number);
                              
        }

        public List<Cabala_Word> FindbyWord(string word)
        {
            return _dataAccessService.FindByWord(word);
        }

        #endregion
    }
}
