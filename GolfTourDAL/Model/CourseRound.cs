using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolfTourDAL.Model
{
    public partial class CourseRound
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseRoundId { get; set; }

        public int GolfCourseId { get; set; }
        [ForeignKey("GolfCourseId")] public virtual GolfCourse GolfCourse { get; set; }

        public DateTime Date { get; set; }

        public ScoreType ScoreType { get; set; }

        public virtual ICollection<Golfer> Golfers { get; set; }= new HashSet<Golfer>();

        //public int Golfer1Id { get; set; }
        //[ForeignKey("Golfer1Id")] public virtual Golfer Golfer1 { get; set; }
        //public int Golfer2Id { get; set; }
        //[ForeignKey("Golfer2Id")] public virtual Golfer Golfer2 { get; set; }
        ////public int Golfer3Id { get; set; }
        ////[ForeignKey("Golfer3Id")] public virtual Golfer Golfer3 { get; set; }
        ////public int Golfer4Id { get; set; }
        ////[ForeignKey("Golfer4Id")] public virtual Golfer Golfer4 { get; set; }
    }
}