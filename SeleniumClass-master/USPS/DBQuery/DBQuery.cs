using FrameworkLib.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace USPS.DBQuery
{
   public class DBQuery
    {
        public static Dictionary<int, string> PersonInfo(string condutions)
        {
            Dictionary<int, string> obj = new Dictionary<int, string>();
            string SQLPriceQuery = $"Select top 10 p.FirstName,p.LastName,pe.EmailAddress,pp.phoneNumber,pa.AddressLine1,pa.AddressLine2,pa.City," +
                $" pa.PostalCode from person.person p join person.EmailAddress pe on p.BusinessEntityID = pe.BusinessEntityID " +
                $"join person.PersonPhone pp on pp.BusinessEntityID = p.BusinessEntityID " +
                $"join Person.BusinessEntityAddress pbe on pbe.BusinessEntityID = p.BusinessEntityID join Person.Address pa on pa.AddressID = pbe.AddressID /* where EmailAddress = '{condutions}'*/" ;
            SqlDataReader excuteSQLPriceQuery = DatabaseHelpers.ExecuteQuery(SQLPriceQuery);
            int Rowcount = 0;
            while (excuteSQLPriceQuery.Read())
            {
                string FirstName = null;
                try { FirstName = excuteSQLPriceQuery.GetString(0).ToString(); } catch { FirstName = null; };


                string LastName= null;
                try { LastName = excuteSQLPriceQuery.GetString(1).ToString(); } catch { LastName = null; };

                string EmailAddress = null;
                try { EmailAddress = excuteSQLPriceQuery.GetString(2).ToString(); } catch { EmailAddress = null; };

                string phoneNumber = null;
                try { phoneNumber = excuteSQLPriceQuery.GetString(3).ToString(); } catch { phoneNumber = null; };

                string AddressLine1 = null;
                try { AddressLine1 = excuteSQLPriceQuery.GetString(4).ToString(); } catch { AddressLine1 = null; };

                string AddressLine2= null;
                try { AddressLine2 = excuteSQLPriceQuery.GetString(5).ToString(); } catch { AddressLine2 = null; };

                string City= null;
                try { City = excuteSQLPriceQuery.GetString(6).ToString(); } catch { City = null; };


                string PostalCode= null;
                try { PostalCode = excuteSQLPriceQuery.GetString(7).ToString(); } catch { PostalCode = null; };


                //string ListPrice = null;
                //try { ListPrice = excuteSQLPriceQuery.GetDecimal(1).ToString(); } catch { ListPrice = null; }
                //string SellStartDate = null;
                //try { SellStartDate = excuteSQLPriceQuery.GetDateTime(2).ToString(); } catch { SellStartDate = null; }

                string DataResutls = FirstName + "|" + LastName + "|" + EmailAddress + "|" + phoneNumber + "|" + AddressLine1 + "|" + AddressLine2  + "|" + City + "|" + PostalCode;
                obj.Add(Rowcount, DataResutls);
                Rowcount++;

            }
            return obj;

        }

    }
}
