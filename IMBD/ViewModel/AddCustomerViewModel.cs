using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMBD.Models;

namespace IMBD.ViewModel
{
    public class AddCustomerViewModel
    {
        public List<Actors> Act { get; set; }
        public Movies mo;
    }
}