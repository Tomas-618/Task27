using System.Data;
using System.Data.SqlClient;
using Task27.DataLayer.Exceptions;
using Task27.Services.Domain.Models;

namespace Task27.DataLayer
{
    public class DataBaseProvider
    {
        private readonly ConnectionPathModel _connectionPath;

        public DataBaseProvider(ConnectionPathModel connectionPath) =>
            _connectionPath = connectionPath;

        public DataTable FindCitizenData(string hash)
        {
            try
            {
                string commandText = $"select * from passports where num='{hash}' limit 1;";

                using (SqlConnection connection = new SqlConnection(_connectionPath.Value))
                {
                    connection.Open();

                    SqlDataAdapter sqLiteDataAdapter = new SqlDataAdapter(new SqlCommand(commandText, connection));

                    DataTable citizenDataTable = new DataTable();
                    sqLiteDataAdapter.Fill(citizenDataTable);

                    return citizenDataTable;
                }
            }
            catch (SqlException)
            {
                throw new FileNotFoundException(_connectionPath.Path);
            }
        }
    }
}
