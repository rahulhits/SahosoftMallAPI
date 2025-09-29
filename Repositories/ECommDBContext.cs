using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
	public class ECommDBContext:DbContext
	{
		public ECommDBContext(DbContextOptions<ECommDBContext> options) : base(options)
		{
		}
	}
}
