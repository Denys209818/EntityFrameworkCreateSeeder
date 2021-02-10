using EFCreateSeeder.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCreateSeeder.DAL.Services
{
    public static class DBSeeder
    {
        /// <summary>
        ///     Викликає усі методи, що стосуються заповнення БД
        /// </summary>
        /// <param name="context">Приймає звязок до БД типу Context</param>
        public static void SeedAll(EFContext context) 
        {
            SeedRoles(context);
            SeedUsers(context);
            SeedUserRoles(context);
        }
        /// <summary>
        ///     Заповнює БД ролями
        /// </summary>
        /// <param name="context">Приймає звязок до БД типу Context</param>
        private static void SeedRoles(EFContext context) 
        {
            if (context.AspNetRoles.Count() == 0) 
            {
                context.AspNetRoles.AddRange(new List<AspNetRole> { 
                new AspNetRole
                {
                    Name = "Doctor",
                    NormalizedName = "Doctor Cardiolog",
                    ConcurrencyStamp = ""
                },
                new AspNetRole
                {
                    Name = "Teacher",
                    NormalizedName = "Web-Design Teacher",
                    ConcurrencyStamp = ""
                },
                new AspNetRole
                {
                    Name = "Manager",
                    NormalizedName = "Manger for Sales",
                    ConcurrencyStamp = ""
                }
                });

                context.SaveChanges();
            }
        }
        /// <summary>
        ///     Заповнює БД користувачами
        /// </summary>
        /// <param name="context">Приймає звязок до БД типу Context</param>
        private static void SeedUsers(EFContext context) 
        {
            if (context.AspNetUsers.Count() == 0) 
            {
                context.AspNetUsers.AddRange(new List<AspNetUser> {
                new AspNetUser
                {
                    UserName = "Kolya",
                    TwoFactorEnabled = true,
                    AccessFailedCount = "0",
                    ConcurrencyStamp = "",
                    EmailConfirmed = true,
                    Email = "kolya@gmail.com",
                    LockoutEnabled = true,
                    LockoutEnd =  DateTime.Now,
                    NormalizedEmail = "kolya@gmail.com",
                    NormalizedUserName ="Kolya Petrov",
                    PasswordHash = "123",
                    PhoneNumber = "086081238501",
                    PhoneNumberConfirmed = true,
                    SecurityStamp = ""
                },
                new AspNetUser
                {
                    UserName = "Andriy",
                    TwoFactorEnabled = true,
                    AccessFailedCount = "0",
                    ConcurrencyStamp = "",
                    EmailConfirmed = true,
                    Email = "andriy@gmail.com",
                    LockoutEnabled = true,
                    LockoutEnd =  DateTime.Now,
                    NormalizedEmail = "andriy@gmail.com",
                    NormalizedUserName ="Andriy Sidorov",
                    PasswordHash = "432",
                    PhoneNumber = "0823423840",
                    PhoneNumberConfirmed = true,
                    SecurityStamp = ""
                },
                new AspNetUser
                {
                    UserName = "Vasja",
                    TwoFactorEnabled = true,
                    AccessFailedCount = "0",
                    ConcurrencyStamp = "",
                    EmailConfirmed = true,
                    Email = "vasja@gmail.com",
                    LockoutEnabled = true,
                    LockoutEnd =  DateTime.Now,
                    NormalizedEmail = "vasja@gmail.com",
                    NormalizedUserName ="Vasja Ivanov",
                    PasswordHash = "643",
                    PhoneNumber = "92342034234",
                    PhoneNumberConfirmed = true,
                    SecurityStamp = ""
                }
                });

                context.SaveChanges();
            }
        }
        /// <summary>
        ///     Заповнюж БД звязками між таблицями: AspNetUser i AspNetRole
        /// </summary>
        /// <param name="context">Приймає звязок до БД типу Context</param>
        private static void SeedUserRoles(EFContext context) 
        {
            if (context.UserRoles.Count() == 0) 
            {
                context.AddRange(new List<AspNetUserRoles> { 
                new AspNetUserRoles 
                {
                    UserId = 1,
                    RoleId = 1,
                },
                new AspNetUserRoles 
                {
                    UserId = 2,
                    RoleId = 3,
                },
                new AspNetUserRoles 
                {
                    UserId = 3,
                    RoleId = 2,
                }
                });
                context.SaveChanges();
            }
        }

    }
}
