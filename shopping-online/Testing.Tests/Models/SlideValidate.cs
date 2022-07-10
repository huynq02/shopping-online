using shopping_online.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.Tests.Models
{
    class SlideValidate : ISlideValidate
    {
        public string CheckInputDescription(Slide slide)
        {
            if (slide.slide_descriptions == "")
            {
                return "Descriptions is not empty";
            } else if (slide.slide_descriptions.Length < 5 || slide.slide_descriptions.Length >15000)
            {
                return "Use 5-15000 characters";
            } else
            {
                return "True";
            }
        }

        public string CheckInputImage(Slide slide)
        {
            if (slide.slide_imageslide == "")
            {
                return "Imageslide is not empty";
            } else
            {
                return "True";
            }
        }

        public string CheckInputTitle(Slide slide)
        {
            if (slide.slide_title == "")
            {
                return "Title is not empty";
            }
            else if (slide.slide_title.Length < 10 || slide.slide_title.Length > 150)
            {
                return "Use 10-150 characters";
            }
            else
            {
                return "True";
            }
        }
        public string CheckUInputCreateBy(Slide slide)
        {
            if (slide.slide_createby == "")
            {
                return "CreateBy is not empty";
            }
            else if (slide.slide_createby.Length < 5 || slide.slide_createby.Length > 70)
            {
                return "Use 5-70 characters";
            }
            else
            {
                return "True";
            }
        }

    }
}
