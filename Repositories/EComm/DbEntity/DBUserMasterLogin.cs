namespace Repositories.EComm.DbEntity
{
	public class DBUserMasterLogin
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public int UserTypeId { get; set; }
		public string UserType { get; set; }
		public string ImagePath { get; set; }
		public string Token { get; set; }
		public string Rts { get; set; }
	}
}
