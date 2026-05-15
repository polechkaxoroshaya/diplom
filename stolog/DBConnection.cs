using System;
using System.Configuration;
using Npgsql;

namespace EVS
{
    public class DBConnection
    {
        private static DBConnection _instance;
        private static readonly object _lock = new object();
        private NpgsqlConnection _connection;
        private string _connectionString;

        private DBConnection()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["LogisticsDB"]?.ConnectionString;

            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new Exception("Строка подключения не найдена в конфигурационном файле!");
            }
        }

        public static DBConnection Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new DBConnection();
                        }
                    }
                }
                return _instance;
            }
        }

        public NpgsqlConnection GetConnection()
        {
            if (_connection == null || _connection.State != System.Data.ConnectionState.Open)
            {
                _connection = new NpgsqlConnection(_connectionString);
                _connection.Open();
            }
            return _connection;
        }

        public void CloseConnection()
        {
            if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
                _connection.Dispose();
                _connection = null;
            }
        }

        public bool IsConnected
        {
            get { return _connection != null && _connection.State == System.Data.ConnectionState.Open; }
        }

        public int ExecuteNonQuery(string sql, NpgsqlParameter[] parameters = null)
        {
            using (var conn = GetConnection())
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                return cmd.ExecuteNonQuery();
            }
        }

        public object ExecuteScalar(string sql, NpgsqlParameter[] parameters = null)
        {
            using (var conn = GetConnection())
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                return cmd.ExecuteScalar();
            }
        }

       public NpgsqlDataReader ExecuteReader(string sql, NpgsqlParameter[] parameters = null)
        {
            var conn = GetConnection();
            var cmd = new NpgsqlCommand(sql, conn);

            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }

            return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        }

        public NpgsqlTransaction BeginTransaction()
        {
            return GetConnection().BeginTransaction();
        }
    }
}