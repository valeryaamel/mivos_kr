using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xamarin_blogges.Models;
using xamarin_blogges.Models.Input;
using xamarin_blogges.Models.Output;
using xamarin_blogges.Services;

namespace xamarin_blogges.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPosts : ContentPage
    {
        private readonly static IRestServices _restServices = new RestServices();
        private int _id;
        private Posts post = new Posts();
        public UserPosts()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            PostsList.ItemsSource = (System.Collections.IEnumerable)BindingContext;
        }

        private void PostsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            post = e.SelectedItem as Posts;
            _id = post.Id;
        }

        private async void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            if (_id == 0)
            {
                DisplayAlert("Ошибка", "Сначала выберите пост", "Ок");
                return;
            }
            bool a = await _restServices.DeletePost(_id);
            tmp.user.Posts.Remove(post);
            Navigation.PopAsync();
            await Navigation.PushAsync(new UserPosts
            {
                BindingContext = tmp.user.Posts
            });
        }
    }
}