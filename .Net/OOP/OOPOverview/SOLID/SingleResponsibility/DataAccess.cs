using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibility
{
    public class DataAccess
    {
        // daha sonra veritabani degisebilir
        SqlConnection sqlConnection = null;

        // baglanti saglayabilmek icin bir connection string'i lazim
        // onu da constructor'dan alsin

        public DataAccess(string connectionString)
        {
            sqlConnection= new SqlConnection(connectionString);
        }

        // ExecuteNonQuery'in calismasi icin : bir commandText, sonra parametre
        // parametreler once string aliyor sonra da object aldigindan Generic ile bunu cozeriz 
        public int ExecuteNonQuery(string commandText, Dictionary<string, object> parameters)
        {
            SqlCommand sqlCommand = createCommand(commandText, parameters); // createCommand'i kendimiz yaratiyoruz
            sqlCommand.Connection.Open();
            int rowsAffected = sqlCommand.ExecuteNonQuery();
            sqlCommand.Connection.Close();
            return rowsAffected;
        }

        private SqlCommand createCommand(string commandText, Dictionary<string, object> parameters)
        {
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = commandText; // normalde verilen parametreleri command'e eklememiz lazim 
            // ama o is bizim isimiz degil
            // onu soyle cozucez
            addParametersToCommand(sqlCommand, parameters); // bu metodu da Generate method diyoruz
            return sqlCommand;
        }

        private void addParametersToCommand(SqlCommand sqlCommand, Dictionary<string, object> parameters)
        {
            foreach(var parameter in parameters)
            {
                parameters.Add(parameter.Key, parameter.Value);
            }
        }

        // one job at a time
        // birim zamanda bir is
    }
}
