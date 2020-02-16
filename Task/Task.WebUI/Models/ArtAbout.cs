using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task.Domain.Entities;

namespace Task.WebUI.Models
{
    public class ArtAbout
    {
        public Article Article { get; set; }
        public string[] Tags { get; set; }
        public ArtAbout(Article a, string[] t) { Article = a; Tags = t; }
    }
}