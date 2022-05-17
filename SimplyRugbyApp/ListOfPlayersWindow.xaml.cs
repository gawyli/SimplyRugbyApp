using System.Windows;

namespace SimplyRugbyApp
{
    /// <summary>
    /// Interaction logic for ListOfPlayersWindow.xaml
    /// </summary>
    public abstract partial class ListOfPlayersWindow : Window
    {
        #region constructor
        public ListOfPlayersWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region methods (SelectedPlayer)
        #region DisplayPlayers - old method replaces by TreeView code implementation
        /*
        private void DisplayPlayers()
        {
            var database = new DatabaseAccess();
            var players = database.LoadPlayers();

            foreach (var player in players)
            {
                string name = player.FirstName + " " + player.LastName;
                Tv_listOfPlayers.Items.Add(player.SRUNumber + " " + name);
            }

        }
        */
        #endregion
        protected internal int SelectedPlayer()
        {
            var selectedPlayer = Tv_listOfPlayers.SelectedItem as PlayerDetails;

            if (selectedPlayer == null)
            {
                return 0;
            }
            else
            {
                return selectedPlayer.SRUNumber;
            }
        }
        #endregion

        #region Event handlers (AddPlayer / ListOfEmails / Exit buttons)
        protected internal void Btn_AddPlayer_Click(object sender, RoutedEventArgs e)
        {
            Window addPlayer = new AddPlayer();
            addPlayer.Show();
            this.Close();
        }
        protected internal void Btn_ListOfEmails_Click(object sender, RoutedEventArgs e)
        {
            Window listOfEmails = new ListOfEmails();
            listOfEmails.Show();
            this.Close();

        }
        private void Btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Abstracts Event handlers (buttons)
        public abstract void Btn_Search_Click(object sender, RoutedEventArgs e);
        public abstract void Btn_ViewPlayerDetails_Click(object sender, RoutedEventArgs e);
        #endregion
    }
}