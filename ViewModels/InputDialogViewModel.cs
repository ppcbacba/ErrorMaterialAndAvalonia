using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;

using AvaloniaApplication1.Views;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Material.Dialog;
using Material.Dialog.Enums;
using Material.Dialog.Icons;

namespace AvaloniaApplication1.ViewModels
{
    public partial class InputDialogViewModel:ObservableObject
    {
        public MainWindow _window;
        private string _inputText;
        public string InputText
        {
            get => _inputText;
            set => SetProperty(ref _inputText, value);
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
        [ObservableProperty]
        private string _result;
        [RelayCommand]
        public async void ConfirmDialog()
        {
            //var result=await LoginDialog();
            var result = await DoConfirmDialog();
            //_result = $"Result: {result.Item1}, Account: {result.Item2}, Password: {result.Item3}";
        }
        private async Task<(string,string,string)> LoginDialog()
        {
            _window = getCurrentWindow();
            var result = await DialogHelper.CreateTextFieldDialog(new TextFieldDialogBuilderParams
            {
                ContentHeader = "Authentication required.",
                SupportingText = "Please login before any action.",
                StartupLocation = WindowStartupLocation.CenterOwner,
                DialogHeaderIcon = DialogIconKind.Blocked,
                Borderless = true,
                Width = 400,
                TextFields = new[] {
                new TextFieldBuilderParams {
                    HelperText = "* Required",
                    Classes = "outline",
                    Label = "Account",
                    MaxCountChars = 24,
                },
                new TextFieldBuilderParams {
                    HelperText = "* Required",
                    Classes = "outline",
                    Label = "Password",
                    MaxCountChars = 64,
                    FieldKind = TextFieldKind.Masked,
                }
            },
                DialogButtons = new[] {
                new DialogButton {
                    Content = "CANCEL",
                    Result = "cancel",
                    IsNegative = true
                },
                new DialogButton {
                    Content = "LOGIN",
                    Result = "login",
                    IsPositive = true
                }
            }
            }).ShowDialog(_window);
            var res = (result.GetResult, result.GetFieldsResult()[0].Text, result.GetFieldsResult()[1].Text);
            return res;
            //yield return $"Result: {result.GetResult}";

            //if (result.GetResult != "login")
            //    yield break;
            //var t = result.GetFieldsResult()[0].Text;
            //yield return $"Account: {result.GetFieldsResult()[0].Text}";
            //yield return $"Password: {result.GetFieldsResult()[1].Text}";
        }
        public async Task<(string,string,string)> DoConfirmDialog()
        {
            _window= getCurrentWindow();
            var dialog = DialogHelper.CreateTextFieldDialog(new TextFieldDialogBuilderParams
            {
                ContentHeader = "Enter your name",
                SupportingText = "Please enter your name",
                StartupLocation = WindowStartupLocation.CenterOwner,
                DialogHeaderIcon = DialogIconKind.Info,
                TextFields = new[]
                {
                    new TextFieldBuilderParams
                    {
                        HelperText = "* Required",
                        Classes = "outline",
                        Label = "Account",
                        MaxCountChars = 24,

                    },
                    new TextFieldBuilderParams
                    {
                        HelperText = "* Required",
                        Classes = "outline",
                        Label = "Password",
                        MaxCountChars = 64,
                        FieldKind = TextFieldKind.Masked,

                    }
                },

                DialogButtons = new[]
                {
                    new Material.Dialog.DialogButton
                    {
                        Content = "CANCEL",
                        Result = "cancel"
                    },
                    new Material.Dialog.DialogButton()
                    {
                        Content = "OK",
                        Result = "ok"
                    }
                }
            });
            TextFieldDialogResult result = await dialog.ShowDialog(_window);
            if(result.GetResult== "ok")
            {
                return (result.GetResult, result.GetFieldsResult()[0].Text, result.GetFieldsResult()[1].Text);
            }
            else
            {
                return new (result.GetResult,"","");
            }
            
            //yield return $"Result: {result.GetResult}";

            //if (result.GetResult != "login")
            //    yield break;
            //var t = result.GetFieldsResult()[0].Text;
            //yield return $"Account: {result.GetFieldsResult()[0].Text}";
            //yield return $"Password: {result.GetFieldsResult()[1].Text}";

        }
    }
}
