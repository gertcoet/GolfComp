 using GolfTourDAL.Model;

namespace GolfTourDAL.EF
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class GolfTourEntities : DbContext
    {
        // Your context has been configured to use a 'GolfTourEntities' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'GolfTourDAL.EF.GolfTourEntities' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'GolfTourEntities' 
        // connection string in the application configuration file.
        public GolfTourEntities()
            : base("name=GolfTourEntities")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Golfer> Golfers { get; set; }
        public virtual DbSet<GolfCourse> GolfCourses { get; set; }
        public virtual DbSet<CourseHole> CourseHoles { get; set; }
        public virtual DbSet<CourseRound> CourseRound { get; set; }
        public virtual DbSet<CourseRoundHole> CourseRoundHoles { get; set; }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}