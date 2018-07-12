using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace GolfTourDAL.Model
{
    public partial class GolferHole
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid GolferHoleId { get; set; }

        [Required] public int GolferId { get; set; }

        [Required] public int HoleId { get; set; }


        [ForeignKey("GolferId")] [Required] public virtual Golfer Golfer { get; set; }

        [ForeignKey("CourseHoleId")] [Required] public virtual CourseHole CourseHole { get; set; }

        public int Shots { get; set; }
        public int Score { get; set; }
    }

    public partial class GolferHole
    {
        public override string ToString()
        {
            return $"{Golfer.Name} shot {this.Shots} on the hole number {CourseHole.HoleNumber}";

        }
    }
}