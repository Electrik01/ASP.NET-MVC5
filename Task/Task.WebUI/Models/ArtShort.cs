using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task.Domain.Entities;
using Task.Domain.Pagination;

namespace Task.WebUI.Models
{
    public class ArtShort
    {
        public IEnumerable<Article> Articles { get; set; }
        public PageInfo PageInfo { get; set; }
        public ArtShort(IEnumerable<Article> articles, int pagenumber)
        {
            int pageSize = 4;

            Articles = articles.Skip((pagenumber - 1) * pageSize)
                                    .Take(pageSize);
            PageInfo = new PageInfo { PageNumber = pagenumber, PageSize = pageSize, TotalItems =articles.Count() };
            foreach (Article article in Articles)
                article.Text = article.Text.Substring(0, 200);

        }
    }
}