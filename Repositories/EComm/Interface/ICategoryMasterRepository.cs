using BusinessEntities.Common;
using BusinessEntities.EComm.RequestDTO;
using Repositories.EComm.Common;
using Repositories.EComm.DbEntity;

namespace Repositories.EComm.Interface
{
	public interface ICategoryMasterRepository
	{
		DBResponseInt Add(CategoryMasterRequest viewModel);
		DBResponseInt Update(CategoryMasterRequest viewModel);
		DBResponseInt Delete(long id);
		IEnumerable<DBCategoryMaster> GetAll(GetAllByUserId viewModel);
		DBCategoryMaster GetById(long id);
	}
}
