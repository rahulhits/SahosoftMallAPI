using Microsoft.EntityFrameworkCore;
using Repositories.EComm.Common;
using Repositories.EComm.DbEntity;

namespace Repositories
{
	public class ECommDBContext : DbContext
	{
		public ECommDBContext(DbContextOptions<ECommDBContext> options) : base(options)
		{
		}
		// Define DbSets for your entities here
		public DbSet<DBSizeMaster> SizeMasters { get; set; }
		public DbSet<DBColorMaster> ColorMasters { get; set; }
		public DbSet<DBResponseInt> ResponseInts { get; set; }
		public DbSet<DBUserTypeMaster> UserTypeMasters { get; set; }
		public DbSet<DBCategoryMaster> CategoryMasters { get; set; }
		public DbSet<DBBrandLogoMaster> BrandLogoMasters { get; set; }

		public DbSet<DBUserMaster> UserMasters { get; set; }
		public DbSet<DBUserMaster_GetUserByUserType> UserMaster_GetUserByUserTypes { get; set; }
		public DbSet<DBUserMasterLogin> UserMasterLogins { get; set; }

	}
}
