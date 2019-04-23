using System.Collections.Generic;

namespace DataBaseLocalService.Helpers
{
    public interface IDataAccess
    {
        void Delete<T>(T model);
        void Dispose();
        T Find<T>(int pk, bool WithChildren) where T : class;
        T First<T>(bool WithChildren) where T : class;
        List<T> GetList<T>(bool WithChildren) where T : class;
        void Insert<T>(T model);
        void Update<T>(T model);
    }
}