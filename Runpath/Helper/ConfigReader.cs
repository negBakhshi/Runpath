using System.Configuration;

namespace Runpath.Helper
{
    /// <summary>
    /// Reads the data by key from the Web.Config file
    /// </summary>
    public static class ConfigReader
    {
        public static string AlbumsURL => ConfigurationManager.AppSettings["Albums_Url"];
        public static string PhotosURL => ConfigurationManager.AppSettings["Photos_Url"];
    }
}