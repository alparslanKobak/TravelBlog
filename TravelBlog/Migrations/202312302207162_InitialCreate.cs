namespace TravelBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AppUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        RoleId = c.Int(nullable: false),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AppRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.BlogPosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        Image = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        CityId = c.Int(nullable: false),
                        AppUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.AppUsers", t => t.AppUserId)
                .Index(t => t.CityId)
                .Index(t => t.AppUserId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Image = c.String(),
                        RegionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Regions", t => t.RegionId, cascadeDelete: true)
                .Index(t => t.RegionId);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        AppUserId = c.Int(nullable: false),
                        BlogPostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AppUsers", t => t.AppUserId, cascadeDelete: true)
                .ForeignKey("dbo.BlogPosts", t => t.BlogPostId)
                .Index(t => t.AppUserId)
                .Index(t => t.BlogPostId);
            
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BlogPostId = c.Int(nullable: false),
                        AppUserId = c.Int(nullable: false),
                        IsLiked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AppUsers", t => t.AppUserId, cascadeDelete: true)
                .ForeignKey("dbo.BlogPosts", t => t.BlogPostId)
                .Index(t => t.BlogPostId)
                .Index(t => t.AppUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppUsers", "RoleId", "dbo.AppRoles");
            DropForeignKey("dbo.BlogPosts", "AppUserId", "dbo.AppUsers");
            DropForeignKey("dbo.Likes", "BlogPostId", "dbo.BlogPosts");
            DropForeignKey("dbo.Likes", "AppUserId", "dbo.AppUsers");
            DropForeignKey("dbo.Comments", "BlogPostId", "dbo.BlogPosts");
            DropForeignKey("dbo.Comments", "AppUserId", "dbo.AppUsers");
            DropForeignKey("dbo.Cities", "RegionId", "dbo.Regions");
            DropForeignKey("dbo.BlogPosts", "CityId", "dbo.Cities");
            DropIndex("dbo.Likes", new[] { "AppUserId" });
            DropIndex("dbo.Likes", new[] { "BlogPostId" });
            DropIndex("dbo.Comments", new[] { "BlogPostId" });
            DropIndex("dbo.Comments", new[] { "AppUserId" });
            DropIndex("dbo.Cities", new[] { "RegionId" });
            DropIndex("dbo.BlogPosts", new[] { "AppUserId" });
            DropIndex("dbo.BlogPosts", new[] { "CityId" });
            DropIndex("dbo.AppUsers", new[] { "RoleId" });
            DropTable("dbo.Likes");
            DropTable("dbo.Comments");
            DropTable("dbo.Regions");
            DropTable("dbo.Cities");
            DropTable("dbo.BlogPosts");
            DropTable("dbo.AppUsers");
            DropTable("dbo.AppRoles");
        }
    }
}
