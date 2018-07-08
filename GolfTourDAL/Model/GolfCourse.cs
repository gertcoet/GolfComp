using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolfTourDAL.Model
{
    public partial class GolfCourse
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GolfCourseId { get; set; }

        [Required] public string Name { get; set; }

        public virtual ICollection<Hole> Holes { get; set; } = new HashSet<Hole>();
    }


    public partial class GolfCourse
    {
        public override string ToString()
        {
            return $"Course name : {Name} - Id : {this.GolfCourseId}";
        }
    }
}