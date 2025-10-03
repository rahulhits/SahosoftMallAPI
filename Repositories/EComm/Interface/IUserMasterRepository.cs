using BusinessEntities.EComm.RequestDTO;
using Repositories.EComm.Common;
using Repositories.EComm.DbEntity;

namespace Repositories.EComm.Interface
{
	public interface IUserMasterRepository
	{
		DBResponseInt Add(UserMasterRequest viewModel);
		DBResponseInt Update(UserMasterRequest viewModel);
		DBResponseInt Delete(long id);
		IEnumerable<DBUserMaster> GetAll(GetAllUserListRequest viewModel);
		DBUserMaster GetById(long id);
		DBUserMasterLogin Login(LoginRequest viewModel);
		DBResponseInt UpdateProfile(UpdateProfileRequest viewModel);
		IEnumerable<DBUserMaster_GetUserByUserType> GetUserByUserType(GetUserByUserTypeRequest viewModel);
	}
}
