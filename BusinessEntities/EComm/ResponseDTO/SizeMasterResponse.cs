using BusinessEntities.Common;

namespace BusinessEntities.EComm.ResponseDTO
{
	public class SizeMasterResponse : BaseResponse
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? CreatedByName { get; set; }
		public string? CreatedByUserType { get; set; }
	}
}
