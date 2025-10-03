using AutoMapper;
using BusinessEntities.Common;
using BusinessEntities.EComm.RequestDTO;
using BusinessEntities.EComm.ResponseDTO;
using BusinessService.EComm.Interface;
using Repositories.EComm.Interface;

namespace BusinessService.EComm.Implementation
{
	public class UserMasterService : IUserMasterService
	{
		private readonly IUserMasterRepository _repository;
		private IMapper _mapper;

		public UserMasterService(IUserMasterRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public ApiResponse<long> Add(UserMasterRequest viewModel)
		{
			var response = _repository.Add(viewModel);
			if (response.Value == -1)
			{
				return ApiResponse<long>.Failure("User Master with the same name Email Id already exists.");
			}
			return ApiResponse<long>.Success(response.Value);
		}

		public ApiResponse<long> Delete(long id)
		{
			var response = _repository.Delete(id);
			if (response.Value == -1)
			{
				return ApiResponse<long>.Failure("Data Not Found.");
			}
			return ApiResponse<long>.Success(response.Value);
		}

		public ApiResponse<IEnumerable<UserMasterResponse>> GetAll(GetAllUserListRequest viewModel)
		{
			var response = _repository.GetAll(viewModel);
			if (response == null)
			{
				return ApiResponse<IEnumerable<UserMasterResponse>>.Failure("Data Not Found !!");
			}
			return ApiResponse<IEnumerable<UserMasterResponse>>.Success(_mapper.Map<IEnumerable<UserMasterResponse>>(response));
		}

		public ApiResponse<UserMasterResponse> GetById(long id)
		{
			var response = _repository.GetById(id);
			if (response == null || response.Id == 0)
			{
				return ApiResponse<UserMasterResponse>.Failure("Data Not Found !!");
			}
			return ApiResponse<UserMasterResponse>.Success(_mapper.Map<UserMasterResponse>(response));
		}

		public ApiResponse<IEnumerable<UserMaster_GetUserByUserTypeResponse>> GetUserByUserType(GetUserByUserTypeRequest viewModel)
		{
			var response = _repository.GetUserByUserType(viewModel);
			if (response == null)
			{
				return ApiResponse<IEnumerable<UserMaster_GetUserByUserTypeResponse>>.Failure("Data Not Found !!");
			}
			return ApiResponse<IEnumerable<UserMaster_GetUserByUserTypeResponse>>.Success(_mapper.Map<IEnumerable<UserMaster_GetUserByUserTypeResponse>>(response));
		}

		public ApiResponse<UserMasterLoginResponse> Login(LoginRequest viewModel)
		{
			var response = _repository.Login(viewModel);
			if (response == null || response.Id == 0)
			{
				return ApiResponse<UserMasterLoginResponse>.Failure("User Not Found !!");
			}
			return ApiResponse<UserMasterLoginResponse>.Success(_mapper.Map<UserMasterLoginResponse>(response));
		}

		public ApiResponse<long> Update(UserMasterRequest viewModel)
		{
			var response = _repository.Update(viewModel);
			if (response.Value == -1)
			{
				return ApiResponse<long>.Failure("User Master with the same name Email Id already exists.");
			}
			else if (response.Value == -2)
			{
				return ApiResponse<long>.Failure("User does not exists.");
			}
			return ApiResponse<long>.Success(response.Value);
		}

		public ApiResponse<long> UpdateProfile(UpdateProfileRequest viewModel)
		{
			var response = _repository.UpdateProfile(viewModel);
			if (response.Value == -1)
			{
				return ApiResponse<long>.Failure("User Not Found.");
			}
			return ApiResponse<long>.Success(response.Value);
		}
	}
}
