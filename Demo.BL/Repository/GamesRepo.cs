using Demo.BL.Interface;
using Demo.DAL._Data.Context;
using Demo.DAL._Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Repository
{
    public class GamesRepo : GenericRepository<Game>,IGamesRpo
    {
        public GamesRepo(StoreContext context) : base(context)
        {
        }
    }
}
