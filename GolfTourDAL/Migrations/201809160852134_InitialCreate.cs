namespace GolfTourDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseHoles",
                c => new
                    {
                        CourseHoleId = c.Int(nullable: false, identity: true),
                        HoleNumber = c.Int(nullable: false),
                        Stroke = c.Int(nullable: false),
                        Par = c.Int(nullable: false),
                        GolfCourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseHoleId)
                .ForeignKey("dbo.GolfCourses", t => t.GolfCourseId, cascadeDelete: true)
                .Index(t => t.GolfCourseId);
            
            CreateTable(
                "dbo.GolfCourses",
                c => new
                    {
                        GolfCourseId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.GolfCourseId);
            
            CreateTable(
                "dbo.CourseRounds",
                c => new
                    {
                        CourseRoundId = c.Int(nullable: false, identity: true),
                        GolfCourseId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        ScoreType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseRoundId)
                .ForeignKey("dbo.GolfCourses", t => t.GolfCourseId, cascadeDelete: true)
                .Index(t => t.GolfCourseId);
            
            CreateTable(
                "dbo.CourseRoundHoles",
                c => new
                    {
                        CourseRoudHoleId = c.Long(nullable: false, identity: true),
                        CourseRoudId = c.Int(nullable: false),
                        CourseHoleId = c.Int(),
                        GolferId = c.Int(nullable: false),
                        Strokes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseRoudHoleId)
                .ForeignKey("dbo.CourseHoles", t => t.CourseHoleId)
                .ForeignKey("dbo.CourseRounds", t => t.CourseRoudId, cascadeDelete: true)
                .ForeignKey("dbo.Golfer", t => t.GolferId, cascadeDelete: true)
                .Index(t => t.CourseRoudId)
                .Index(t => t.CourseHoleId)
                .Index(t => t.GolferId);
            
            CreateTable(
                "dbo.Golfer",
                c => new
                    {
                        GolferId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Surname = c.String(maxLength: 50),
                        Email = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.GolferId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseRounds", "GolfCourseId", "dbo.GolfCourses");
            DropForeignKey("dbo.CourseRoundHoles", "GolferId", "dbo.Golfer");
            DropForeignKey("dbo.CourseRoundHoles", "CourseRoudId", "dbo.CourseRounds");
            DropForeignKey("dbo.CourseRoundHoles", "CourseHoleId", "dbo.CourseHoles");
            DropForeignKey("dbo.CourseHoles", "GolfCourseId", "dbo.GolfCourses");
            DropIndex("dbo.CourseRoundHoles", new[] { "GolferId" });
            DropIndex("dbo.CourseRoundHoles", new[] { "CourseHoleId" });
            DropIndex("dbo.CourseRoundHoles", new[] { "CourseRoudId" });
            DropIndex("dbo.CourseRounds", new[] { "GolfCourseId" });
            DropIndex("dbo.CourseHoles", new[] { "GolfCourseId" });
            DropTable("dbo.Golfer");
            DropTable("dbo.CourseRoundHoles");
            DropTable("dbo.CourseRounds");
            DropTable("dbo.GolfCourses");
            DropTable("dbo.CourseHoles");
        }
    }
}
