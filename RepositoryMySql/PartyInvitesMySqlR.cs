using System;
using System.Collections.Generic;
using System.Text;
using Contracts;
using Entities;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace RepositoryMySql
{
    class PartyInvitesMySqlR : IPartyInvitesR
    {
        //create a db connection
        static string ConnectionString = "server=localhost;user=partyinvitesuser;database=partyinvitesdb;port:33061;password=Password1234!";
        static MySqlConnection db = new MySqlConnection(ConnectionString);


        public void Add(GuestResponse aGuestResponse)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(int aGuesResponseId)
        {
            throw new NotImplementedException();
        }

        public GuestResponse Get(int aGuestResponseId)
        {
            throw new NotImplementedException();
        }

        public List<GuestResponse> GetAll()
        {
            db.Open();
            string sql = "SELECT * FROM invitationresponses;";
            MySqlCommand cdm = new MySqlCommand(sql, db);

            throw new NotImplementedException();
        }

        public List<GuestResponseYes> GetAllGuestResponseYes()
        {
            throw new NotImplementedException();
        }

        public void Update(GuestResponse aGuestResponse)
        {
            throw new NotImplementedException();
        }
    }
}
