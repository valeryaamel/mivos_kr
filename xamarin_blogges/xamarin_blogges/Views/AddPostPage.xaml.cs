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
    public partial class AddPostPage : ContentPage
    {
        private readonly static IRestServices _restServices = new RestServices();
        private List<Category> categories = new List<Category>();
        private List<Language> languages = new List<Language>();
        List<int> pc = new List<int>();
        List<int> pl = new List<int>();
        public AddPostPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            categories = await _restServices.GetCategoriesAsync();
            languages = await _restServices.GetLanguagesAsync();
            foreach (var item in languages)
            {
                langs.Items.Add(item.Name);
            }
            foreach (var item in categories)
            {
                cats.Items.Add(item.Name);
            }
        }

        private void langs_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label label = new Label();
            string str = langs.Items[langs.SelectedIndex];
            label.FontAttributes = FontAttributes.Bold;
            label.Text = str + "; ";
            lang.Children.Add(label);
            int langid = languages.Where(x => x.Name == str).Select(x => x.Id).First();
            pl.Add(langid);
        }

        private void cats_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label label = new Label();
            string str = cats.Items[cats.SelectedIndex];
            label.FontAttributes = FontAttributes.Bold;
            label.Text = str + "; ";
            categ.Children.Add(label);
            int catid = categories.Where(x => x.Name == str).Select(x => x.Id).First();
            pc.Add(catid);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            AddPost post = new AddPost()
            {
                Title = posttitle.Text,
                Text = posttext.Text,
                Date = DateTime.Now,
                UserId = tmp.UserId,
                Categories = pc.ToArray(),
                Languages = pl.ToArray()
            };

            bool a = await _restServices.SentPost(post);
            if (a) await Navigation.PopAsync();
            else DisplayAlert("Ошибка", "Заполните все поля", "Ок");
        }
    }
}