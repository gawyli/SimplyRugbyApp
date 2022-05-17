using System.Windows;

namespace SimplyRugbyApp
{
    /// <summary>
    /// Interaction logic for SkillsProfile.xaml
    /// </summary>
    public abstract partial class SkillsProfile : Window, ISimplyRugby
    {
        #region members
        public DatabaseAccess database = new();
        #endregion

        #region constructors
        public SkillsProfile()
        {
            InitializeComponent();

        }
        #endregion

        #region abstracts methods
        public abstract void WindowAdjustments();
        public abstract void ComboBoxAdjustment();
        #endregion

        #region abstracts buttons (save / back)
        public abstract void Btn_save_Click(object sender, RoutedEventArgs e);
        public abstract void Btn_back_Click(object sender, RoutedEventArgs e);
        #endregion
    }
}
