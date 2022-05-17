using SimplyRugbyApp.Validators;
using System;
using System.Windows;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace SimplyRugbyApp
{
    /// <summary>
    /// Interaction logic for PlayerWindow.xaml
    /// </summary>
    public abstract partial class PlayerWindow : Window
    {
        #region members
        public DatabaseAccess database = new DatabaseAccess();
        private PlayerDetailsValidator validator = new PlayerDetailsValidator();

        public PlayerDetails Player { get; set; }
        #endregion

        #region construcors
        public PlayerWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region methods (CheckAge / SwitchTextBoxes / BackToListOfPlayers)
        private void CheckAge()
        {
            var today = DateTime.Today;
            var dob = Convert.ToDateTime(Tb_dob.Text);
            var age = today.Year - dob.Year;

            if (!(age >= 18))
            {
                Tb_parentalConsent.IsEnabled = true;

                if (age < 15) { Cb_squad.SelectedIndex = 0; }
                else if (age > 14 && age < 16) { Cb_squad.SelectedIndex = 1; }
                else if (age > 15 && age < 18) { Cb_squad.SelectedIndex = 2; }
            }
            else if (age > 17 && age < 20)
            {
                Cb_squad.SelectedIndex = 3;
                Tb_parentalConsent.IsEnabled = false;
            }
            else
            {
                Cb_squad.SelectedIndex = 4;
                Tb_parentalConsent.IsEnabled = false;
            }
        }

        protected internal void SwichTextBoxes(bool isPressed)
        {
            if (!isPressed)
            {
                Tb_firstName.IsEnabled = false;
                Tb_lastName.IsEnabled = false;
                Tb_dob.IsEnabled = false;
                Tb_email.IsEnabled = false;
                Tb_mobile.IsEnabled = false;
            }
            else
            {
                Tb_firstName.IsEnabled = true;
                Tb_lastName.IsEnabled = true;
                Tb_dob.IsEnabled = true;
                Tb_email.IsEnabled = true;
                Tb_mobile.IsEnabled = true;
                if (Tb_dob.Text != "") CheckAge();  //Tb_parentalConsent.IsEnabled = true;

            }
        }

        public void BackToListOfPlayers()
        {
            Window secretaryView = new Secretary();
            secretaryView.Show();
            this.Close();
        }
        #endregion

        #region Displaying and fetching data from Database (Load Player / Save Player / Load Squads)
        public virtual void DisplayPlayerDetails(int sruNumber)
        {
            Player = database.LoadPlayer(sruNumber);

            Tb_sruNumber.Text = Player.SRUNumber.ToString();
            Tb_firstName.Text = Player.FirstName;
            Tb_lastName.Text = Player.LastName;
            Tb_dob.Text = Player.DOB;
            Tb_email.Text = Player.Email;
            Tb_mobile.Text = Player.Mobile;
            Cb_squad.Items.Add(Player.Squad);
            Cb_squad.SelectedIndex = 0;
            Tb_parentalConsent.Text = Player.ParentalConsent;

        }

        protected internal PlayerDetails CollectDetails()
        {

            Player = new PlayerDetails();

            Player.SRUNumber = int.Parse(Tb_sruNumber.Text);
            Player.FirstName = Tb_firstName.Text;
            Player.LastName = Tb_lastName.Text;
            Player.DOB = Tb_dob.Text;
            Player.Email = Tb_email.Text;
            Player.Mobile = Tb_mobile.Text;
            Player.Squad = Cb_squad.SelectedItem.ToString();
            Player.ParentalConsent = Tb_parentalConsent.Text;

            return Player;
        }

        protected internal void SquadsList()
        {
            //var listOfSquads = Gr_elements.FindName() as ComboBox;
            var squads = database.LoadSquads();

            foreach (var squad in squads)
            {
                Cb_squad.Items.Add(squad.Name);
            }
            Cb_squad.SelectedIndex = 0;
        }
        #endregion

        #region OnLostFocus event handler (textbox)
        //Check age entered to DOB field when user move coursor to the next field
        public void Tb_dob_OnLostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                CheckAge();
            }
            catch
            {
                MessageBox.Show("Enter valid Date of Birth!");
                //Tb_dob.Focus();
            }
        }
        #endregion

        #region Abstracts Event handlers (buttons)
        public abstract void Btn_universal_one_Click(object sender, RoutedEventArgs e);
        public abstract void Btn_universal_two_Click(object sender, RoutedEventArgs e);
        public abstract void Btn_back_Click(object sender, RoutedEventArgs e);
        #endregion

        #region User input validation
        public ValidationResult UserInputValidation(PlayerDetails player)
        {
            ValidationResult result = validator.Validate(player);

            return result;

        }
        #endregion
    }
}
