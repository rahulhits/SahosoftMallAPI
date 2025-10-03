using Repositories.EComm.Common;

namespace Repositories.EComm.DbEntity
{
	public class DBBrandLogoMaster : BaseEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string ImagePath { get; set; }
		public string CreatedByName { get; set; }
		public string CreatedByUserType { get; set; }
	}
}
