using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMBD.Models
{
    public class Actor_Movies
    {
        public int Id { get; set; }
        public virtual int MovieId { get; set; }
        public virtual int ActorId { get; set; }
    }
}