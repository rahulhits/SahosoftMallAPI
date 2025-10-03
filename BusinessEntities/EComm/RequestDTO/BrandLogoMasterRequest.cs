using BusinessEntities.Common;

namespace BusinessEntities.EComm.RequestDTO
{
	public class BrandLogoMasterRequest : BaseRequest
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string ImagePath { get; set; }
	}
}
