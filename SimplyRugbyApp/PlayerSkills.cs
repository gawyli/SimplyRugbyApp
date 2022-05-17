namespace SimplyRugbyApp
{
    public partial class PlayerSkills
    {
        #region members
        //Passing
        public int Standard { get; set; }
        public int Spin { get; set; }
        public int Pop { get; set; }
        public string PassingComment { get; set; }

        //Trackling
        public int Front { get; set; }
        public int Rear { get; set; }
        public int Side { get; set; }
        public int Scrabble { get; set; }
        public string TracklingComment { get; set; }

        //Kicking
        public int DropSkill { get; set; }
        public int Punt { get; set; }
        public int Grubber { get; set; }
        public int Goal { get; set; }
        public string KickingComment { get; set; }

        //Date of adding
        public string Data { get; set; }
        #endregion
    }
}
