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
        public string search { get; set; }
        public Slide sl { get; set; }
        public List<Slide> slDis { get; set; }
        public IPagedList<Slide> slActive { get; set; }
        public IPagedList<Slide> slide { get; set; }
    }
}