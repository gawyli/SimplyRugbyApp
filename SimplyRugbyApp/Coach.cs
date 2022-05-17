using System.Windows;

namespace SimplyRugbyApp
{
    class Coach : ListOfPlayersWindow, ISimplyRugby
    {
        #region constructors
        public Coach()
        {
            WindowAdjustments();
        }
        #endregion

        #region methods (WindowAdjustments)
        public void WindowAdjustments()
        {
            Gr_elements.Children.Remove(Btn_AddPlayer);
            Gr_elements.Children.Remove(Btn_ListOfEmails);
        }
        #endregion

        #region Event handlers (ViewPlayer / Search buttons)
        public override void Btn_ViewPlayerDetails_Click(object sender, RoutedEventArgs e)
        {
            if (!(SelectedPlayer() == 0))   //check if player has been selected
            {
                Window playerWindow = new ViewPlayerCoach(SelectedPlayer());
                playerWindow.Show();
                this.Close();
            }
            else MessageBox.Show("Select the Player to check details!");

        }
        public override void Btn_Search_Click(object sender, RoutedEventArgs e)
        {
            if (Tb_SruSearch.Text.Length == 6)  //check if SRU has 6 digits
            {
                Window viewPlayer = new ViewPlayerCoach(int.Parse(Tb_SruSearch.Text));

                if (viewPlayer.Content.ToString() == "error")
                {
                    MessageBox.Show("SRU Number does not exist!");
                    viewPlayer.Close();
                }
                else
                {
                    viewPlayer.Show();
                    this.Close();
                }
            }
            else MessageBox.Show("Enter valid SRU Number!");
        }
        #endregion
    }
}
