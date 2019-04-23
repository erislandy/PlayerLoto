using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLocalService.Helpers
{
    using Interfaces;
    using Models;
    using Prism.Services;
    using SQLite.Net;
    using SQLiteNetExtensions.Extensions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    
    public class DataAccess : IDisposable, IDataAccess
    {
        private SQLiteConnection connection;
        private IConfig _config;
        public DataAccess(IDependencyService dependencyService)
        {
            _config = dependencyService.Get<IConfig>();
             this.connection = new SQLiteConnection(
                _config.Platform,
                Path.Combine(_config.DirectoryDB, "PL.db3"));
            connection.CreateTable<DrawingResultLocal>();
            connection.CreateTable<CabalaNumbersLocal>();
            connection.CreateTable<CabalaWordsLocal>();

        }

        public void Insert<T>(T model)
        {
            this.connection.Insert(model);
        }

        public void Update<T>(T model)
        {
            this.connection.Update(model);
        }

        public void Delete<T>(T model)
        {
            this.connection.Delete(model);
        }

        public T First<T>(bool WithChildren) where T : class
        {
            if (WithChildren)
            {
                return connection.GetAllWithChildren<T>().FirstOrDefault();
            }
            else
            {
                return connection.Table<T>().FirstOrDefault();
            }
        }

        public List<T> GetList<T>(bool WithChildren) where T : class
        {
            if (WithChildren)
            {
                return connection.GetAllWithChildren<T>().ToList();
            }
            else
            {
                return connection.Table<T>().ToList();
            }
        }

        public T Find<T>(int pk, bool WithChildren) where T : class
        {
            if (WithChildren)
            {
                return connection.GetAllWithChildren<T>().FirstOrDefault(m => m.GetHashCode() == pk);
            }
            else
            {
                return connection.Table<T>().FirstOrDefault(m => m.GetHashCode() == pk);
            }
        }

        public void Dispose()
        {
            connection.Dispose();
        }
    }

}
