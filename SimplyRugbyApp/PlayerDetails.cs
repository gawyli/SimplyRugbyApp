namespace SimplyRugbyApp
{
    public partial class PlayerDetails
    {
        #region members
        public int SRUNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DOB { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Squad { get; set; }
        public string ParentalConsent { get; set; }
        public PlayerSkills Skills { get; set; }
        #endregion

        #region constructors
        public PlayerDetails()
        {
            Skills = new PlayerSkills();
        }
        #endregion
    }
}
