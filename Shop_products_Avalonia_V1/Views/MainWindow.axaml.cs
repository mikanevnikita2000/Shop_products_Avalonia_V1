using Avalonia.Controls;

namespace Shop_products_Avalonia_V1.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public ViewModels.MainWindowViewModel MainWindowViewModel
        {
            get => default;
            set
            {
            }
        }
    }
}
