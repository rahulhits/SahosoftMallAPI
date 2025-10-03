using BusinessEntities.Common;

namespace BusinessEntities.EComm.RequestDTO
{
	public class UserTypeMasterRequest : BaseRequest
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
