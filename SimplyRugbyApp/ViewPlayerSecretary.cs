using System.Windows;

namespace SimplyRugbyApp
{
    class ViewPlayerSecretary : PlayerWindow, ISimplyRugby
    {
        #region members
        private int SRUNumber { get; set; }

        private static bool isPressed = false;
        #endregion

        #region constructors
        public ViewPlayerSecretary(int sruNumber)
        {
            SRUNumber = sruNumber;
            WindowAdjustments();
        }
        #endregion

        #region methods (WindowAdjustments / DisplayPlayerDetails)
        public void WindowAdjustments()
        {
            Btn_universal_one.Content = "Edit";
            Btn_universal_two.Content = "Remove";
            DisplayPlayerDetails(SRUNumber);

            
        }

        public override void DisplayPlayerDetails(int sruNumber)
        {
            try
            {
                base.DisplayPlayerDetails(sruNumber);
                this.Title = "Player: " + Player.FirstName + " " + Player.LastName;
            }
            catch
            {
                this.Content = "error";
            }
        }
        #endregion

        #region Edit and Save button
        public override void Btn_universal_one_Click(object sender, RoutedEventArgs e)
        {
            if (!isPressed)  //Edit function
            {
                isPressed = true;
                SwichTextBoxes(isPressed);
                Cb_squad.Items.Clear();
                SquadsList();

                foreach (var index in Cb_squad.Items)
                {
                    if (index.ToString() == Player.Squad)
                    {
                        Cb_squad.SelectedItem = index.ToString();
                    }
                }

                Btn_universal_one.Content = "Save";
                Btn_universal_two.IsEnabled = false;
            }

            //Save function
            else
            {
                var player = CollectDetails();
                var result = UserInputValidation(player);

                if (!result.IsValid)
                {
                    var failure = result.Errors[0];
                    MessageBox.Show(failure.ErrorMessage);
                }
                else if (Tb_parentalConsent.IsEnabled && Tb_parentalConsent.Text == "")
                {
                    MessageBox.Show("Player is under 18, Parental Consent must not be empty!");
                }
                else
                {
                    isPressed = false;
                    Btn_universal_one.Content = "Edit";
                    Btn_universal_two.IsEnabled = true;

                    database.UpdatePlayer(player);
                    SwichTextBoxes(isPressed);

                    MessageBox.Show("Player details has been updated!");
                }
            }
        }
        #endregion

        #region Remove button
        public override void Btn_universal_two_Click(object sender, RoutedEventArgs e)
        {
            database.RemovePlayer(SRUNumber);
            Btn_universal_two.IsEnabled = false;
            MessageBox.Show("Player has been removed!");

            //Back to the list
            BackToListOfPlayers();
        }
        #endregion

        #region Back button
        public override void Btn_back_Click(object sender, RoutedEventArgs e)
        {
            isPressed = false;
            BackToListOfPlayers();
        }
        #endregion

    }
}
