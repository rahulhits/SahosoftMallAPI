using BusinessEntities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EComm.DbEntity
{
	public class DBSizeMaster: BaseEntity
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? CreatedByName { get; set; }
		public string? CreatedByUserType { get; set; }
		//public string? Status { get; set; }
		//public int CreatedBy { get; set; }
		//public int? ModifiedBy { get; set; }
		//public string? CreatedOn { get; set; }
		//public string? ModifiedOn { get; set; }


	}
}
