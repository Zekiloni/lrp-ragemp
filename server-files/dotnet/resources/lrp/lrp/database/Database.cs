using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;
using MySql.Data.MySqlClient;
using static lrp.structs.log;
using System.Threading.Tasks;

namespace lrp.database
{
    class database : Script
    {
        public bool isConnected = false;
        public MySqlConnection sqlConnection;

        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }

        /// <summary>
        /// Init database connection string variables
        /// </summary>
        public database()
        {
            this.Host = "localhost";
            this.Username = "root";
            this.Password = "1232345";
            this.Database = "lcrp";

            //my change. 2 
        }

        [ServerEvent(Event.ResourceStart)]
        public async void OnResourceStart()
        {
            Log($"Framework starting");

            try
            {
                MySqlConnectionStringBuilder StringBuilder = new MySqlConnectionStringBuilder();
                StringBuilder.Server = this.Host;
                StringBuilder.UserID = this.Username;
                StringBuilder.Password = this.Password;
                StringBuilder.Database = this.Database;

                sqlConnection = new MySqlConnection(StringBuilder.ToString());

                Log("Attempting to connect to database..");

                await sqlConnection.OpenAsync();
                if (sqlConnection.State != System.Data.ConnectionState.Open) {
                    Log("Connection failed.");
                    return;
                }

                Log("Connection successful!");
                await sqlConnection.CloseAsync();
            }
            catch (Exception ex) {
                Log("Connection failed.");
            }
        }
    }
}
