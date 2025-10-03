using BusinessEntities.Common;

namespace BusinessEntities.EComm.RequestDTO
{
	public class CategoryMasterRequest : BaseRequest
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Title { get; set; }
		public string ImagePath { get; set; }
		public int IsSave { get; set; }
		public string Link { get; set; }
	}
}
