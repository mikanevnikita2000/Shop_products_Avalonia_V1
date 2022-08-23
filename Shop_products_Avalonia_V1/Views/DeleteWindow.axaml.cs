using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Shop_products_Avalonia_V1.Views
{
    public partial class DeleteWindow : Window
    {
        public DeleteWindow()
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
