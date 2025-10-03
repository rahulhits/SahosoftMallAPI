using BusinessEntities.Common;
using BusinessEntities.EComm.RequestDTO;
using BusinessEntities.EComm.ResponseDTO;

namespace BusinessService.EComm.Interface
{
	public interface IUserMasterService
	{
		ApiResponse<long> Add(UserMasterRequest viewModel);
		ApiResponse<long> Update(UserMasterRequest viewModel);
		ApiResponse<long> Delete(long id);
		ApiResponse<IEnumerable<UserMasterResponse>> GetAll(GetAllUserListRequest viewModel);
		ApiResponse<UserMasterResponse> GetById(long id);
		ApiResponse<UserMasterLoginResponse> Login(LoginRequest viewModel);
		ApiResponse<long> UpdateProfile(UpdateProfileRequest viewModel);
		ApiResponse<IEnumerable<UserMaster_GetUserByUserTypeResponse>> GetUserByUserType(GetUserByUserTypeRequest viewModel);
	}
}
