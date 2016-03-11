namespace Student.Profile.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Student.Profile.Context.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Student.Profile.Context.AppDbContext context)
        {
            var users = new List<User>()
            {
                new User()
                {
                    UserName="admin",Password="admin",FirstName="Kripesh",LastName="Bista",Email="kripeshbista3@gmail.com",Status=true
                },
                new User()
                {
                    UserName="user",Password="user",FirstName="Rupesh",LastName="Gurung",Email="rupesh@gmail.com",Status=true
                },
            };
            users.ForEach(u =>
            {
                context.Users.Add(u);
                context.SaveChanges();
            });
            var roles = new List<Role>()
            {
                new Role()
                {
                    RoleName="Admin"
                },
                new Role()
                {
                    RoleName="User"
                }
            };
            roles.ForEach(r =>
            {
                context.Roles.Add(r);
                context.SaveChanges();
            });
            var userRoles = new List<UserRole>()
            {
                new UserRole()
                {
                   UserId=users.Single(i=> i.UserName=="admin").UserId,RoleId=roles.Single(i=> i.RoleName=="Admin").RoleId
                },
                new UserRole()
                {
                    UserId=users.Single(i=> i.UserName=="user").UserId,RoleId=roles.Single(i=> i.RoleName=="User").RoleId
                }
            };
            userRoles.ForEach(ur =>
            {
                context.UserRoles.Add(ur);
                context.SaveChanges();
            });
        }
    }
}
