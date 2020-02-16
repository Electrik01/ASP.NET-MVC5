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
        public string Tags { get; set; }


        public IEnumerable<Review> Reviews { get; set; }
    }
}
