using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IResturantRepository
    {
        void Add(Resturant resturant);
        void Delete(Resturant resturant);
        void Update(Resturant resturant);
   
    }
}
