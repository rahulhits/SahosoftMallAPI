using BusinessEntities.Common;
using BusinessEntities.EComm.RequestDTO;
using BusinessEntities.EComm.ResponseDTO;

namespace BusinessService.EComm.Interface
{
	public interface IUserTypeMasterService
	{
		ApiResponse<long> Add(UserTypeMasterRequest viewModel);
		ApiResponse<long> Update(UserTypeMasterRequest viewModel);
		ApiResponse<long> Delete(long id);
		ApiResponse<IEnumerable<UserTypeMasterResponse>> GetAll(GetAllByUserId viewModel);
		ApiResponse<IEnumerable<UserTypeMasterResponse>> GetAllForUserRights(GetAllByUserId viewModel);
		ApiResponse<UserTypeMasterResponse> GetById(long Id);
	}
}
