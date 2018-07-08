using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolfTourDAL.Model
{
    [Table("Golfer")]
    public class Golfer
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GolferId { get; set; }

        [StringLength(50)] public string Name { get; set; }

        [StringLength(50)] public string Surname { get; set; }

        [StringLength(200)] public string Email { get; set; }
       
        public virtual ICollection<Hole> Hole { get; set; } = new HashSet<Hole>();
    }
}