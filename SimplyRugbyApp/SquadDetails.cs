using System.Collections.Generic;

namespace SimplyRugbyApp
{
    public partial class SquadDetails
    {
        #region members
        public string Name { get; set; }
        public List<PlayerDetails> Players { get; set; }
        #endregion

        #region Constructors
        public SquadDetails()
        {

        }
        public SquadDetails(string name)
        {
            Name = name;
            Players = new List<PlayerDetails>();
        }
        #endregion
    }
}
