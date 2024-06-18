using Avalonia.Controls;

using AvaloniaApplication1.ViewModels;

namespace AvaloniaApplication1.Views
{
    public partial class InputDialog : UserControl
    {
        public InputDialog()
        {
            InitializeComponent();
            DataContext = new InputDialogViewModel();
        }
    }
}
