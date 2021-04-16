using Runpath.Models;
using System.Collections.Generic;

namespace Runpath.Helper
{
    public interface IAPIProvider
    {
        IEnumerable<UserPhotos> CombineData(int? userId = null);
        List<Album> GetAlbumData(int? userId = null);
        List<Photo> GetPhotoData();
    }
}
