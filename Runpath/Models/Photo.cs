using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Runpath.Models
{
    /// <summary>
    /// This Class has been used for storing each photos information
    /// </summary>

    public class Photo
    {
        public int AlbumId { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("thumbnailUrl")]
        public string ThumbnailUrl { get; set; }

        public bool ShouldSerializeAlbumId()
        {
            return false;
        }
    }
}