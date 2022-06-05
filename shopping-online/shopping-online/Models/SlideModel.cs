using PagedList;
using shopping_online.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shopping_online.Models
{
    public class SlideModel
    {
        public IPagedList<Slide> slide { get; set; }
    }
}