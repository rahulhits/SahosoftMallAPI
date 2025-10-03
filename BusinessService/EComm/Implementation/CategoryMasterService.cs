using AutoMapper;
using BusinessEntities.Common;
using BusinessEntities.EComm.RequestDTO;
using BusinessEntities.EComm.ResponseDTO;
using BusinessService.EComm.Interface;
using Repositories.EComm.Interface;

namespace BusinessService.EComm.Implementation
{
	public class CategoryMasterService : ICategoryMasterService
	{
		private readonly ICategoryMasterRepository _repository;
		private IMapper _mapper;

		public CategoryMasterService(ICategoryMasterRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public ApiResponse<long> Add(CategoryMasterRequest viewModel)
		{
			var response = _repository.Add(viewModel);
			if (response.Value == -1)
			{
				return ApiResponse<long>.Failure("Category with the same name already exists.");
			}
			else if (response.Value == -2)
			{
				return ApiResponse<long>.Failure("You Cannot add more then 2 Categories.");
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

		public ApiResponse<IEnumerable<CategoryMasterResponse>> GetAll(GetAllByUserId viewModel)
		{
			var response = _repository.GetAll(viewModel);
			if (response == null)
			{
				return ApiResponse<IEnumerable<CategoryMasterResponse>>.Failure("Data Not Found !!");
			}
			return ApiResponse<IEnumerable<CategoryMasterResponse>>.Success(_mapper.Map<IEnumerable<CategoryMasterResponse>>(response));
		}

		public ApiResponse<CategoryMasterResponse> GetById(long Id)
		{
			var response = _repository.GetById(Id);
			if (response == null || response.Id == 0)
			{
				return ApiResponse<CategoryMasterResponse>.Failure("Data Not Found !!");
			}
			return ApiResponse<CategoryMasterResponse>.Success(_mapper.Map<CategoryMasterResponse>(response));
		}

		public ApiResponse<long> Update(CategoryMasterRequest viewModel)
		{
			var response = _repository.Update(viewModel);
			if (response.Value == -1)
			{
				return ApiResponse<long>.Failure("User Type Master with the same name already exists.");
			}
			else if (response.Value == -2)
			{
				return ApiResponse<long>.Failure("You Cannot add more then 2 Categories.");
			}
			return ApiResponse<long>.Success(response.Value);
		}
	}
}
