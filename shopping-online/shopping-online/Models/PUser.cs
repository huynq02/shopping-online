using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace shopping_online.Models
{
    public class PUser
    {
        [MetadataType(typeof(UserMetaData))]
        public partial class User
        {
        }
        public class UserMetaData
        {
            [Remote("IsUserNameAvailable", "Home", HttpMethod = "POST", ErrorMessage = "UserName already in use.")]
            public string UserName { get; set; }
        }
    }
}