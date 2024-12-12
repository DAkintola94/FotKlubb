﻿using FotKlubb.Models.DomainModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FotKlubb.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<CreateProfileModel> ProfileCreation { get; set; }
        public DbSet<PositionModel> Position_model { get; set; }
        public DbSet<LoginProfileModel> LoginProfile { get; set; }
        public DbSet<UsersActivity> UserActivity { get; set; }
        public DbSet<UsersPostModel> UserPost { get; set; }
        public DbSet<MarketModel> Market { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            var sysAdminRoleId = "1";
            var adminRoleId = "2";
            var userRoleId = "3";

            //Seed roles for (User, Admin Superadmin)
            // Seed superAdmin
            // Add all the role to the superadmin

            var roles = new List<IdentityRole> //List of roles, stacked in IdenityRole list
            {

               new IdentityRole //role 1
               {
                  Name = "System Administrator",
                  NormalizedName = "SYSADMIN",
                  Id = sysAdminRoleId,
                  ConcurrencyStamp = sysAdminRoleId
               },

               new IdentityRole //role 2
               {
                   Name = "Admin",
                   NormalizedName = "ADMIN",
                   Id = adminRoleId,
                   ConcurrencyStamp = adminRoleId
               },

               new IdentityRole //role 3 
               {
                   Name = "RegularUser",
                   NormalizedName = "RegularUser",
                   Id = userRoleId,
                   ConcurrencyStamp = userRoleId
               },

               };

            modelBuilder.Entity<IdentityRole>().HasData(roles); //Seed data for roles

            //Seed data for users

            var sysadminId = "1";
            var sysAdminUser = new ApplicationUser
            {
                Id = sysadminId,
                UserName = "sysadmin@test.com",
                NormalizedUserName = "sysadmin@test.com".ToUpper(),
                Email = "sysadmin@test.com",
                NormalizedEmail = "sysadmin@test.com".ToUpper(),
                FirstName = "System",
                LastName = "Administrator",
                PhoneNumber = "40748608"
            };

            sysAdminUser.PasswordHash = new PasswordHasher<ApplicationUser> //Hashing password for sysAdminUser
                ().HashPassword(sysAdminUser, "Testingtesting1234");

            modelBuilder.Entity<ApplicationUser>().HasData(sysAdminUser); //using applicationuser because its custom model than add more, 
            //its possible because it inherits from IdentityUser, the is the default

            var sysadminRoles = new List<IdentityUserRole<string>> //List of roles for sysAdminUser
            {
                new IdentityUserRole<string> //Adding role so sysAdminUser can be a system administrator
                {
                    RoleId = sysAdminRoleId,
                    UserId = sysadminId
                },

                new IdentityUserRole<string> //Adding role so sysAdminUser can be a driver
                {
                    RoleId = adminRoleId,
                    UserId = sysadminId
                },

                new IdentityUserRole<string> //Adding role so sysAdminUser can be a customer
                {
                    RoleId = userRoleId,
                    UserId = sysadminId
                }

            };


            modelBuilder.Entity<IdentityUserRole<string>>().HasData(sysadminRoles); //Seed data for sysAdminUser roles

            //Seeding data for driverUser

            var adminId = "2";
            var adminUser = new ApplicationUser //Creating a driver user
            {
                Id = adminId, //All this is possible because of IdentityUser
                UserName = "admin@test.com",
                NormalizedUserName = "ADMIN@TEST.COM",
                Email = "admin@test.com", //All this is possible because of IdentityUser
                NormalizedEmail = "ADMIN@TEST.COM",
                FirstName = "Test",
                LastName = "Admin",
                PhoneNumber = "95534356"
            };

            adminUser.PasswordHash = new PasswordHasher<ApplicationUser> //Hashing password for driverUser, linked to ApplicationUser
                ().HashPassword(adminUser, "Admintesting1234");

            modelBuilder.Entity<ApplicationUser>().HasData(adminUser); //Seed data for driverUser, linked to ApplicationUser

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = adminId
                }

              );

            //Seeding data for customerUser

            var userId = "3";
            var averageUser = new ApplicationUser //Creating a customer user
            {
                Id = userId, //All this is possible because of IdentityUser
                UserName = "user@test.com",
                NormalizedUserName = "USER@TEST.COM", //All this is possible because of IdentityUser
                Email = "user@test.com",
                NormalizedEmail = "USER@TEST.COM",
                FirstName = "Test",
                LastName = "User",
                PhoneNumber = "43342364"
            };

            averageUser.PasswordHash = new PasswordHasher<ApplicationUser> //Hashing password for customerUser, linked to ApplicationUser
                ().HashPassword(averageUser, "Usertesting1234");

            modelBuilder.Entity<ApplicationUser>().HasData(averageUser); //Seed data for customerUser, linked to ApplicationUser

            modelBuilder.Entity<IdentityUserRole<string>>().HasData( //Seed data for customerUser roles
                new IdentityUserRole<string>
                {
                    RoleId = userRoleId,
                    UserId = userId
                }
              );

            modelBuilder.Entity<CreateProfileModel>()
                .HasIndex(p => p.Email)
                .IsUnique();
            modelBuilder.Entity<PositionModel>()
                .HasKey(p => p.PositionId);
            modelBuilder.Entity<MarketModel>()
                .HasKey(p => p.MarketID);
            modelBuilder.Entity<CategoryModel>()
                .HasKey(p => p.CategoryID);
            modelBuilder.Entity<UsersPostModel>()
                .HasKey(p => p.PostId);

            //modelBuilder.Entity<UsersActivity>()
            //.HasOne(p => p.UsersApplication)
            //.WithOne()
            //.HasForeignKey(p => p.UsersSessionId);
        }
    }
}
