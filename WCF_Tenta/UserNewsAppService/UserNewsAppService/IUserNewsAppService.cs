using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UserNewsAppService.Models;

namespace UserNewsAppService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserNewsAppService" in both code and config file together.
    [ServiceContract]
    public interface IUserNewsAppService
    {
        [OperationContract]
        Models.UserNewsPost[] GetAllNewsPosts();

        [OperationContract]
        Models.UserNewsPost[] GetFilteredNewsPosts(int id);

        [OperationContract]
        bool Subscribe(string email);

        [OperationContract]
        bool Unsubscribe(string email);
    }
}
