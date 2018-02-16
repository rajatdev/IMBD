using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace IMBD.Helper
{
    static class Helper
    {
        public static string GetPosterPath()
        {
            return ConfigurationManager.AppSettings["Path"];
        }
        public static string GetMoviesApiPath()
        {
            return ConfigurationManager.AppSettings["Imdb_Api"];
        }
        public static string GetMoviesApiKey()
        {
            return ConfigurationManager.AppSettings["Imdb_Key"];
        }
    }
}