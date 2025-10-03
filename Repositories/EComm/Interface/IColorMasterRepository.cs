using BusinessEntities.Common;
using BusinessEntities.EComm.RequestDTO;
using Repositories.EComm.Common;
using Repositories.EComm.DbEntity;

namespace Repositories.EComm.Interface
{
	public interface IColorMasterRepository
	{
		DBResponseInt Add(ColorMasterRequest viewModel);
		DBResponseInt Update(ColorMasterRequest viewModel);
		DBResponseInt Delete(long id);
		IEnumerable<DBColorMaster> GetAll(GetAllByUserId viewModel);
		DBColorMaster GetById(long id);
	}
}
