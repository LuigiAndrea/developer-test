namespace OrangeBricks.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFieldAppointmentsToProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "Property_Id", c => c.Int());
            CreateIndex("dbo.Appointments", "Property_Id");
            AddForeignKey("dbo.Appointments", "Property_Id", "dbo.Properties", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "Property_Id", "dbo.Properties");
            DropIndex("dbo.Appointments", new[] { "Property_Id" });
            DropColumn("dbo.Appointments", "Property_Id");
        }
    }
}
