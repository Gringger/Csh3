using System.Windows;
using FontAwesome.WPF;

namespace Lab03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ImageAwesome _loader;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new AddPersonView(ShowLoader);
        }

        private void ShowLoader(bool isShow)
        {
            LoadHelp.OnRequestLoader(MainGrid, ref _loader, isShow);
        }
    }
}
