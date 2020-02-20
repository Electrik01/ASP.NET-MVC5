using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Domain.Entities;

namespace Task.Domain.Repository
{
    public interface IRepository
    {
        IEnumerable<Review> Reviews();
        IEnumerable<Article> Articles();
        IEnumerable<Poll> Polls();
        IEnumerable<Tag> Tags();
        void Save(Poll r);
        void Del(Article r);

        void Edit(Article r);
        void Save(Review r);
        void Save(Article r);
        void Save(Tag r);
        void SaveChanges();
    }
}
