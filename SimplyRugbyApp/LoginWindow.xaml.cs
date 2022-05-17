using System.Windows;

namespace SimplyRugbyApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        #region members
        private string Username { get; set; }
        private string Password { get; set; }
        #endregion

        #region constructors
        public LoginWindow()
        {
            InitializeComponent();
            this.Title = "Login";
        }
        #endregion

        #region methods
        private void Verification()
        {
            const string SECRETARY_USER = "secretary";
            const string COACH_USER = "coach";
            const string SECRETARY_PASSWORD = "secretaryPWD";
            const string COACH_PASSWORD = "coachPWD";

            if (Username == SECRETARY_USER && Password == SECRETARY_PASSWORD)
            {
                Window secretaryView = new Secretary();
                secretaryView.Show();
                this.Close();

            }
            else if (Username == COACH_USER && Password == COACH_PASSWORD)
            {
                Window coachView = new Coach();
                coachView.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Username or password is wrong!");
            }
        }
        #endregion

        #region login button
        private void Btn_login_Click(object sender, RoutedEventArgs e)
        {
            Username = Tb_username.Text;
            Password = Pb_password.Password;
            Verification();
        }
        #endregion

        #region exit button
        private void Btn_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
