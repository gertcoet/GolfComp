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

        [ForeignKey("CourseRoudId")]
        public virtual CourseRound CourseRoud { get; set; }

        public int CourseHoleId { get; set; }
        [ForeignKey("CourseHoleId")]
        public virtual CourseHole CourseHole { get; set; }

        public int GolferId { get; set; }
        [ForeignKey("GolferId")]
        public virtual Golfer Golfer { get; set; }

        public int Strokes { get; set; }
    }
}