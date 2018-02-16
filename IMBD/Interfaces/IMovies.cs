using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMBD.Models;
using System.IO;
using System.Web;

namespace IMBD.Interfaces
{
    interface IMovies
    {
        List<Movies> ListMovie();
        int AddMovie(Movies movie, HttpPostedFileBase File);

        void ModifyMovie(Movies movie, List<int> actorids, HttpPostedFileBase File);

        void DeleteMovie(Movies movie);
    }
}
