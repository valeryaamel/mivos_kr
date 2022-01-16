using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xamarin_blogges.Models;
using xamarin_blogges.Models.Input;
using xamarin_blogges.Models.Output;
using xamarin_blogges.Services;

namespace xamarin_blogges.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }


        private readonly static IRestServices _restServices = new RestServices();

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if(e.Value == true)
            {
                email.IsVisible = true;
                confirm.IsVisible = true;
                btn.Text = "Зарегестрироваться";
            }
            else
            {
                email.IsVisible = false;
                confirm.IsVisible = false;
                btn.Text = "Войти";
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (cb.IsChecked == true)
            {
                Registration registration = new Registration()
                {
                    Login = login.Text,
                    Email = email.Text,
                    Password = password.Text,
                    ConfirmPassword = confirm.Text
                };
                tmp.user = await _restServices.Registration(registration);
                tmp.UserId = tmp.user.Id;
                Navigation.PopAsync();
                await Navigation.PushAsync(new UserPage
                {
                    BindingContext = tmp.user
                });
            }
            else
            {
                tmp.user = await _restServices.SignIn(login.Text, password.Text);
                tmp.UserId = tmp.user.Id;
                Navigation.PopAsync();
                await Navigation.PushAsync(new UserPage
                {
                    BindingContext = tmp.user
                });
            }
        }
    }
}