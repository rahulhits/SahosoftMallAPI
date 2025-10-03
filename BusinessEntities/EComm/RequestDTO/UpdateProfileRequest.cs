using BusinessEntities.Common;

namespace BusinessEntities.EComm.RequestDTO
{
	public class UpdateProfileRequest : BaseRequest
	{
		public int Id { get; set; }
		public string ImagePath { get; set; }
	}
}
