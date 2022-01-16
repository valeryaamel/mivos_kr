using Android.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using xamarin_blogges.Models;
using xamarin_blogges.Models.Input;
using xamarin_blogges.Services;
using xamarin_blogges.Views;

namespace xamarin_blogges
{
    public partial class MainPage : ContentPage
    {
        private readonly static IRestServices _restServices = new RestServices();
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (tmp.UserId == 0)
                addbtn.IsEnabled = false;
            else addbtn.IsEnabled = true;

            tmp.posts = await _restServices.GetPostsAsync();

            PostsList.ItemsSource = tmp.posts;
        }

        private async void PostsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Post post = (Post)e.SelectedItem;
            tmp.PostId = post.Id;
            await Navigation.PushAsync(new PostPage
            {
                BindingContext = post
            });
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            if (tmp.UserId == 0)
            {
                await Navigation.PushAsync(new RegistrationPage());
            }
            else
            {
                await Navigation.PushAsync(new UserPage
                {
                    BindingContext = tmp.user
                });
            }
            
        }

        private async void addbtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPostPage());
        }
    }
}
