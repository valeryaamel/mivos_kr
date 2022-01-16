using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using xamarin_blogges.Models.Input;
using xamarin_blogges.Models.Output;

namespace xamarin_blogges.Services
{
    public interface IRestServices
    {
        //Post
        Task<List<Post>> GetPostsAsync();
        Task<bool> SentPost(AddPost post);
        Task<bool> DeletePost(int id);

        //User
        Task<User> Registration(Registration registration);
        Task<User> SignIn(string username, string password);

        //Comment
        Task<Comments> AddComment(Comments comment);
        Task<bool> DeleteComment(int id);

        //Category
        Task<List<Category>> GetCategoriesAsync();

        //Language
        Task<List<Language>> GetLanguagesAsync();
    }
}
