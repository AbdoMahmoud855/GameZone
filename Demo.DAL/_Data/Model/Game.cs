using Demo.DAL._Data.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL._Data.Model
{
    public class Game : BaseEntity<int>
    {

   
        [Required]
        [MaxLength(100000)]
        public string Description { get; set; } = string.Empty;
        [Required]
        [MaxLength(500)]
        public string ImageName {  get; set; } = string.Empty;  
        public int CategoryId { get; set; }
        public Category? category { get; set; } 
        public ICollection<GameDevice> Devices { get; set; } = new List<GameDevice>();



    }
}
