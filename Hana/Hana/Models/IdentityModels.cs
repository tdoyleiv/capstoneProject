using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Hana.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Hana.Models.BillingAddress> BillingAddresses { get; set; }

        public System.Data.Entity.DbSet<Hana.Models.City> Cities { get; set; }

        public System.Data.Entity.DbSet<Hana.Models.State> States { get; set; }

        public System.Data.Entity.DbSet<Hana.Models.ZIP> ZIPs { get; set; }

        public System.Data.Entity.DbSet<Hana.Models.CreditCard> CreditCards { get; set; }

        public System.Data.Entity.DbSet<Hana.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<Hana.Models.EmailAddress> EmailAddresses { get; set; }

        public System.Data.Entity.DbSet<Hana.Models.PhoneNumber> PhoneNumbers { get; set; }

        public System.Data.Entity.DbSet<Hana.Models.ShippingAddress> ShippingAddresses { get; set; }

        public System.Data.Entity.DbSet<Hana.Models.ShoppingCart> ShoppingCarts { get; set; }

        public System.Data.Entity.DbSet<Hana.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<Hana.Models.ProductType> ProductTypes { get; set; }

        public System.Data.Entity.DbSet<Hana.Models.Size> Sizes { get; set; }

        public System.Data.Entity.DbSet<Hana.Models.Transaction> Transactions { get; set; }

        public System.Data.Entity.DbSet<Hana.Models.Store> Stores { get; set; }

        public System.Data.Entity.DbSet<Hana.Models.OrderedProduct> OrderedProducts { get; set; }
    }
}