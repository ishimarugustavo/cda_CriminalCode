using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace CriminalCode.API.Models
{
    public class CriminalCodes : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Decimal Penalty { get; set; }
        public int PrisonTime { get; set; }
        public Status Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public User CreateUser { get; set; }
        public  User UpdateUser { get; set; }
    }
}