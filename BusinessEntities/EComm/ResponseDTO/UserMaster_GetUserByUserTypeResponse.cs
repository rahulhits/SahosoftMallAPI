using BusinessEntities.Common;

namespace BusinessEntities.EComm.ResponseDTO
{
	public class UserMaster_GetUserByUserTypeResponse : BaseResponse
	{
		public int UserId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int UserTypeId { get; set; }
		public string UserType { get; set; }
	}
}
