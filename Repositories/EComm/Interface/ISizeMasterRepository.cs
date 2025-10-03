using BusinessEntities.Common;
using BusinessEntities.EComm.RequestDTO;
using Repositories.EComm.Common;
using Repositories.EComm.DbEntity;

namespace Repositories.EComm.Interface
{
	public interface ISizeMasterRepository
	{
		DBResponseInt Add(SizeMasterRequest viewModel);
		DBResponseInt Update(SizeMasterRequest viewModel);
		DBResponseInt Delete(long id);
		IEnumerable<DBSizeMaster> GetAll(GetAllByUserId viewModel);
		DBSizeMaster GetById(long id);
	}
}
