using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace IMBD.Helper
{
    static class PosterData
    {
        public static string GetPosterPath()
        {
            return ConfigurationManager.AppSettings["Path"];
        }

    }
}