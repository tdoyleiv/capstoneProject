namespace Hana.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Hana.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Hana.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Hana.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.States.AddOrUpdate(
              s => s.PostalCode,
              new State { Name = "Alabama", PostalCode = "AL" }, 
              new State { Name = "Alaska", PostalCode = "AK" },
              new State { Name = "Arizona", PostalCode = "AZ" },
              new State { Name = "Arkansas", PostalCode = "AR" },
              new State { Name = "California", PostalCode = "CA" },
              new State { Name = "Colorado", PostalCode = "CO" },
              new State { Name = "Connecticut", PostalCode = "CT" },
              new State { Name = "Delaware", PostalCode = "DE" },
              new State { Name = "Florida", PostalCode = "FL" },
              new State { Name = "Georgia", PostalCode = "GA" },
              new State { Name = "Hawaii", PostalCode = "HI" },
              new State { Name = "Idaho", PostalCode = "ID" },
              new State { Name = "Illinois", PostalCode = "IL" },
              new State { Name = "Indiana", PostalCode = "IN" },
              new State { Name = "Iowa", PostalCode = "IA" },
              new State { Name = "Kansas", PostalCode = "KS" },
              new State { Name = "Kentucky", PostalCode = "KY" },
              new State { Name = "Louisiana", PostalCode = "LA" },
              new State { Name = "Maine", PostalCode = "ME" },
              new State { Name = "Maryland", PostalCode = "MD" },
              new State { Name = "Massachusetts", PostalCode = "MA" },
              new State { Name = "Michigan", PostalCode = "MI" },
              new State { Name = "Minnesota", PostalCode = "MN" },
              new State { Name = "Mississippi", PostalCode = "MS" },
              new State { Name = "Missouri", PostalCode = "MO" },
              new State { Name = "Montana", PostalCode = "MT" },
              new State { Name = "Nebraska", PostalCode = "NE" },
              new State { Name = "Nevada", PostalCode = "NV" },
              new State { Name = "New Hampshire", PostalCode = "NH" },
              new State { Name = "New Jersey", PostalCode = "NJ" },
              new State { Name = "New Mexico", PostalCode = "NM" },
              new State { Name = "New York", PostalCode = "NY" },
              new State { Name = "North Carolina", PostalCode = "NC" },
              new State { Name = "North Dakota", PostalCode = "ND" },
              new State { Name = "Ohio", PostalCode = "OH" },
              new State { Name = "Oklahoma", PostalCode = "OK" },
              new State { Name = "Oregon", PostalCode = "OR" },
              new State { Name = "Pennsylvania", PostalCode = "PA" },
              new State { Name = "Rhode Island", PostalCode = "RI" },
              new State { Name = "South Carolina", PostalCode = "SC" },
              new State { Name = "South Dakota", PostalCode = "SD" },
              new State { Name = "Tennessee", PostalCode = "TN" },
              new State { Name = "Texas", PostalCode = "TX" },
              new State { Name = "Utah", PostalCode = "UT" },
              new State { Name = "Vermont", PostalCode = "VT" },
              new State { Name = "Virginia", PostalCode = "VA" },
              new State { Name = "Washington", PostalCode = "WA" },
              new State { Name = "West Virginia", PostalCode = "WV" },
              new State { Name = "Wisconsin", PostalCode = "WI" },
              new State { Name = "Wyoming", PostalCode = "WY" },
              new State { Name = "District of Columbia", PostalCode = "DC" }
            );
            context.Sizes.AddOrUpdate(
              s => s.Name,
              new Size { Name = "Small" },
              new Size { Name = "Medium" },
              new Size { Name = "Large" },
              new Size { Name = "Extra Large" }
              );
        }
    }
}
