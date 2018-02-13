using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace RepositoryMySql
{
    public class PartyInvitesMySqlConenction
    {
        //Properties
        string ConnectionString;
        MySqlConnection connection = new MySqlConnection();

        //Constructors
        public PartyInvitesMySqlConenction(string aConnectionString)
        {
            this.connection = new MySqlConnection(aConnectionString);
        }

        public PartyInvitesMySqlConenction()
        {
            string ConnectionString = "server = localhost; port: 33061; user: partyinvitesuser; password = Password1234!; database = partyinvitesdb";
            this.connection = new MySqlConnection(ConnectionString);
        }

        
    }
}
