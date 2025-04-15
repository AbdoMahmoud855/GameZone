using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL._Data.Model.Base
{
    public abstract class BaseEntity<TKey> where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; }
        [MaxLength(100)]
        public required string Name { get; set; }
    }
}
