using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task.Domain.Entities;

namespace Task.WebUI.Models
{
    public class ArtAdd
    {
        public Article Article {
            get
            {
                //Article.Tags = Tags_Line.Split(new char)

                return Article;
            }
            set { Article = value; }
            }
        public string Tags_Line { get; set; }
    }
}