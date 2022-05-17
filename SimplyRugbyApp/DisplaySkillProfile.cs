using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SimplyRugbyApp
{
    class DisplaySkillProfile : SkillsProfile
    {
        #region members
        private List<PlayerSkills> SkillProfiles { get; set; }
        private PlayerDetails Player { get; set; }

        private string data;
        #endregion

        #region constructors
        public DisplaySkillProfile(List<PlayerSkills> skillProfiles, string data, PlayerDetails player)
        {
            SkillProfiles = skillProfiles;
            Player = player;
            this.data = data;

            ComboBoxAdjustment();
            WindowAdjustments();

        }
        #endregion

        #region methods
        public override void WindowAdjustments()
        {
            this.Title = "Skill profile";

            Tb_firstName.Text = Player.FirstName;
            Tb_lastName.Text = Player.LastName;
            Cb_squad.Items.Add(Player.Squad);
            Cb_squad.SelectedIndex = 0;

            Dp_addingData.IsEnabled = false;
            Dp_addingData.SelectedDate = DateTime.Parse(data);
            Gr_elements.Children.Remove(Btn_save);

            Tb_passCom.IsReadOnly = true;
            Tb_tracCom.IsReadOnly = true;
            Tb_kickCom.IsReadOnly = true;

        }

        public override void ComboBoxAdjustment()
        {
            string[] cbNames = { "standard", "spin", "pop", "front", "rear", "side", "scrabble", "drop", "punt", "grubber", "goal" };

            List<int> skillsRate = new();


            foreach (var skillProfile in SkillProfiles)
            {
                if (skillProfile.Data == data)
                {
                    //Passing
                    skillsRate.Add(skillProfile.Standard);
                    skillsRate.Add(skillProfile.Spin);
                    skillsRate.Add(skillProfile.Pop);

                    //Trackling
                    skillsRate.Add(skillProfile.Front);
                    skillsRate.Add(skillProfile.Rear);
                    skillsRate.Add(skillProfile.Side);
                    skillsRate.Add(skillProfile.Scrabble);

                    //Kicking
                    skillsRate.Add(skillProfile.DropSkill);
                    skillsRate.Add(skillProfile.Punt);
                    skillsRate.Add(skillProfile.Grubber);
                    skillsRate.Add(skillProfile.Goal);

                    //Textboxes - comments
                    Tb_passCom.Text = skillProfile.PassingComment;
                    Tb_tracCom.Text = skillProfile.TracklingComment;
                    Tb_kickCom.Text = skillProfile.KickingComment;
                    break;
                }
            }

            for (int i = 0; i < cbNames.Length; i++)
            {
                var comboBox = Gr_skillsGrid.FindName("Cb_" + cbNames[i]) as ComboBox;
                comboBox.IsEnabled = false;

                foreach (var skillProfile in SkillProfiles)
                {
                    if (skillProfile.Data == data)
                    {
                        comboBox.Items.Add(skillsRate[i]);
                        comboBox.SelectedIndex = 0;
                    }
                }
            }
        }
        #endregion

        #region save button
        public override void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            //for future implementation
            //Remove current skill profile
            //Name of btn must be change
        }
        #endregion

        #region back button
        public override void Btn_back_Click(object sender, RoutedEventArgs e)
        {
            Window viewPlayer = new ListOfSkillProfile(Player);
            viewPlayer.Show();
            this.Close();
        }
        #endregion
    }
}
