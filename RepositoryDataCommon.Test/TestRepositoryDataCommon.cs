using NUnit.Framework;
using FluentAssertions;
using Contracts;
using Entities;
using PartyInvitesCustom.Models;
using RepositoryDataCommon;
using PartyInvitesCustom.Orchestrators;
using RepoSQLite;
using System;
using System.Data;
using System.IO;
using System.Data.SQLite;

namespace RepositoryDataCommon.Test
{
    public class TestRepoConnection : IRepoConnection
    {
        string m_DbFileName = "SQLiteDB.sqlite";
        string m_ConnectionString = "Data Source=SQLiteDB.sqlite";
        string m_Database = "";

        public string ConnectionString
        {
            get
            {
                return m_ConnectionString;
            }
            set
            {
                m_ConnectionString = value;
                m_DbFileName = "SQLiteDB.sqlite";
            }

        }

        public string DatabaseName
        {
            get { return m_Database; }
            set { m_Database = value; }
        }

        //Takes connection string returns SQLiteConnection
        public IDbConnection Connection(string aConnectionString)
        {
            var vConnection = new SQLiteConnection(aConnectionString);

            return (vConnection);
        }
    }

    [TestFixture]
    public class TestRespositoryDataCommon
    {
        public Guest MakeNewRecord()
        {
            Guest vRecord = new Guest
            {
                Name = "Test Record",
                Email = "Test@Email.Com",
                Phone = "123-456-7890",
                WillAttend = true
            };

            return vRecord;
        }

        [Test]
        public void TestAddGuest()
        {
            // Arrange
            TestRepoConnection vTestRepoConnection = new TestRepoConnection();
            GuestDataCommon vTestRepo = new GuestDataCommon(vTestRepoConnection);
            //vTestRepo.StartUp();
            int vCountBefore = vTestRepo.Count();
            Guest vRecord = MakeNewRecord();

            // Act
            vTestRepo.Add(vRecord);
            int vCountAfter = vTestRepo.Count();

            // Assert
            vCountAfter.Should().Be(vCountBefore + 1);
        }
    }
}
