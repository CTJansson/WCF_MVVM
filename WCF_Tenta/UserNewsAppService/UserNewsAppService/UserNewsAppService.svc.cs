using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace UserNewsAppService
{
    public class UserNewsAppService : IUserNewsAppService
    {
        NewsAppEnts ctx;

        public UserNewsAppService()
        {
            ctx = new NewsAppEnts();
        }

        public Models.UserNewsPost[] GetAllNewsPosts()
        {
            Models.UserNewsPost[] temp = ctx.NewsPosts
                .Select(np => new Models.UserNewsPost
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

        public Models.UserNewsPost[] GetFilteredNewsPosts(int id)
        {
            Models.UserNewsPost[] temp = ctx.NewsPosts
                .Where(np => np.CategoryId == id)
                .Select(np => new Models.UserNewsPost
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

        public bool Subscribe(string email)
        {
            if (email != null && email.Contains('@') && email.Contains('.'))
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
            if (email != null && email.Contains('@') && email.Contains('.'))
            {
                SubscribedEmail sub = ctx.SubscribedEmails.FirstOrDefault(se => se.Email == email);

                if (sub != null)
                {           
                    ctx.SubscribedEmails.Remove(sub);
                    ctx.SaveChanges();

                    return true;
                }
            }

            return false;
        }
    }
}
