using System.Windows;

namespace RxUiSplunk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(ShellViewModel shellViewModel)
        {
            InitializeComponent();

            DataContext = shellViewModel;
        }
    }
}
