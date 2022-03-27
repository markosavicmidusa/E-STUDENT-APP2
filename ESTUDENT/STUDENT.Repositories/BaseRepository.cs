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
    }
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
    {

        private IConfiguration configuration;
        public string connectionString;

        public BaseRepository(IConfiguration configuration)
        {
            // adding dapper crud beacuse the project is instanced with one type of mysql querries
            // local

            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);

            this.configuration = configuration;
            this.connectionString = configuration.GetConnectionString("DefaultConnection");
        }


        /// <summary>
        /// Reading all from any table
        /// </summary>
        /// <returns></returns>
        public List <TEntity> ReadAll()
        {

            var connection = new MySqlConnection(connectionString);
            List <TEntity>? results = connection.GetList<TEntity>().ToList();
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
            throw new NotImplementedException();
        }
    }
}
