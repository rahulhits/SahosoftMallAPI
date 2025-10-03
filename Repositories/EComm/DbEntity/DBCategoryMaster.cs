using Repositories.EComm.Common;

namespace Repositories.EComm.DbEntity
{
	public class DBCategoryMaster : BaseEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Title { get; set; }
		public string ImagePath { get; set; }
		public int IsSave { get; set; }
		public string Link { get; set; }
		public string CreatedByName { get; set; }
		public string CreatedByUserType { get; set; }
	}
}
