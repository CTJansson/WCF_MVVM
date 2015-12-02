using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCF_Admin.Models
{
    [DataContract]
    public class AdminAccount
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public int AuthorId { get; set; }
        [DataMember]
        public AdminAuthor Author { get; set; }
    }
}
