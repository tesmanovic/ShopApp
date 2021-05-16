using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Models
{
    [Table("Stage")]
    public class DStage
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName ="NVARCHAR(100)")]
        public string Name { get; set; }
        [Column(TypeName ="NVARCHAR(MAX)")]
        public string Description { get; set; }
        [Column(TypeName ="NVARCHAR(100)")]
        public string ImageName { get; set; }
        [ForeignKey("FestivalId")]
        [Required]
        public DFestival Festival { get; set; }
        public ICollection<DTicket> Tickets { get; set; }
    }
}
