using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMBD.Models
{
    public class Actors
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public DateTime Dob { get; set; }
        public string Bio { get; set; }
    }
}