using Newtonsoft.Json;
using System.Collections.Generic;

namespace Runpath.Models
{
    /// <summary>
    /// This Class has been used for storing each User's photos.
    /// </summary>
    public class UserPhotos
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("titel")]
        public string Titel { get; set; }
        [JsonProperty("photos")]
        public IEnumerable<Photo> Photos { get; set; }
    }
}