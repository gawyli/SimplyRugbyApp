using System.Collections.Generic;

namespace SimplyRugbyApp
{
    /// <summary>
    /// This class is used by ListOfPlayersWindows.xaml to display all squads and belongs to them the players in the TreeView
    /// XAML file create an instance of ClubDetails and binding data to the TreeView
    /// Check XAML code in ListOfPlayersWindow.xaml
    /// </summary> 

    class ClubDetails : List<SquadDetails>
    {
        #region constructor
        public ClubDetails()
        {
            CreateClubWithSquadsAndPlayers();
        }
        #endregion

        #region methods
        private void CreateClubWithSquadsAndPlayers()   //creating list of players and squads that the players belong to
        {
            DatabaseAccess database = new();    //create instance of database class

            SquadDetails team;  //declare variable team 

            var squads = database.LoadSquads();
            var players = database.LoadPlayers();


            foreach (var squad in squads)   //foreach squad in squads
            {
                team = new SquadDetails(squad.Name);    //create new instance of SquadDetails class with squad.Name parameter passing
                foreach (var player in players)     //foreach player in players
                {
                    if (player.Squad == squad.Name)     //check if player belong to indicated suqad
                    {
                        team.Players.Add(player);   //add the player that belongs to the correct squad into team variable 
                    }
                }
                this.Add(team); //assign squad and player to the Club list which is displayed in List in XAML file
            }
        }
        #endregion
    }
}
