using System.Collections.Generic;
using System.Threading.Tasks;

namespace CPMobile.Models
{
    public interface ICPFeeds
    {
        //Task Init();

        Task<CPFeed> GetArticleAsync(int page, int cveCategoria);

        Task<CPFeed> GetForumAsync();

        Task<bool> GetAccessToken(string username, string password);

        Task<string> GetCategorias();

        Task<MyProfile> GetMyProfile();

        Task<CPFeed> MyArticles(int page);

        Task<CPFeed> GetForumAsync(int tag);
    }

}
