using CoronaTestRest.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaTestRest.DBUtil
{
    public class ManageCoronaTest
    {
        private const String connectionString = @"Server=tcp:oursqlservice.database.windows.net,1433;Initial Catalog=RestDB;Persist Security Info=False;User ID=Secret!;Password=12345678A!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        private const String Get_All = "select * from CoronaTests";
        private const String Get_By_Id = "select * from CoronaTests WHERE TestId = @ID";
        private const String Get_By_High_Temperature = "select * from CoronaTests WHERE Temperature > 38";

        public IEnumerable<CoronaTest> Get()
        {
            List<CoronaTest> liste = new List<CoronaTest>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(Get_All, conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CoronaTest test = ReadNextElement(reader);
                    liste.Add(test);
                }

                reader.Close();
            }

            return liste;
        }

        public CoronaTest GetById(int id)
        {
            CoronaTest cTest = new CoronaTest();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(Get_By_Id, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    var reader = cmd.ExecuteReader();
                    if (reader.Read()) cTest = ReadNextElement(reader);
                }
            }

            return cTest;
        }

        public IEnumerable<CoronaTest> HighTemperature()
        {
            List<CoronaTest> tListe = new List<CoronaTest>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(Get_By_High_Temperature, conn))
                {
                    
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        CoronaTest test = ReadNextElement(reader);
                        tListe.Add(test);
                    }

                    reader.Close();
                }
            }

            return tListe;
        }


        private CoronaTest ReadNextElement(SqlDataReader reader)
        {
            CoronaTest coronaTest = new CoronaTest();

            coronaTest.TestId = reader.GetInt32(0);
            coronaTest.MachineName = reader.GetString(1);
            coronaTest.Temperature = reader.GetDouble(2);
            coronaTest.Location = reader.GetString(3);
            coronaTest.Date = reader.GetString(4);
            coronaTest.Time = reader.GetString(5);

            return coronaTest;
        }

    }
}
