using Demo.DAL._Data.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL._Data.Model
{
    public class Category : BaseEntity<int>
    {
        public ICollection<Game> Games { get; set; } = new List<Game>();    
    }
}
