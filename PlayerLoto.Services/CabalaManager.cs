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
    public class CabalaManager : ICabalaManager
    {
        IRepository _repository;
        public CabalaManager(IRepository repository)
        {
            _repository = repository;
        }
        public Cabala_Number FindByNumber(int number)
        {
            return  _repository.GetList<Cabala_Number>(c => c.Number == number)
                                          .FirstOrDefault();
            
        }

        public List<Cabala_Word> FindbyWord(string word)
        {
            return _repository.GetList<Cabala_Word>(c => c.Word.Contains(word))
                                          .ToList();
           
           
        }
    }
}
