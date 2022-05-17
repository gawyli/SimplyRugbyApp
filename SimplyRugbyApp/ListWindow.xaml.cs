using System.Windows;
using System.Windows.Controls;

namespace SimplyRugbyApp
{
    /// <summary>
    /// Interaction logic for ListWindow.xaml
    /// </summary>
    public abstract partial class ListWindow : Window
    {
        #region members
        public DatabaseAccess database = new();
        #endregion

        #region constructors
        public ListWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region Abstracts Event handlers (buttons)
        public abstract void Btn_universal_one_Click(object sender, RoutedEventArgs e);
        public abstract void Btn_universal_two_Click(object sender, RoutedEventArgs e);
        public abstract void Btn_back_Click(object sender, RoutedEventArgs e);
        #endregion

        #region abstract selection changed event handler
        public abstract void Lst_universalList_SelectionChanged(object sender, SelectionChangedEventArgs e);
        #endregion
    }
}
