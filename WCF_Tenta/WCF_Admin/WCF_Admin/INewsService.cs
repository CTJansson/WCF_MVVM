using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Security;

namespace WCF_Admin
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "INewsService" in both code and config file together.
    [ServiceContract]
    public interface INewsService
    {
        [OperationContract]
        bool UserAuthentication(string username, string password);

        [OperationContract]
        Models.AdminAccount GetLoggedInAdminAccount(string username);

        [OperationContract]
        Models.AdminNewsPosts[] GetAllNewsPosts();

        [OperationContract]
        Models.AdminNewsPosts[] GetFilteredNewsPosts(int id);

        [OperationContract]
        bool CreateNewsPost(Models.AdminNewsPosts newspost);

        [OperationContract]
        Models.NewsCategories[] GetEveryCategory();

        [OperationContract]
        Models.AdminNewsPosts[] GetAuthorNewsposts(int id);

        [OperationContract]
        void EditNewsPost(int id, Models.AdminNewsPosts post);

        [OperationContract]
        void DeleteNewsPost(int id);
    }
}
