using DataAccess.Entities;
using DataAccess.Mapping;

namespace DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<AtpContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(AtpContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var admin = new Role {Id = 0, RoleName = "Admin"};
            var teacher = new Role {Id = 1, RoleName = "Teacher"};
            var student = new Role {Id = 2, RoleName = "Student"};

            context.Roles.Add(admin);
            context.Roles.Add(teacher);
            context.Roles.Add(student);

            //context.Roles.AddOrUpdate(
            //    new Role {Id = 0, RoleName = "Admin"},
            //    new Role {Id = 1, RoleName = "Teacher"},
            //    new Role {Id = 2, RoleName = "Student"});

            context.Users.AddOrUpdate(
                new User
                {
                    Name = new Name
                    {
                        FirstName = "Beseda",
                        LastName = "Dmitriy",
                        MiddleName = "Gennadievich"
                    },
                    Password = "donntu2009",
                    Email = "BesedaDG@gmail.com",
                    Role = student
                },
                new User
                {
                    Name = new Name
                    {
                        FirstName = "Zinchencko",
                        LastName = "Yuriy",
                        MiddleName = "Yevgenievich"
                    },
                    Password = "donntu2009",
                    Email = "Zinchencko@gmail.com",
                    Role = teacher
                },
                new User
                {
                    Name = new Name
                    {
                        FirstName = "Admin",
                        LastName = "Admin",
                        MiddleName = "Admin"
                    },
                    Password = "donntu2009",
                    Email = "Admin@gmail.com",
                    Role = admin
                }
                );
        }
    }
}
