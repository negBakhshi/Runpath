using Runpath.Models;
using NUnit.Framework;
using Runpath.Helper;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TestProject
{
    public class Tests
    {
        [Test]
        public void ShouldReturnAllPhotos()
        {
            var api = new APIProvider();
            var result = api.CombineData() as List<UserPhotos>;

            Assert.IsNotNull(result);
            Assert.AreEqual(100, result.Count);

            Assert.AreEqual("quidem molestiae enim", result[0].Titel);
            var j1 = JsonConvert.SerializeObject(result.First().Photos.Take(5));
            var j2 = JsonConvert.SerializeObject(GetTestProducts().First().Photos);
            Assert.AreEqual(j1,j2);
        }

        private List<UserPhotos> GetTestProducts()
        {
            var userPhotos = new List<UserPhotos>();
            userPhotos.Add(new UserPhotos { UserId = 1, Id = 1, Titel = "quidem molestiae enim", Photos = GetPhotos() });


            return userPhotos;
        }

        private List<Photo> GetPhotos()
        {
            var photos = new List<Photo>();
            photos.Add(new Photo {AlbumId=1, Id = 1, Title = "accusamus beatae ad facilis cum similique qui sunt", Url = "https://via.placeholder.com/600/92c952", ThumbnailUrl = "https://via.placeholder.com/150/92c952" });
            photos.Add(new Photo { AlbumId = 1, Id = 2, Title = "reprehenderit est deserunt velit ipsam", Url = "https://via.placeholder.com/600/771796", ThumbnailUrl = "https://via.placeholder.com/150/771796" });
            photos.Add(new Photo { AlbumId = 1, Id = 3, Title = "officia porro iure quia iusto qui ipsa ut modi", Url = "https://via.placeholder.com/600/24f355", ThumbnailUrl = "https://via.placeholder.com/150/24f355" });
            photos.Add(new Photo { AlbumId = 1, Id = 4, Title = "culpa odio esse rerum omnis laboriosam voluptate repudiandae", Url = "https://via.placeholder.com/600/d32776", ThumbnailUrl = "https://via.placeholder.com/150/d32776" });
            photos.Add(new Photo { AlbumId = 1, Id = 5, Title = "natus nisi omnis corporis facere molestiae rerum in", Url = "https://via.placeholder.com/600/f66b97", ThumbnailUrl = "https://via.placeholder.com/150/f66b97" });
            return photos;
        }
    }
}