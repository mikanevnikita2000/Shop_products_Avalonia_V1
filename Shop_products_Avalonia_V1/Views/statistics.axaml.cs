using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Shop_products_Avalonia_V1.Views
{
    public partial class statistics : Window
    {
        public statistics()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
