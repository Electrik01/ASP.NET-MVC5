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
        void Save(Poll r);
        void Save(Review r);
    }
}
