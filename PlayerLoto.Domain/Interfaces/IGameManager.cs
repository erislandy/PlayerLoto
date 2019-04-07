using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerLoto.Domain.Interfaces
{
    public interface IGameManager
    {
        IList<int> GetNumbers();
        void PlayGame(DateTime date, DrawType drawType);
    }
}
