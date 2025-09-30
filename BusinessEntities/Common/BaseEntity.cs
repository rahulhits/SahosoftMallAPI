using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Common
{
	public class BaseEntity
	{
		public string? Status { get; set; }
		public int CreatedBy { get; set; }
		public int? ModifieddBy { get; set; }
		public string? CreatedOn { get; set; }
		public int? ModifiedOn { get;set; }
	}
}
