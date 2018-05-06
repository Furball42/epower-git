using ePower.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ePower.Portal.Helpers
{
    public static class RegistrationHelpers
    {
        public static bool CreateNewRegisteredDatabase(string databaseName)
        {
            var connection = System.Configuration.ConfigurationManager.ConnectionStrings["PortalConnection"].ConnectionString;
            var connectionString = string.Format(connection, databaseName);

            connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=" + databaseName + ";Integrated Security=True";

            var db = new ApplicationDbContext(connectionString);

            try
            {
                return db.Database.CreateIfNotExists();
            }
            catch (Exception e)
            {
                return false;
            }
                        
        }
    }
}