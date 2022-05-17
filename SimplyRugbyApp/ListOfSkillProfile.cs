using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SimplyRugbyApp
{
    class ListOfSkillProfile : ListWindow, ISimplyRugby
    {
        #region members

        private PlayerDetails Player { get; set; }
        private List<PlayerSkills> PlayerListSkillProfiles { get; set; }

        private string date;
        #endregion

        #region constructors
        public ListOfSkillProfile(PlayerDetails player)
        {

            Player = player;
            WindowAdjustments();
        }
        #endregion

        #region methods (WindowAdjustments / LoadSkillProfiles(+sorting dates))
        public void WindowAdjustments()
        {
            Btn_universal_one.Content = "View";
            Btn_universal_two.Content = "In future";
            Btn_universal_two.IsEnabled = false;
            LoadSkillProfiles();

            this.Title = "List of skills profiles";
        }

        private void LoadSkillProfiles()    //Load Skill profiles to list and sort them by the date of adding
        {
            List<DateTime> listOfDates = new();
            PlayerListSkillProfiles = database.LoadPlayerSkillProfiles(Player);

            foreach (var skillProfile in PlayerListSkillProfiles)
            {
                listOfDates.Add(DateTime.Parse(skillProfile.Data));
            }

            listOfDates.Sort((a, b) => a.CompareTo(b)); //sort dates ascending

            foreach (var date in listOfDates)
            {
                Lst_universalList.Items.Add(date.ToString("dd/MM/yyyy"));
            }
        }
        #endregion

        #region Event handler (SelectionChanged - ListView)
        public override void Lst_universalList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            date = Lst_universalList.SelectedItem.ToString();
        }
        #endregion

        #region Event handlers (DisplaySkillProfile / Empty(for implementation) / Back buttons)

        //DisplaySkillProfiles button
        public override void Btn_universal_one_Click(object sender, RoutedEventArgs e)
        {
            if (date != null)
            {
                Window skillProfile = new DisplaySkillProfile(PlayerListSkillProfiles, date, Player);
                skillProfile.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Select one of the skill profile!");
            }
        }

        //For future button
        public override void Btn_universal_two_Click(object sender, RoutedEventArgs e)
        {
            //for future implementation
        }

        //Back button
        public override void Btn_back_Click(object sender, RoutedEventArgs e)
        {
            Window viewPlayer = new ViewPlayerCoach(Player.SRUNumber);
            viewPlayer.Show();
            this.Close();
        }
        #endregion
    }
}
