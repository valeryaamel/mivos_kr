using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xamarin_blogges.Models.Input;

namespace xamarin_blogges.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostPage : ContentPage
    {
        Post post = new Post();
        public PostPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            post = (Post)BindingContext;

            Label cl = new Label();
            cl.Text = "Категории: ";
            cl.FontSize = 13;
            cl.FontAttributes = FontAttributes.Bold;
            Categories.Children.Add(cl);
            foreach(var c in post.Categories)
            {
                Label label = new Label();
                label.Text = $"{c.Name}; ";
                label.FontSize = 13;
                Categories.Children.Add(label);
            }

            Label ll = new Label();
            ll.Text = "Языки: ";
            ll.FontSize = 13;
            ll.FontAttributes = FontAttributes.Bold;
            Languages.Children.Add(ll);
            foreach(var l in post.Languages)
            {
                Label label = new Label();
                label.Text = $"{l.Name}; ";
                label.FontSize = 13;
                label.FontAttributes = FontAttributes.Italic;
                Languages.Children.Add(label);
            }

            Comments.Text = $"Комментарии({post.Comments.Count()})";
        }

        private async void Comments_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CommentsPage
            {
                BindingContext = post.Comments as List<Comment>
            });
        }
    }
}