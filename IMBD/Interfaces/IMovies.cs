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
        void AddMovie(Movies movie);

        void ModifyMovie(Movies movie, List<int> actorids, HttpPostedFileBase File);

        void DeleteMovie(Movies movie);
    }
}
