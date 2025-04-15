using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Interface
{
    public interface IUnitOfWork
    {
        public IGamesRpo gamesRpo { get; set; }
        public  Task<int> SaveChanges();
    }
}
