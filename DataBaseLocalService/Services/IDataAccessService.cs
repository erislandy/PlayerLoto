using System;
using System.Collections.Generic;
using PlayerLoto.Domain;

namespace DataBaseLocalService.Services
{
    public interface IDataAccessService
    {
        List<DrawingResult> GetDrawingResultHistory(DateTime initialDate, DateTime finaldate);
        List<int> GetNumberList();
        Cabala_Number FindByNumber(int number);
        List<Cabala_Word> FindByWord(string word);
    }
}