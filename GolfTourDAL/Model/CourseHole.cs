using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolfTourDAL.Model
{
    public partial class CourseHole
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseHoleId { get; set; }

        [Required] public int HoleNumber { get; set; }

        [Required] public int Stroke { get; set; }

        [Required] public int Par { get; set; }

        [Required] public int GolfCourseId { get; set; }

        [ForeignKey("GolfCourseId")] public virtual GolfCourse GolfCourse { get; set; }
    }
}