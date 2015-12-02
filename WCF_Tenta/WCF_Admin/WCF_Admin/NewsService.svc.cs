using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using WCF_Admin.EmailService;

namespace WCF_Admin
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "NewsService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select NewsService.svc or NewsService.svc.cs at the Solution Explorer and start debugging.
    public class NewsService : INewsService
    {
        private NewsAppEnt ctx;
        private EmailServiceClient _emailClient;

        public NewsService()
        {
            ctx = new NewsAppEnt();
            _emailClient = new EmailServiceClient();
        }

        public bool UserAuthentication(string username, string password)
        {   
            Account acc = ctx.Accounts.Where(a => a.Username == username).FirstOrDefault();

            if (acc != null && acc.Password == password)
                return true;
            else
                return false;
        }

        public Models.AdminAccount GetLoggedInAdminAccount(string username)
        {
            Models.AdminAccount acc = ctx.Accounts
                .Where(a => a.Username == username)
                .Select(ac => new Models.AdminAccount 
                { 
                    Id = ac.Id,
                    AuthorId = ac.AuthorId,
                    Author = ctx.Authors
                    .Where(a => a.Id == ac.AuthorId)
                    .Select(au => new Models.AdminAuthor
                    { 
                        FirstName = au.FirstName, LastName = au.LastName, Email = au.Email, Title = au.Title
                    }).FirstOrDefault(),
                }).First();

            return acc;
        }


        public Models.AdminNewsPosts[] GetAllNewsPosts()
        {
            Models.AdminNewsPosts[] temp = ctx.NewsPosts
                .Select(np => new Models.AdminNewsPosts
                {
                    Id = np.Id,
                    Header = np.Header,
                    Content = np.Content,
                    Tags = np.Tags,
                    Date = np.Date,
                    AuthorId = np.AuthorId,
                    WrittenBy = np.WrittenBy,
                })
                .OrderByDescending(np => np.Date)
                .ToArray();

            return temp;
        }

        public Models.AdminNewsPosts[] GetFilteredNewsPosts(int id)
        {
            Models.AdminNewsPosts[] temp = ctx.NewsPosts
                .Where(np => np.CategoryId == id)
                .Select(np => new Models.AdminNewsPosts
                {
                    Header = np.Header,
                    Content = np.Content,
                    Date = np.Date,
                    Tags = np.Tags,
                    WrittenBy = np.WrittenBy,
                })
                .OrderByDescending(np => np.Date)
                .ToArray();

            return temp;
        }

        public bool CreateNewsPost(Models.AdminNewsPosts np)
        {
            NewsPost post = new NewsPost
            {
                Header = np.Header,
                Content = np.Content,
                Tags = np.Tags,
                Date = np.Date,
                CategoryId = np.CategoryId,
                AuthorId = np.AuthorId,
                WrittenBy = np.WrittenBy
            };

            if (post != null)
            {
                ctx.NewsPosts.Add(post);
                ctx.SaveChanges();
                _emailClient.SendEmailToSubscribers(np.Header);
                return true;            
            }

            return false;
        }

        public Models.NewsCategories[] GetEveryCategory()
        {
            Models.NewsCategories[] temp = ctx.Categories
                .Select(c => new Models.NewsCategories 
                { 
                    Id = c.Id,
                    Name = c.CategoryName,
                }).ToArray();

            return temp;
        }

        public Models.AdminNewsPosts[] GetAuthorNewsposts(int id)
        {
            Models.AdminNewsPosts[] temp = ctx.NewsPosts
                .Where(np => np.AuthorId == id)
                .Select(np => new Models.AdminNewsPosts
                {
                    Id = np.Id,
                    Header = np.Header,
                    Content = np.Content,
                    CategoryId = np.CategoryId,
                    AuthorId = np.AuthorId,
                    WrittenBy = np.WrittenBy,
                    Tags = np.Tags,
                    Date = np.Date,
                }).ToArray();

            return temp;
        }

        public void EditNewsPost(int id, Models.AdminNewsPosts post)
        {
            NewsPost updatedPost = ctx.NewsPosts.First(np => np.Id == id);
            updatedPost.Header = post.Header;
            updatedPost.Content = post.Content;
            updatedPost.Tags = post.Tags;
            updatedPost.CategoryId = post.CategoryId;
            ctx.SaveChanges();
        }

        public void DeleteNewsPost(int id)
        {
            NewsPost temp = ctx.NewsPosts.First(np => np.Id == id);

            ctx.NewsPosts.Remove(temp);
            ctx.SaveChanges();
        }

        public bool Subscribe(string email)
        {
            if (email.Contains('@') && email.Contains('.'))
            {
                SubscribedEmail sub = new SubscribedEmail()
                {
                    Email = email,
                };

                ctx.SubscribedEmails.Add(sub);
                ctx.SaveChanges();

                return true;
            }

            return false;
        }

        public bool Unsubscribe(string email)
        {
            SubscribedEmail sub = ctx.SubscribedEmails.Find(email);

            if (sub != null)
            {
                ctx.SubscribedEmails.Remove(sub);
                ctx.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
