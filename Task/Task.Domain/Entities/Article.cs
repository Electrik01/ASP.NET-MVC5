using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Domain.Entities
{
    public class Article
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime Data { get; set; }
        public bool IsShow { get; set; }
        public bool IsDel { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
