﻿using System;
using System.Data.Entity;

using PlayerLoto.Data;

namespace PlayerLoto.DataEF
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContextTransaction tx;
        public object Orm { get; private set; }

        
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="orm">The orm.</param>
        public UnitOfWork(DbContext orm)
        {
            Orm = orm;
            
        }

        #region IUnitOfWork Members

        


        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        public void Add<T>(T entity) where T : class
        {
            try
            {
                (Orm as DbContext ).Set<T>().Add(entity);
                (Orm as DbContext).SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("An error occured during the Add Entity.\r\n{0}", ex.Message));
            }
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        public void Update<T>(T entity) where T : class
        {
            try
            {
                (Orm as DbContext).Set<T>().Attach(entity);
                (Orm as DbContext).SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("An error occured during the Update Entity.\r\n{0}", ex.Message));
            }
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        public void Delete<T>(T entity) where T : class
        {
            try
            {
                ((DbContext)Orm).Set<T>().Remove(entity);
                (Orm as DbContext).SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("An error occured during the Delete Entity.\r\n{0}", ex.Message));
            }
        }

        /// <summary>
        /// Begins the transaction.
        /// </summary>
        public void BeginTransaction()
        {
            try
            {
                tx = (Orm as DbContext).Database.BeginTransaction() ;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("An error occured during the Begin transaction.\r\n{0}", ex.Message));
            }
        }

        /// <summary>
        /// Commits the transaction.
        /// </summary>
        public void CommitTransaction()
        {
            try
            {
                if (tx == null)
                {
                    throw new Exception("The current transaction is not started!");
                }
                (Orm as DbContext).SaveChanges();
                tx.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("An error occured during the Commit transaction.\r\n{0}", ex.Message));
            }
            finally
            {
                tx.Dispose();
            }
        }

        /// <summary>
        /// Rollbacks the transaction.
        /// </summary>
        public void RollbackTransaction()
        {
            try
            {
                if (tx != null)
                {
                    tx.Rollback();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("An error occured during the Rollback transaction.\r\n{0}", ex.Message));
            }
        }

        #endregion

       
    }

}
