using Dapper;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace SimplyRugbyApp
{
    public partial class DatabaseAccess
    {
        private static string ConnectionString()    //creating ConnectionString for connecting to database
        {
            var connectionStringBuilder = new SQLiteConnectionStringBuilder
            {
                DataSource = "./SimplyRugbyDB.db"
            };

            return connectionStringBuilder.ConnectionString;
        }

        public List<SquadDetails> LoadSquads()  //load squads from DB and save them as list
        {
            using (var connection = new SQLiteConnection(ConnectionString()))   //using statement keep connection with DB as long as code is execute between {}
                                                                                //conection is automatically closed when program finish use code in using statment
            {
                string selectQuery = "select * from Squads";

                connection.Open();
                var squads = connection.Query<SquadDetails>(selectQuery);   //execute query using dapper library 

                return squads.ToList();
            }
        }

        public List<PlayerDetails> LoadPlayers()    //load players from DB and save them as list
        {
            using (var connection = new SQLiteConnection(ConnectionString()))
            {
                string selectQuery = "select * from Players";

                connection.Open();
                var players = connection.Query<PlayerDetails>(selectQuery);

                return players.ToList();
            }
        }

        public PlayerDetails LoadPlayer(int sruNumber)  //load player details to which sruNumber belongs to
        {
            using (var connection = new SQLiteConnection(ConnectionString()))
            {
                string selectQuery = "select * from Players where SRUNumber = " + sruNumber;

                connection.Open();
                var player = connection.QuerySingle<PlayerDetails>(selectQuery);

                return player;
            }
        }

        public void AddPlayer(PlayerDetails player)     //add player to database
        {
            using (var connection = new SQLiteConnection(ConnectionString()))
            {
                string insertQuery = "insert or replace into Players " +
                    "(SRUNumber, FirstName, LastName, DOB, Email, Mobile, Squad, ParentalConsent) " +
                    "values (@SRUNumber, @FirstName, @LastName, @DOB, @Email, @Mobile, @Squad, @ParentalConsent)";

                connection.Open();
                connection.Execute(insertQuery, player);
            }
        }

        public void UpdatePlayer(PlayerDetails player)  //update player details in database
        {
            using (var connection = new SQLiteConnection(ConnectionString()))
            {
                string updateQuery = "update Players set " +
                    "FirstName = @FirstName, LastName = @LastName, DOB = @DOB, " +
                    "Email = @Email, Mobile = @Mobile, Squad = @Squad, " +
                    "ParentalConsent = @ParentalConsent where SRUNumber = @SRUNumber";

                connection.Open();
                connection.Execute(updateQuery, player);
            }
        }

        public void RemovePlayer(int sruNumber)     //remove player from database with indicated sruNumber
        {
            using (var connection = new SQLiteConnection(ConnectionString()))
            {
                string deleteQueryPlayer = "delete from Players where SRUNumber = " + sruNumber;
                string deleteQuerySkills = "delete from Skills where SRUNumber = " + sruNumber;

                connection.Open();
                connection.Execute(deleteQueryPlayer);
                connection.Execute(deleteQuerySkills);

            }
        }

        public List<int> SRUNumberList()    //Load sruNumbers to list - function for generate unique sruNumber
        {
            using (var connection = new SQLiteConnection(ConnectionString()))
            {
                string selectQuery = "select SRUNumber from Players";

                connection.Open();
                var sruNumberList = connection.Query<int>(selectQuery);

                return sruNumberList.ToList();
            }
        }

        public void AddSkillsRate(PlayerDetails player)     //add skills profile to the player
        {
            using (var connection = new SQLiteConnection(ConnectionString()))
            {
                string insertQuery = " Insert into Skills " +
                "(SRUNumber, Data, Standard, Spin, Pop, PassingComment, " +
                "Front, Rear, Side, Scrabble, TracklingComment, " +
                "DropSkill, Punt, Grubber, Goal, KickingComment)";

                insertQuery +=
                    "Values(" + player.SRUNumber + ",'" + player.Skills.Data +
                    "'," + player.Skills.Standard + "," + player.Skills.Spin + "," + player.Skills.Pop + ",'" + player.Skills.PassingComment +
                    "'," + player.Skills.Front + "," + player.Skills.Rear + "," + player.Skills.Side + "," + player.Skills.Scrabble + ",'" + player.Skills.TracklingComment +
                    "'," + player.Skills.DropSkill + "," + player.Skills.Punt + "," + player.Skills.Grubber + "," + player.Skills.Goal + ",'" + player.Skills.KickingComment +
                    "')";

                connection.Execute(insertQuery);
            }
        }

        public List<PlayerSkills> LoadPlayerSkillProfiles(PlayerDetails player)     //load player's skill profiles and save them as list
        {
            using (var connection = new SQLiteConnection(ConnectionString()))
            {
                string selectQuery = "select * from Skills where SRUNumber = @SRUNumber";

                connection.Open();
                var skillProfiles = connection.Query<PlayerSkills>(selectQuery, player);

                return skillProfiles.ToList();
            }
        }
    }
}
