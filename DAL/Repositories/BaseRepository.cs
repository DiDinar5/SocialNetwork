using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace SocialNetwork.DAL.Repositories
{
    public class BaseRepository
    {
        protected T QueryFirstOrDefault<T>(string sql, object parameters = null)//Сначала запрос или по умолчанию
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                return connection.QueryFirstOrDefault<T>(sql, parameters);
            }
        }

        protected List<T> Query<T>(string sql, object parameters = null)//запрос
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                return connection.Query<T>(sql, parameters).ToList();
            }
        }

        protected int Execute(string sql, object parameters = null)//выполнять
        {
            using var connection = CreateConnection();
            connection.Open();
            var res = connection.Execute(sql, parameters);
            
            return res;
        }

        private IDbConnection CreateConnection()
        {
            return new SQLiteConnection("Data Source = DAL/DB/social_network.db; Version = 3");
        }
    }
}