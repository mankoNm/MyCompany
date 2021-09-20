using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyCompany.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Domain
{
	public class AppDbContext : IdentityDbContext<IdentityUser>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<TextField> TextFields { get; set; }
		public DbSet<ServiceItem> ServiceItems { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
			{
				Id = "936DA01F-9ABD-4d9d-80C7-02AF85C822A8",
				Name = "admin",
				NormalizedName = "ADMIN"
			});

			modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
			{
				Id = "536DA01F-9ABD-4d9d-80C7-02AF85C822A8",
				UserName = "admin",
				NormalizedUserName = "ADMIN",
				Email = "my@email.com",
				NormalizedEmail = "MY@EMAIL.COM",
				EmailConfirmed = true,
				PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
				SecurityStamp = string.Empty
			});

			modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
			{
				RoleId = "936DA01F-9ABD-4d9d-80C7-02AF85C822A8",
				UserId = "536DA01F-9ABD-4d9d-80C7-02AF85C822A8"
			});

			modelBuilder.Entity<TextField>().HasData(new TextField {
				Id = new Guid("136DA01F-9ABD-4d9d-80C7-02AF85C822A8"),
				CodeWord = "PageIndex",
				Title = "Главная"
			});

			modelBuilder.Entity<TextField>().HasData(new TextField
			{
				Id = new Guid("236DA01F-8ABD-4d9d-80C7-02AF85C822A8"),
				CodeWord = "PageServices",
				Title = "Наши услуги"
			});

			modelBuilder.Entity<TextField>().HasData(new TextField
			{
				Id = new Guid("336DA01F-9ABD-4d9d-80C7-02AF85C822A8"),
				CodeWord = "PageContacts",
				Title = "Контанты"
			});
		}
	}
}
