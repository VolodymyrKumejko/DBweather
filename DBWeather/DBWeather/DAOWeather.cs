using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace DBWeather
{
    class DAOWeather
    {
        SqlConnection conn;
        public DAOWeather()
        {          
            string connStr = ConfigurationManager.ConnectionStrings["DBweather"].ConnectionString;
            conn = new SqlConnection(connStr);
        }

        public void Show(string reg)
        {
            conn.Open();
            string sqlSelect = $"SELECT * FROM Weather WHERE Regeon='{reg}';";
            SqlCommand command = new SqlCommand(sqlSelect, conn);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write(reader.GetName(i) + "\t");
                }
                Console.WriteLine("\n--------------------------");
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write(reader[i] + "\t");
                    }
                    Console.WriteLine();
                }
            }
        }
        public void Show(string reg, int temperature)
        {
            conn.Open();
            string sqlSelect = $"SELECT * FROM Weather WHERE Regeon='{reg}' AND Precipitation='snow' AND Temperature<{temperature};";
            SqlCommand command = new SqlCommand(sqlSelect, conn);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write(reader.GetName(i) + "\t");
                }
                Console.WriteLine("\n--------------------------");
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write(reader[i] + "\t");
                    }
                    Console.WriteLine();
                }
            }
        }
        public void ShowWeatherByLang(string Lang)
        {
            conn.Open();
            string sqlSelect = $"SELECT Data, Temperature, Precipitation,NameRegeon,Language FROM Weather JOIN TablRegeon ON Weather.Regeon=TablRegeon.Regeon JOIN TablResidents ON TablRegeon.TypResidents=TablResidents.TypResidents WHERE TablResidents.Language='{Lang}';";
            SqlCommand command = new SqlCommand(sqlSelect, conn);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write(reader.GetName(i) + "\t");
                }
                Console.WriteLine("\n--------------------------");
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write(reader[i] + "\t");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
