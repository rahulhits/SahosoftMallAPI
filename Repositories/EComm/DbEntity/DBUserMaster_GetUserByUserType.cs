using Microsoft.EntityFrameworkCore;
using Repositories.EComm.Common;
using System.ComponentModel.DataAnnotations;

namespace Repositories.EComm.DbEntity
{
	//[Keyless]
	public class DBUserMaster_GetUserByUserType : BaseEntity
	{
		[Key]
		public int UserId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int UserTypeId { get; set; }
		public string UserType { get; set; }
	}
}
