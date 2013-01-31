namespace EF.Experience.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PersonNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Number", c => c.Int(nullable: false, defaultValue: 0));
            CreateIndex("dbo.People", "Name", true, "index_name");
        }

        public override void Down()
        {
            DropColumn("dbo.People", "Number");
        }
    }
}
