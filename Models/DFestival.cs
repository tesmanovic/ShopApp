using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Models
{
    [Table("Festival")]
    public class DFestival
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName ="NVARCHAR(100)")]
        public string Name { get; set; }
        [Column(TypeName ="NVARCHAR(MAX)")]
        public string Description { get; set; }
        [Column(TypeName ="DATETIME")]
        public DateTime DateFrom { get; set; }
        [Column(TypeName ="DATETIME")]
        public DateTime DateEnd { get; set; }
        [Column(TypeName ="NVARCHAR(100)")]
        public string ImageName { get; set; }
        public ICollection<DStage> Stages { get; set; }
    }
}
