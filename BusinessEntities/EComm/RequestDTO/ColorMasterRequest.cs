using BusinessEntities.Common;

namespace BusinessEntities.EComm.RequestDTO
{
	public class ColorMasterRequest : BaseRequest
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Code { get; set; }
	}
}
