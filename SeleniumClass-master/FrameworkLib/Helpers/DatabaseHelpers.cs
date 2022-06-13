using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FrameworkLib.Helpers
{
    public static  class DatabaseHelpers
    {
        /*Open the connection*/

        public static SqlConnection DBConnect()

        {

            string ConnectionString = @"FAISALDESKTOP\SQLEXPRESS01";

            try

            {

                SqlConnection sqlConnect = new SqlConnection();

                sqlConnect.ConnectionString = @"Data Source=localhost\SQLEXPRESS03; Initial Catalog= AdventureWorks2019;Integrated Security=True";

                sqlConnect.Open();

                return sqlConnect;

            }

            catch (Exception e)

            {

                Console.WriteLine("ERROR :: " + e.Message);

            }



            return null;

        }



        /*to Execution Query*/
        public static SqlDataReader ExecuteQuery(string queryString)

        {

            string connetionString = null;

            SqlConnection sqlCnn;

            SqlCommand sqlCmd = null;

            SqlDataReader sqlReader = null;

            connetionString = @"Data Source=localhost\SQLEXPRESS03; Initial Catalog= AdventureWorks2019;Integrated Security=True";



            sqlCnn = new SqlConnection(connetionString);

            try

            {

                sqlCnn.Open();

                if (sqlCnn.State == System.Data.ConnectionState.Open)

                {

                    sqlCmd = new SqlCommand();

                    sqlCmd.Connection = sqlCnn;

                    sqlCmd.CommandType = CommandType.Text;

                    sqlCmd.CommandText = queryString;

                    sqlReader = sqlCmd.ExecuteReader(CommandBehavior.Default);

                    return sqlReader;

                }

            }

            catch (Exception ex)

            {

            }

            return sqlReader;

        }

        /*Closing the connection */

        public static void DBClose(this SqlConnection sqlConnection)

        {

            try

            {
                sqlConnection.Close();
            }

            catch (Exception e)

            {
                Console.WriteLine("ERROR :: " + e.Message);

            }

        }

    }
}