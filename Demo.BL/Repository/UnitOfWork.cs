using Demo.BL.Interface;
using Demo.DAL._Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Repository
{
    public class UnitOfWork : IUnitOfWork ,IDisposable 
    {
        private readonly StoreContext _context;

        public UnitOfWork(StoreContext context )
        {
            
           _context = context;
            gamesRpo=new GamesRepo(_context);
        }
        public IGamesRpo gamesRpo { get ; set ; }

        public async Task<int> SaveChanges()
        => await _context.SaveChangesAsync();
        public void Dispose()
        =>_context.Dispose();
    }
}
