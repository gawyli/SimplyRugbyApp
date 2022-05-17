using System.Windows;

namespace SimplyRugbyApp
{
    class Secretary : ListOfPlayersWindow
    {
        #region constructor
        public Secretary()
        {

        }
        #endregion

        #region Event handlers (buttons)
        public override void Btn_ViewPlayerDetails_Click(object sender, RoutedEventArgs e)
        {
            if (!(SelectedPlayer() == 0))
            {
                Window viewPlayer = new ViewPlayerSecretary(SelectedPlayer());
                viewPlayer.Show();
                this.Close();
            }
            else MessageBox.Show("Select the Player to check details!");
        }

        public override void Btn_Search_Click(object sender, RoutedEventArgs e)
        {
            if (Tb_SruSearch.Text.Length == 6)
            {
                Window viewPlayer = new ViewPlayerSecretary(int.Parse(Tb_SruSearch.Text));

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
