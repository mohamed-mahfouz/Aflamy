namespace Aflame.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'19810d28-8f75-4bd3-b0d0-7f20e6684793', N'admin@Aflame.com', 0, N'AIXuHftHk8f3qy0GDauu3RW+CVKD8Z4MI3iAJpMU5Bia1S20ifBAGW+yr7AuBygcXg==', N'ae1a1a9a-7ee6-45b1-93f2-beaddb07ccc0', NULL, 0, 0, NULL, 1, 0, N'admin@Aflame.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'aea406c0-123c-4748-a26c-6bd656ddca54', N'guest@Aflame.com', 0, N'AIRHsHHGZkhojDHV4vOACAF5Gj4E05ewksJuxmiB1Hd4SdehwEpmM+SMmZGfl6b7SQ==', N'07dc6594-d4ed-4785-9865-015870f00f23', NULL, 0, 0, NULL, 1, 0, N'guest@Aflame.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'61e8cac4-3a21-460a-8c74-339ee4801f73', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'19810d28-8f75-4bd3-b0d0-7f20e6684793', N'61e8cac4-3a21-460a-8c74-339ee4801f73')

");
        }
        
        public override void Down()
        {
        }
    }
}
