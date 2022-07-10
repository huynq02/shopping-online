
using shopping_online.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.Tests.Models
{
    interface ISlideValidate
    {
        string CheckInputTitle(Slide slide);
        string CheckUInputCreateBy(Slide slide);
        string CheckInputImage(Slide slide);
        string CheckInputDescription(Slide slide);
    }
}
