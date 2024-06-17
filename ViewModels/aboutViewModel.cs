using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls;
using AvaloniaApplication1.Views;
using CommunityToolkit.Mvvm.Input;
using Material.Dialog.Icons;
using Material.Dialog;
using Avalonia;

namespace AvaloniaApplication1.ViewModels
{
    public partial class aboutViewModel:ViewModelBase
    {
        private readonly MainWindow? _window;
        public bool IsDialogsAvailable { get; }
        public aboutViewModel()
        {
            if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime app)
            {
                if (app.MainWindow is not MainWindow w)
                    return;

                _window = w;
                IsDialogsAvailable = true;
            }
            IsDialogsAvailable = true;
        }


        [RelayCommand]
        public async Task ConfirmDialog()
        {
            if (_window == null) return;
            var result = await DialogHelper.CreateAlertDialog(new AlertDialogBuilderParams
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
}
