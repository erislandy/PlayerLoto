using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerLoto.Domain.Interfaces
{
    public interface ICabalaManager
    {
        Cabala_Number FindByNumber(int number);
        List<Cabala_Word> FindbyWord(string word);
    }
}
