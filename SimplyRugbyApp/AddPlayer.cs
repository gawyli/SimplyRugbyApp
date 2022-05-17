using System;
using System.Collections.Generic;
using System.Windows;

namespace SimplyRugbyApp
{
    class AddPlayer : PlayerWindow, ISimplyRugby
    {
        #region constructor
        public AddPlayer()
        {
            WindowAdjustments();
        }
        #endregion

        #region methods (WindowAdjustments / CreateSRUNumber)
        public void WindowAdjustments()
        {
            this.Title = "Add Player";
            Btn_universal_one.Content = "Add";
            Cv_buttonSpace.Children.Remove(Btn_universal_two);

            SquadsList();           //load all squads located in database
            SwichTextBoxes(true);   //alwasy true because user must have access to TextBoxes when new player is adding
            CreateSRUNumber();      //generate random SRU number for new player
        }

        private void CreateSRUNumber()  //create random SRU number
        {
            Random rnd = new Random();                              //new instance of Random class
            List<int> sruNumberList = database.SRUNumberList();     //fetch exist SRUnumbers as List of integer from database
            int sruNumber;

            sruNumber = rnd.Next(100000, 1000000);      //create 6 digits long random number

            foreach (var sru in sruNumberList)      //check if generated number exists and if yes, then generate new number and repeat it as long as number will be unique
            {
                while (sruNumber == sru)
                {
                    sruNumber = rnd.Next(100000, 1000000);
                }
            }

            Tb_sruNumber.Text = sruNumber.ToString();
        }

        private void Add()      //Add new player function with validation
        {
            var player = CollectDetails();      //store return value to variable player
            var result = UserInputValidation(player);       //call the function responsible for validate player details and store whatever return value is

            if (!result.IsValid)    //check is result is true
            {
                var failure = result.Errors[0];     //Validation always stop on first rule's faliure, so that array Error always store only one message on position 0 (index 0)
                MessageBox.Show(failure.ErrorMessage);
            }
            else if (Tb_parentalConsent.IsEnabled && Tb_parentalConsent.Text == "") //If TextBox ParentalConsent is enable it means Player is under 18, so that TextBox can't be empty
            {
                MessageBox.Show("Player is under 18, Parental Consent must not be empty!");
            }
            else
            {
                database.AddPlayer(player);
                MessageBox.Show("Player has been added!");

                BackToListOfPlayers();
            }
        }
        #endregion

        #region Add button
        public override void Btn_universal_one_Click(object sender, RoutedEventArgs e)
        {
            Add();
        }
        #endregion

        #region To be implement
        public override void Btn_universal_two_Click(object sender, RoutedEventArgs e)
        {
            //For future implementation
        }
        #endregion

        #region Back button
        public override void Btn_back_Click(object sender, RoutedEventArgs e)
        {
            BackToListOfPlayers();
        }
        #endregion
    }
}
