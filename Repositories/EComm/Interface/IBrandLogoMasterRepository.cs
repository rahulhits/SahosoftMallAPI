using BusinessEntities.Common;
using BusinessEntities.EComm.RequestDTO;
using Repositories.EComm.Common;
using Repositories.EComm.DbEntity;

namespace Repositories.EComm.Interface
{
	public interface IBrandLogoMasterRepository
	{
		DBResponseInt Add(BrandLogoMasterRequest viewModel);
		DBResponseInt Update(BrandLogoMasterRequest viewModel);
		DBResponseInt Delete(long id);
		IEnumerable<DBBrandLogoMaster> GetAll(GetAllByUserId viewModel);
		DBBrandLogoMaster GetById(long id);
	}
}
