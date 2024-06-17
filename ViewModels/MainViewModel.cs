using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls;
using AvaloniaApplication1.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Avalonia;
using Avalonia.Platform;
using Material.Dialog;
using Material.Dialog.Icons;
using System;
using System.Threading.Tasks;

namespace AvaloniaApplication1.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private  MainWindow? _window;
    public bool IsDialogsAvailable { get; }
    public MainViewModel()
    {

        IsDialogsAvailable = true;
    }

    private static MainWindow getCurrentWindow()
    {
        if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime app)
        {
            if (app.MainWindow is MainWindow w)
            {
                return w;
            }
        }
        return null;
    }

    [RelayCommand]
    public async void ConfirmDialog()
    {
        if (_window == null) _window=getCurrentWindow();
        var result =await DialogHelper.CreateAlertDialog(new AlertDialogBuilderParams
        {
            ContentHeader = "Confirm action",
            SupportingText = "Are you sure to DELETE 20 FILES?",
            StartupLocation = WindowStartupLocation.CenterOwner,
            NegativeResult = new DialogResult("cancel"),
            DialogHeaderIcon = DialogIconKind.Help,
            DialogButtons = new[]
               {
                new DialogButton
                {
                    Content = "CANCEL",
                    Result = "cancel"
                },
                new DialogButton(){
                    Content = "DELETE",
                    Result = "delete"
                }
            }
        }).ShowDialog(_window);
        Console.WriteLine(result);
    }

}
