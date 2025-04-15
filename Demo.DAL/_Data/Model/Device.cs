using Demo.DAL._Data.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL._Data.Model
{
    public class Device : BaseEntity<int>
    {
        [MaxLength(100)]
        public required string Icon { get; set; }
    }
}
