using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiSaveImage.Models
{
    public class Person
    {
        [Key]
        public int  Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string  Name { get; set; }
        
        [Column(TypeName = "nvarchar(100)")]
        public string Family { get; set; }
        
        [Column(TypeName = "nvarchar(100)")]
        public string Phone { get; set; }
        
        [Column(TypeName = "nvarchar(100)")]
        public string ImageName { get; set; }

    }
}
