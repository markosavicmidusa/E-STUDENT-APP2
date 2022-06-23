using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace ESTUDENT.Repositories
{
    public interface IBaseRepository<TEntity> {

        public List <TEntity> ReadAll();
        public TEntity ReadOne(int id);

        int Create(TEntity obj);
        void Update(TEntity obj);
        void Delete(TEntity obj);
        public List<TEntity> TableSearch(int pageNumber, int rowsPerPage, string conditions, string orderBy);

    }
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
    {

        private IConfiguration configuration;
        public string connectionString;
        protected MySqlConnection connection;

        public BaseRepository(IConfiguration configuration)
        {
            // adding dapper crud beacuse the project is instanced with one type of mysql querries
            // local

            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);

            this.configuration = configuration;
            this.connectionString = configuration.GetConnectionString("DefaultConnection");

            connection = new MySqlConnection(connectionString);
        }
        


        /// <summary>
        /// Reading all from any table
        /// </summary>
        /// <returns></returns>
        public List <TEntity> ReadAll()
        {
           
            //var connection = new MySqlConnection(connectionString);
            List <TEntity> results = connection.GetList<TEntity>().ToList();
            return results;
        }
       
        
        
        /// <summary>
        ///  Read one specific entity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public TEntity ReadOne(int id)
        {
            TEntity result = connection.Get<TEntity>(id);
            return result;
        }

       

        void IBaseRepository<TEntity>.Update(TEntity obj)
        {
            connection.Update<TEntity>(obj);
        }

        void IBaseRepository<TEntity>.Delete(TEntity obj)
        {
            connection.Delete<TEntity>(obj);
        }

        public int Create(TEntity obj)
        {
            var result = connection.Insert<TEntity> (obj);
            return (int) result;
        }

        /// <summary>
        /// table search for pagination
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="rowsPerPage"></param>
        /// <param name="conditions"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public List<TEntity> TableSearch(int pageNumber, int rowsPerPage, string conditions, string orderBy)
        {
            return connection.GetListPaged<TEntity>(pageNumber, rowsPerPage, conditions, orderBy).ToList();
        }
    }
}
