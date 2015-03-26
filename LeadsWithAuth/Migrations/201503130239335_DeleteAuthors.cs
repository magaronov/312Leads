namespace LeadsWithAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteAuthors : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Authors");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
