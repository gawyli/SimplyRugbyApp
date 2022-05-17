using System;
using System.Windows;
using System.Windows.Controls;

namespace SimplyRugbyApp
{
    class AddSkillProfile : SkillsProfile
    {
        #region members
        private PlayerDetails Player { get; set; }
        #endregion

        #region constructors
        public AddSkillProfile(PlayerDetails player)
        {
            Player = player;
            WindowAdjustments();
            ComboBoxAdjustment();
        }
        #endregion

        #region methods
        public override void WindowAdjustments()
        {
            this.Title = "Add skill profile";

            Tb_firstName.Text = Player.FirstName;       //assigns First name to TextBox
            Tb_lastName.Text = Player.LastName;         //assigns Last name to TextBox
            Cb_squad.Items.Add(Player.Squad);           //assigns Squad to Combobox
            Cb_squad.SelectedIndex = 0;                 //displays Squad in Combobox
        }

        public override void ComboBoxAdjustment()   //add to comboboxes values 1 to 5
        {
            string[] cbNames = { "standard", "spin", "pop", "front", "rear", "side", "scrabble", "drop", "punt", "grubber", "goal" };   //comboboxes names

            foreach (var name in cbNames)
            {
                var comboBox = Gr_skillsGrid.FindName("Cb_" + name) as ComboBox;    //finding the control by names ans save as combobox

                for (int i = 1; i < 6; i++)
                {
                    comboBox.Items.Add(i);
                }

                comboBox.SelectedIndex = 0;
            }
        }

        private void IsDateValid()   //checking if date is valid
        {
            bool isDateDuplicated = false;
            var tempPlayerSkillsList = database.LoadPlayerSkillProfiles(Player);    //temporary list of player's skill profiles 
            

            Player.Skills.Data = Dp_addingData.SelectedDate.Value.ToString("dd/MM/yyyy");   //assigns date value to the property in Player's skill clase

            if (Convert.ToDateTime(Player.Skills.Data) <= DateTime.Now)     //check if selected date is not from the future
            {
                foreach (var skillProfile in tempPlayerSkillsList)  //foreach iterate each skill profile and if statement check date against date in datebase
                {
                    if (skillProfile.Data == Player.Skills.Data)
                    {
                        isDateDuplicated = true;
                        MessageBox.Show("Selected date already exist!");
                        break;
                    }
                }
                if (!isDateDuplicated)
                {
                    database.AddSkillsRate(Player);     //add player skills to the database
                    MessageBox.Show("Skills have been added!");
                    BackToPlayer();
                }
            }
            else
            {
                MessageBox.Show("Selected date cannot be in the future!");
            }
        }

        private void AddSkillsToDatabase()      //assigns values from combobox to properties; validate date; add profile to database
        {
            //Passing
            Player.Skills.Standard = int.Parse(Cb_standard.Text);
            Player.Skills.Spin = int.Parse(Cb_spin.Text);
            Player.Skills.Pop = int.Parse(Cb_pop.Text);
            Player.Skills.PassingComment = Tb_passCom.Text;
            //Trackling
            Player.Skills.Front = int.Parse(Cb_front.Text);
            Player.Skills.Rear = int.Parse(Cb_rear.Text);
            Player.Skills.Side = int.Parse(Cb_side.Text);
            Player.Skills.Scrabble = int.Parse(Cb_scrabble.Text);
            Player.Skills.TracklingComment = Tb_tracCom.Text;
            //Kicking
            Player.Skills.DropSkill = int.Parse(Cb_drop.Text);
            Player.Skills.Punt = int.Parse(Cb_punt.Text);
            Player.Skills.Grubber = int.Parse(Cb_grubber.Text);
            Player.Skills.Goal = int.Parse(Cb_goal.Text);
            Player.Skills.KickingComment = Tb_kickCom.Text;

            //Data
            if (Dp_addingData.SelectedDate == null)
            {
                MessageBox.Show("Date must be selected!");
            }
            else
            {
                IsDateValid();
            }
        }

        private void BackToPlayer()
        {
            Window viewPlayer = new ViewPlayerCoach(Player.SRUNumber);
            viewPlayer.Show();
            this.Close();
        }
        #endregion

        #region Save button
        public override void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            AddSkillsToDatabase();

        }
        #endregion

        #region Back button
        public override void Btn_back_Click(object sender, RoutedEventArgs e)
        {
            BackToPlayer();
        }
        #endregion
    }
}
