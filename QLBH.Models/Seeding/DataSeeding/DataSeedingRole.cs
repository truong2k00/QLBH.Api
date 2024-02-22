using Microsoft.EntityFrameworkCore;
using QLBH.Commons;
using QLBH.Models.Entities;

namespace QLBH.Models
{
    public partial class DataSeeding
    {
        public static void DataSeedingRole(AppDbContext dbContext)
        {
            if (!dbContext.Role.Any())
            {
                using (var transaction = dbContext.Database.BeginTransaction())
                {
                    dbContext.Role.AddRange(GenerateRole());
                    dbContext.Database.ExecuteSqlRaw(string.Format(Common_Constants.SQLRaw.SET_IDENTITY_INSERT_ON, nameof(Role)));
                    dbContext.SaveChanges();
                    dbContext.Database.ExecuteSqlRaw(string.Format(Common_Constants.SQLRaw.SET_IDENTITY_INSERT_OFF, nameof(Role)));
                    transaction.Commit();
                }
            }
        }
        public static List<Role> GenerateRole()
        {
            return new List<Role>
            {
                new Role
                {
                    ID = 100,
                    Role_ID = 100,
                    Role_Name = "Admin"
                },
                new Role
                {
                    ID = 200,
                    Role_ID = 200,
                    Role_Name = "User"
                },
                new Role
                {
                    ID = 201,
                    Role_ID = 201,
                    Role_Name = "Guest"
                },
                new Role
                {
                    ID = 300,
                    Role_ID = 300,
                    Role_Name = "Moderator"
                },
                new Role
                {
                    ID = 301,
                    Role_ID = 301,
                    Role_Name = "Editor"
                },
                new Role
                {
                    ID = 302,
                    Role_ID = 302,
                    Role_Name = "Manager"
                },
                new Role
                {
                    ID = 400,
                    Role_ID = 400,
                    Role_Name = "Superuser"
                }
            };

        }
    }
}
