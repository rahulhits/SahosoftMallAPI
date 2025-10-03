namespace Repositories.EComm.Common
{
	public class BaseEntity
	{
		public string? Status { get; set; }
		public int CreatedBy { get; set; }
		public int? ModifiedBy { get; set; }
		public string? CreatedOn { get; set; }
		public string? ModifiedOn { get; set; }
	}
}
