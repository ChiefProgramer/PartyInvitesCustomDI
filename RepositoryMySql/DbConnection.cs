using System;
using System.Collections.Generic;
using System.Text;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace RepositoryMySql
{
    class DbConnection
    {
        //you'll probably have to change the port, I have several db's running on my machine so I
        //put mysql on 33061 instead of 3306. This way I can be lazy and just leave the others running
        string ConnectionString = "server=localhost;user=partyinvitesuser;database=partyinvitesdb;port:33061;password=Password1234!";


        public MySqlConnection Connect(string aConnectionString)
        {
            MySqlConnection connection = new MySqlConnection(aConnectionString);
            return connection;
        }
    }
}
