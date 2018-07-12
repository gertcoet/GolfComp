using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolfTourDAL.Model
{
    public partial class CourseRoundHole
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CourseRoudHoleId { get; set; }

        public virtual ICollection<CourseRound> CourseRound { get; set; } = new HashSet<CourseRound>();

        //public int CourseHoleId { get; set; }
        //[ForeignKey("CourseHoleId")]
        //public virtual CourseHole CourseHole { get; set; }

        public int Strokes { get; set; }
    }
}