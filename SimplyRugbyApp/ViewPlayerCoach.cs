using System.Windows;

namespace SimplyRugbyApp
{
    public partial class ViewPlayerCoach : PlayerWindow, ISimplyRugby
    {
        #region members
        protected internal int sruNumber;
        #endregion

        #region constructors
        public ViewPlayerCoach(int sruNumber)
        {
            this.sruNumber = sruNumber;
            WindowAdjustments();
        }
        #endregion

        #region methods (WindowAdjustments)
        public void WindowAdjustments()
        {
            try
            {
                DisplayPlayerDetails(sruNumber);
                this.Title = "Player: " + Player.FirstName + " " + Player.LastName;
            }
            catch
            {
                this.Content = "error";
            }

            Btn_universal_one.Content = "Add skills profile";
            Btn_universal_two.Content = "Display\nskills profiles";


        }
        #endregion

        #region Event handlers (AddSkillProfile / ListOfSkillProfiles / Back button)

        //AddSkillProfile
        public override void Btn_universal_one_Click(object sender, RoutedEventArgs e)
        {
            Window skillsProfile = new AddSkillProfile(Player);
            skillsProfile.Show();
            this.Close();

        }

        //ListOfSkillProfiles button
        public override void Btn_universal_two_Click(object sender, RoutedEventArgs e)
        {
            Window listOfSkillProfiles = new ListOfSkillProfile(Player);
            listOfSkillProfiles.Show();
            this.Close();
        }

        //Back button
        public override void Btn_back_Click(object sender, RoutedEventArgs e)
        {
            Window coachView = new Coach();
            coachView.Show();
            this.Close();
        }
        #endregion
    }
}
