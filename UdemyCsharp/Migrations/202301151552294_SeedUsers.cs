namespace UdemyCsharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'955dd967-3352-44aa-9360-58247ab33338', N'admin@vidly.com', 0, N'AHiAOioYYWlNmK28l0BNX/u6Uhk3IgyYj4+cz3u0S8bn9StoyrpNSwFtxs1VNzOTrw==', N'd79f0a82-bb39-4773-b2b5-c97a1f61e975', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ec24ad56-abfc-49c5-823c-ce9bed26c0eb', N'guest@vidly.com', 0, N'AMlAIUkoB4Bt4ixu1UqOmXa6XUtleixxS8d6TnHK82vGxT41Hd7/xE67bsnuykEkJw==', N'db5dac9b-5d99-4c3f-8c58-79889c2f380f', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'03c13c67-ae3c-4933-a54e-0337f0118030', N'CanManageMovie')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'955dd967-3352-44aa-9360-58247ab33338', N'03c13c67-ae3c-4933-a54e-0337f0118030')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
