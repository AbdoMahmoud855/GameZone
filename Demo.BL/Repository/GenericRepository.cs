using Demo.BL.Interface;
using Demo.DAL._Data.Context;
using Demo.DAL._Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly StoreContext _context;

        public GenericRepository(StoreContext context)
        {
            _context = context;
        }
        public async Task Add(T item)
        {
    await  _context.AddAsync(item);
        }

        public  void Delete(T item)
        {
         _context.Remove(item);
        }

        public async Task<IEnumerable<T>> GetAll(bool nonTracking)
        {

            return nonTracking == true ? (IEnumerable<T>) await _context.Set<Game>().Include(p=>p.category).Include(p=>p.Devices).ThenInclude(d=>d.Device).AsNoTracking().ToListAsync() : (IEnumerable<T>)await _context.Set<Game>().Include(p => p.category).Include(p => p.Devices).ToListAsync();
        }

        public async Task<T?> GetById(int id)
        {
            return (T?)(object?)await _context.games.Include(p => p.Devices).ThenInclude(p=>p.Device).SingleOrDefaultAsync(p => p.Id == id);
        }

        public void Update(Game item)
        {

            _context.games.Update(item);
        }
    }
}
