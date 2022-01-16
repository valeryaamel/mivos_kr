using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xamarin_blogges.Models;
using xamarin_blogges.Models.Input;
using xamarin_blogges.Services;

namespace xamarin_blogges.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserComments : ContentPage
    {
        private readonly static IRestServices _restServices = new RestServices();
        private int _id = 0;
        private Comments comments = new Comments();
        public UserComments()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            CommentsList.ItemsSource = (System.Collections.IEnumerable)BindingContext;
        }

        private async Task ImageButton_Clicked(object sender, EventArgs e)
        {
            
        }

        private void CommentsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            comments = (Comments)e.SelectedItem;
            _id = comments.Id;
        }

        private async Task ImageButton_Clicked_1(object sender, EventArgs e)
        {
            
        }

        private async void ImageButton_Clicked_2(object sender, EventArgs e)
        {
            if (_id == 0)
            {
                DisplayAlert("Ошибка","Сначала выберите комментарий","Ок");
                return;
            }
            bool a = await _restServices.DeleteComment(_id);
            tmp.user.Comments.Remove(comments);
            Navigation.PopAsync();
            await Navigation.PushAsync(new UserComments
            {
                BindingContext = tmp.user.Comments
            });
        }
    }
}