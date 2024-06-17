using System;

using Avalonia.Controls;
using Material.Dialog.Icons;

using Material.Dialog;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia;
using AvaloniaApplication1.ViewModels;

namespace AvaloniaApplication1.Views;

public partial class MainView : UserControl
{
   
    public MainView()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
      
    }
    

}
