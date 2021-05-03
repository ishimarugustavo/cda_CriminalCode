using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace CriminalCode.API.Models
{
    public class Status : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}