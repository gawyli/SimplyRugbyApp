using System.Windows;
using System.Windows.Controls;


namespace SimplyRugbyApp
{

    class ListOfEmails : ListWindow, ISimplyRugby
    {
        #region constructors
        public ListOfEmails()
        {
            WindowAdjustments();
        }
        #endregion

        #region methods
        public void WindowAdjustments()
        {
            DisplayEmails();
            Btn_universal_one.Content = "Send to all";
            Btn_universal_two.Content = "Send";

            this.Title = "List of emails";
        }

        private void DisplayEmails()    //function to display emails in the list
        {
            var players = database.LoadPlayers();

            foreach (var player in players)
            {
                string name = player.FirstName + " " + player.LastName;

                Lst_universalList.Items.Add(name + ":\n" + player.Email + "\n");
            }

        }
        #endregion

        #region selection changed event handler
        public override void Lst_universalList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedEmail = Lst_universalList.SelectedItem.ToString();
        }
        #endregion

        #region to be implement button (send to all)
        public override void Btn_universal_one_Click(object sender, RoutedEventArgs e)
        {
            /*
             *  Send to all - To be implement (outlook)
             */
            MessageBox.Show("Feature is not implemented yet! Sorry for inconvenience.");
        }
        #endregion

        #region to be implement button (send)
        public override void Btn_universal_two_Click(object sender, RoutedEventArgs e)
        {
            /*
             * Send - To be implement (outlook)
             */
            MessageBox.Show("Feature is not implemented yet! Sorry for inconvenience.");
        }
        #endregion

        #region back button
        public override void Btn_back_Click(object sender, RoutedEventArgs e)
        {
            Window secretaryView = new Secretary();
            secretaryView.Show();
            this.Close();
        }
        #endregion
    }
}
