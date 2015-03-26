namespace LeadsWithAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Work : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InspectionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Desscription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.InspectionTypes");
        }
    }
}
