using EFCreateSeeder.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCreateSeeder.DAL
{
    public class EFContext : DbContext
    {
        public DbSet<AspNetRole> AspNetRoles { get; set; }
        public DbSet<AspNetUser> AspNetUsers { get; set; }
        public DbSet<AspNetUserRoles> UserRoles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=91.238.103.51;Port=5743;Database=denysdb;Username=denys;Password=qwerty1*;");
        }
        /// <summary>
        ///     Метод, у якому прописуються налаштування до класу AspNetUserRoles
        ///     Налаштування прописуюються, оскільки поля UserId i RoleId є одночасно
        ///     PRIMARY KEYS i FOREIGN KEYS
        /// </summary>
        /// <param name="modelBuilder">Параметр типу ModelBuilder</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AspNetUserRoles>(data =>
            {
                //  Встановлення PRIMERY KEYS для полів RoleId і UserId
                data.HasKey(primaryKeys => new { primaryKeys.RoleId, primaryKeys.UserId });

                //  Формування звязку один до багатьох
                //  Вибірка віртуального поля з таблички AspNetRole, для звязування з класом AspNetUserRoles
                data.HasOne(userRolesVirtualColumnFromRole => userRolesVirtualColumnFromRole.Role)
                //  Вибірка віртуальної колекції з таблички AspNetUserRoles, щоб створити звязок з полем Role з класу AspNetRole
                .WithMany(userRolesVirtualCollectionFromUserRoles => userRolesVirtualCollectionFromUserRoles.UserRoles)
                //  Вибірка поля для якого встановлюється ForeignKey Constraint
                .HasForeignKey(userRolesIntColumnFromRoleWithForeignSettings => 
                userRolesIntColumnFromRoleWithForeignSettings.RoleId)
                //  Вказує що поле обовязкове для заповнення
                .IsRequired();

                //  Формування звязку один до багатьох
                //  Вибірка віртуального поля з таблички AspNetUser, яке буде звязуватися з класом(таблицею) AspNetUserRoles 
                data.HasOne(userRolesVirtualColumnFromUser => userRolesVirtualColumnFromUser.User)
                //  Вибірка віртальної колекції з класу AspNetUserRoles, щоб створити звязок з полем User з класу AspNetUser
                .WithMany(userRolesVirtualCollectionFromUserRoles => userRolesVirtualCollectionFromUserRoles.UserRoles)
                //  Вибірка поля(int), до якого застосовується Constraint 
                .HasForeignKey(userRolesIntColumnWithForeignSettings => userRolesIntColumnWithForeignSettings.UserId)
                //  Вказує, що поле є обовязковим
                .IsRequired();
                
            });
        }
    }
}
