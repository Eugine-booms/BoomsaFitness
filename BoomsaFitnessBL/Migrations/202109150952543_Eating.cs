namespace BoomsaFitnessBL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Eating : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "GenderId", "dbo.Genders");
            DropForeignKey("dbo.Eatings", "Food_Id", "dbo.Foods");
            DropIndex("dbo.Users", new[] { "GenderId" });
            DropIndex("dbo.Eatings", new[] { "Food_Id" });
            RenameColumn(table: "dbo.Eatings", name: "Food_Id", newName: "FoodId");
            AlterColumn("dbo.Users", "GenderId", c => c.Int(nullable: false));
            AlterColumn("dbo.Eatings", "Moment", c => c.DateTime());
            AlterColumn("dbo.Eatings", "FoodId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "GenderId");
            CreateIndex("dbo.Eatings", "FoodId");
            AddForeignKey("dbo.Users", "GenderId", "dbo.Genders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Eatings", "FoodId", "dbo.Foods", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Eatings", "FoodId", "dbo.Foods");
            DropForeignKey("dbo.Users", "GenderId", "dbo.Genders");
            DropIndex("dbo.Eatings", new[] { "FoodId" });
            DropIndex("dbo.Users", new[] { "GenderId" });
            AlterColumn("dbo.Eatings", "FoodId", c => c.Int());
            AlterColumn("dbo.Eatings", "Moment", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "GenderId", c => c.Int());
            RenameColumn(table: "dbo.Eatings", name: "FoodId", newName: "Food_Id");
            CreateIndex("dbo.Eatings", "Food_Id");
            CreateIndex("dbo.Users", "GenderId");
            AddForeignKey("dbo.Eatings", "Food_Id", "dbo.Foods", "Id");
            AddForeignKey("dbo.Users", "GenderId", "dbo.Genders", "Id");
        }
    }
}
