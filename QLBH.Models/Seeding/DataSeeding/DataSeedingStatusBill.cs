using Microsoft.EntityFrameworkCore;
using QLBH.Models.Entities;

namespace QLBH.Models
{
    public partial class DataSeeding
    {
        public static void DataSeedingStatusBill(AppDbContext context)
        {
            if (!context.Status_Bill.Any())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    context.Status_Bill.AddRange(GenerateSatatusBill());
                    context.Database.ExecuteSqlRaw(string.Format(Commons.Common_Constants.SQLRaw.SET_IDENTITY_INSERT_ON, nameof(Status_Bill)));
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw(string.Format(Commons.Common_Constants.SQLRaw.SET_IDENTITY_INSERT_OFF, nameof(Status_Bill)));
                    transaction.Commit();
                }
            }
        }
        public static List<Status_Bill> GenerateSatatusBill()
        {
            return new List<Status_Bill>
            {
                new Status_Bill {
                    ID = 1,
                    Status_Name = "Created"
                },
                new Status_Bill {
                    ID = 2,
                    Status_Name = "Pending Confirmation"
                },
                new Status_Bill {
                    ID = 3,
                    Status_Name = "Confirmed"
                },
                new Status_Bill
                {
                    ID = 4,
                    Status_Name = "In Progress/Delivery"
                },
                new Status_Bill
                {
                    ID = 5,
                    Status_Name="Delivered"
                },
                new Status_Bill
                {
                    ID= 6,
                    Status_Name="Paid"
                },
                new Status_Bill{
                    ID= 7,
                    Status_Name="Cancelled"
                },
                new Status_Bill
                {
                    ID=8,
                    Status_Name="Pending Processing"
                },
                new Status_Bill
                {
                    ID= 9,
                    Status_Name="Completed"
                }
            };
        }
    }
}
