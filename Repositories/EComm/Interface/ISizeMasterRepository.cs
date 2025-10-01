using BusinessEntities.EComm.RequestDTO;
using Repositories.EComm.DbEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EComm.Interface
{
	
	public interface ISizeMasterRepository
	{
		long Add(SizeMasterRequest viewModel);

		long Update(SizeMasterRequest Viewmodel);
		long Delete(long Id);

		IEnumerable<DBSizeMaster> GetAll();
		DBSizeMaster GetById(long Id);

	}
}
