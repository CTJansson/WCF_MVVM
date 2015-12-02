using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF_Admin.Models
{
    public class AdminNewsPosts
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public string Tags { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public string WrittenBy { get; set; }
        public Models.AdminAuthor Author { get; set; }
        public DateTime Date { get; set; }
    }
}