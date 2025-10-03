using BusinessEntities.Common;
using BusinessEntities.EComm.RequestDTO;
using Repositories.EComm.Common;
using Repositories.EComm.DbEntity;

namespace Repositories.EComm.Interface
{
	public interface IUserTypeMasterRepository
	{
		DBResponseInt Add(UserTypeMasterRequest viewModel);
		DBResponseInt Update(UserTypeMasterRequest viewModel);
		DBResponseInt Delete(long Id);
		IEnumerable<DBUserTypeMaster> GetAll(GetAllByUserId viewModel);
		DBUserTypeMaster GetById(long Id);
		IEnumerable<DBUserTypeMaster> GetAllForUserRights(GetAllByUserId viewModel);
	}
}
