using Runpath.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Runpath.Helper
{
    public class APIProvider : IAPIProvider
    {
        public List<Album> GetAlbumData(int? userId = null)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var baseUrl = ConfigReader.AlbumsURL;

                var response = client.GetAsync(userId.HasValue ? baseUrl + $"?userId={userId}" : baseUrl).Result;

                List<Album> Albums;

                if (response.IsSuccessStatusCode)
                {
                    Albums = response.Content.ReadAsAsync<List<Album>>().Result;
                }
                else
                {
                    //log response status here.. 
                    var error = new HttpResponseMessage()
                    {
                        Content = new StringContent(response.StatusCode.ToString()),
                        ReasonPhrase = response.ReasonPhrase
                    };
                    throw new HttpResponseException(error);
                }
                return Albums;

            }
        }
        public List<Photo> GetPhotoData()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var url = ConfigReader.PhotosURL;
                var response = client.GetAsync(url).Result;

                List<Photo> Photos;

                if (response.IsSuccessStatusCode)
                {
                    Photos = response.Content.ReadAsAsync<List<Photo>>().Result;
                }
                else
                {
                    //log response status here.. 
                    var error = new HttpResponseMessage()
                    {
                        Content = new StringContent(response.StatusCode.ToString()),
                        ReasonPhrase = response.ReasonPhrase
                    };
                    throw new HttpResponseException(error);
                }
                return Photos;

            }
        }
        /// <summary>
        /// Calls both APIs and combine all the data
        /// </summary>
        /// <returns>List of Users Photos</returns>
        public IEnumerable<UserPhotos> CombineData(int? userId = null)
        {
            var albums = GetAlbumData(userId);
            var photos = GetPhotoData();
            var result = new List<UserPhotos>();

            foreach (var album in albums)
            {
                result.Add(new UserPhotos
                {
                    UserId = album.UserId,
                    Id = album.Id,
                    Titel = album.Title,
                    Photos = photos.Where(p => p.AlbumId == album.Id)
                });
            }

            return result;
        }
    }
}