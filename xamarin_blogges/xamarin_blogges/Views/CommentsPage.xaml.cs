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
    public partial class CommentsPage : ContentPage
    {
        public CommentsPage()
        {
            InitializeComponent();
        }

        private readonly static IRestServices _restServices = new RestServices();

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (tmp.UserId == 0)
                sent.IsEnabled = false;
            else sent.IsEnabled = true;

            List<Comment> comments = (List<Comment>)BindingContext;

            foreach (Comment comment in comments)
            {
                StackLayout stackLayout = new StackLayout();
                Label label = new Label();
                label.Text = comment.Title;
                label.FontAttributes = FontAttributes.Bold;
                label.FontSize = 20;
                label.TextColor = Color.FromHex("#9575CD");
                Label label1 = new Label();
                label1.Text = comment.Text;
                label1.FontAttributes = FontAttributes.Italic;
                label1.FontSize = 18;
                Label label2 = new Label();
                label2.Text = comment.Username;
                label2.FontAttributes = FontAttributes.Bold;
                label2.FontSize = 16;
                stackLayout.Orientation = StackOrientation.Vertical;
                stackLayout.Children.Add(label);
                stackLayout.Children.Add(label1);
                stackLayout.Children.Add(label2);

                scroll.Children.Add(stackLayout);
            }
        }

        private async void sent_Clicked(object sender, EventArgs e)
        {
            var comment = new Comments()
            {
                Id = 0,
                Title = title.Text,
                Text = text.Text,
                Date = DateTime.Now,
                PostId = tmp.PostId,
                UserId = tmp.UserId
            };

            await _restServices.AddComment(comment);

            StackLayout stackLayout = new StackLayout();
            Label label = new Label();
            label.Text = comment.Title;
            label.FontAttributes = FontAttributes.Bold;
            label.FontSize = 20;
            label.TextColor = Color.FromHex("#9575CD");
            Label label1 = new Label();
            label1.Text = comment.Text;
            label1.FontAttributes = FontAttributes.Italic;
            label1.FontSize = 18;
            Label label2 = new Label();
            label2.Text = tmp.user.Login;
            label2.FontAttributes = FontAttributes.Bold;
            label2.FontSize = 16;
            stackLayout.Orientation = StackOrientation.Vertical;
            stackLayout.Children.Add(label);
            stackLayout.Children.Add(label1);
            stackLayout.Children.Add(label2);

            scroll.Children.Add(stackLayout);
        }
    }
}