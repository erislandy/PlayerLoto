using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerLoto.Domain.Interfaces
{
    public interface IAdvancedOperation
    {
        List<Delay> GetDelays(DateTime initialDate, DateTime finalDate, DrawType type);
        Delay GetAmountDayForPick3Tens(int pick3, DateTime dateTime, DrawType type);

        List<int> GetPath(List<int> listNumber, DateTime initialDate, DateTime finalDate, DrawType type);
    }
}