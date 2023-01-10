namespace UdemyCsharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthdateToCustomer1 : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET BirthDate='1993-09-29' WHERE Id=1");
        }
        
        public override void Down()
        {
        }
    }
}
