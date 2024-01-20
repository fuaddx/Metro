using MetroMvc.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MetroMvc.Contexts
{
	public class DatadbContext : IdentityDbContext
	{
		public DatadbContext(DbContextOptions options) : base(options)
		{
		}
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken=default)
		{
			IEnumerable<EntityEntry<Blog>> entries = ChangeTracker.Entries<Blog>();
            foreach (EntityEntry<Blog> entry in entries)
            {
                if(entry.State == EntityState.Added)
				{
					DateTime dateTime = DateTime.UtcNow;
					DateTime azTime = dateTime.AddHours(4);
					entry.Entity.CreatedTime = azTime;
					entry.Entity.UpdatedTime = null;
				}else if(entry.State == EntityState.Modified)
				{
					DateTime dateTime = DateTime.UtcNow;
					DateTime azTime = dateTime.AddHours(4);
					entry.Entity.UpdatedTime = azTime;

					var modifiedProperty = entry.Properties.Where(prop => prop.IsModified && !prop.Metadata.IsPrimaryKey());
					if (!modifiedProperty.Any())
					{
						entry.Entity.UpdatedTime = null;
					}
				}
            }
			return base.SaveChangesAsync(cancellationToken);
        }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Setting>().HasData(new Setting
			{
				Id=1,
				ImageUrl = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fnystudio107.com%2Fimg%2Fblog%2F_1200x675_crop_center-center_82_line%2Fimage_optimzation.jpg&tbnid=qHRJdD_fikxVkM&vet=12ahUKEwjByqjhmeyDAxUUMBAIHSrfAysQMyg7egUIARDTAQ..i&imgrefurl=https%3A%2F%2Fnystudio107.com%2Fblog%2Fcreating-optimized-images-in-craft-cms&docid=F2R8PY0eFUPyBM&w=1200&h=675&q=image&ved=2ahUKEwjByqjhmeyDAxUUMBAIHSrfAysQMyg7egUIARDTAQ"
            });
			base.OnModelCreating(modelBuilder);
		}
	}
}
