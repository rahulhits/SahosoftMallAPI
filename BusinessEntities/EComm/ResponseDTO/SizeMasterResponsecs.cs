using BusinessEntities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EComm.ResponseDTO
{
	public class SizeMasterResponsecs:BaseResponse
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? CreatedByName { get; set; }
		public string? CreatedByUserType { get; set; }
	}
}
