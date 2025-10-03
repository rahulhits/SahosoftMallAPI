﻿using Repositories.EComm.Common;

namespace Repositories.EComm.DbEntity
{
	public class DBUserMaster : BaseEntity
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public int UserTypeId { get; set; }
		public string UserType { get; set; }
		public string ImagePath { get; set; }
	}
}
