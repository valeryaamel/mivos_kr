using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xamarin_blogges.Models;

namespace xamarin_blogges.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {

        public UserPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            post.Text = $"Посты({tmp.user.Posts.Count()})";
            com.Text = $"Комментарии({tmp.user.Comments.Count()})";
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            tmp.UserId = 0;
            await Navigation.PopAsync();
        }

        private async void com_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserComments
            {
                BindingContext = tmp.user.Comments
            });
        }

        private async void post_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserPosts
            {
                BindingContext = tmp.user.Posts
            });
        }
    }
}