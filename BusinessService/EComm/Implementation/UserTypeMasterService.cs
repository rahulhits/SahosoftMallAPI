using AutoMapper;
using BusinessEntities.Common;
using BusinessEntities.EComm.RequestDTO;
using BusinessEntities.EComm.ResponseDTO;
using BusinessService.EComm.Interface;
using Repositories.EComm.Implementation;
using Repositories.EComm.Interface;

namespace BusinessService.EComm.Implementation
{
	public class UserTypeMasterService : IUserTypeMasterService
	{
		private readonly IUserTypeMasterRepository _repository;
		private IMapper _mapper;

		public UserTypeMasterService(IUserTypeMasterRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public ApiResponse<long> Add(UserTypeMasterRequest viewModel)
		{
			var response = _repository.Add(viewModel);
			if (response.Value == -1)
			{
				return ApiResponse<long>.Failure("User Type Master with the same name already exists.");
			}
			else if (response.Value == -2)
			{
				return ApiResponse<long>.Failure("You Cannot add Admin and Super Admin User Type.");
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
			else if (response.Value == -2)
			{
				return ApiResponse<long>.Failure("Failed to delete User Type Master due to a database error.");
			}
			return ApiResponse<long>.Success(response.Value);
		}

		public ApiResponse<IEnumerable<UserTypeMasterResponse>> GetAll(GetAllByUserId viewModel)
		{
			var response = _repository.GetAll(viewModel);
			if (response == null)
			{
				return ApiResponse<IEnumerable<UserTypeMasterResponse>>.Failure("Data Not Found !!");
			}
			return ApiResponse<IEnumerable<UserTypeMasterResponse>>.Success(_mapper.Map<IEnumerable<UserTypeMasterResponse>>(response));
		}

		public ApiResponse<IEnumerable<UserTypeMasterResponse>> GetAllForUserRights(GetAllByUserId viewModel)
		{
			var response = _repository.GetAllForUserRights(viewModel);
			if (response == null)
			{
				return ApiResponse<IEnumerable<UserTypeMasterResponse>>.Failure("Data Not Found !!");
			}
			return ApiResponse<IEnumerable<UserTypeMasterResponse>>.Success(_mapper.Map<IEnumerable<UserTypeMasterResponse>>(response));
		}

		public ApiResponse<UserTypeMasterResponse> GetById(long Id)
		{
			var response = _repository.GetById(Id);
			if (response == null || response.Id == 0)
			{
				return ApiResponse<UserTypeMasterResponse>.Failure("Data Not Found !!");
			}
			return ApiResponse<UserTypeMasterResponse>.Success(_mapper.Map<UserTypeMasterResponse>(response));
		}

		public ApiResponse<long> Update(UserTypeMasterRequest viewModel)
		{
			var response = _repository.Update(viewModel);
			if (response.Value == -1)
			{
				return ApiResponse<long>.Failure("User Type Master with the same name already exists.");
			}
			else if (response.Value == -2)
			{
				return ApiResponse<long>.Failure("You Cannot add Admin and Super Admin User Type.");
			}
			return ApiResponse<long>.Success(response.Value);
		}
	}
}
