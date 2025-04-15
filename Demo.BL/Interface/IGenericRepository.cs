using Demo.DAL._Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Interface
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAll(bool nonTracking);
        Task<T> GetById(int id);
        Task Add(T item);
        void Update(Game item);
        void Delete(T item);
    }
}
