using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Runpath.Models
{
    /// <summary>
    /// This Class has been used for storing each Albums information
    /// </summary>
    public class Album
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
    }
}