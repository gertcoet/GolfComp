using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolfTourDAL.Model
{
    public class Hole
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HoleId { get; set; }

        [Required] public int HoleNumber { get; set; }

        [Required] public int Stroke { get; set; }

        [Required] public int Par { get; set; }

        [ForeignKey("GolfCourseId")] public virtual GolfCourse GolfCourse { get; set; }
    }
}