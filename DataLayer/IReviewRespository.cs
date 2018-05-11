using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IReviewRepository
    {
        void Add(Review review);
        void Delete(Review review);
        void Update(Review review);
    }
}
