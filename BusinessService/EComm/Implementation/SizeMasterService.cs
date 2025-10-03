using AutoMapper;
using BusinessEntities.Common;
using BusinessEntities.EComm.RequestDTO;
using BusinessEntities.EComm.ResponseDTO;
using BusinessService.EComm.Interface;
using Repositories.EComm.Interface;

namespace BusinessService.EComm.Implementation
{
	public class SizeMasterService : ISizeMasterService
	{
		private readonly ISizeMasterRepository _sizeMasterRepository;
		private IMapper _mapper;
		public SizeMasterService(ISizeMasterRepository sizeMasterRepository, IMapper mapper)
		{
			_sizeMasterRepository = sizeMasterRepository;
			_mapper = mapper;
		}
		public ApiResponse<long> Add(SizeMasterRequest viewModel)
		{
			var response = _sizeMasterRepository.Add(viewModel);
			if (response.Value == -1)
			{
				return ApiResponse<long>.Failure("Size Master with the same name already exists.");
			}
			return ApiResponse<long>.Success(response.Value);
		}

		public ApiResponse<long> Delete(long id)
		{
			var response = _sizeMasterRepository.Delete(id);
			if (response.Value == -1)
			{
				return ApiResponse<long>.Failure("Data Not Found.");
			}
			return ApiResponse<long>.Success(response.Value);
		}
		public ApiResponse<IEnumerable<SizeMasterResponse>> GetAll(GetAllByUserId model)
		{
			var response = _sizeMasterRepository.GetAll(model);
			if (response == null)
			{
				return ApiResponse<IEnumerable<SizeMasterResponse>>.Failure("Data Not Found !!");
			}
			return ApiResponse<IEnumerable<SizeMasterResponse>>.Success(_mapper.Map<IEnumerable<SizeMasterResponse>>(response));
		}

		public ApiResponse<SizeMasterResponse> GetById(long id)
		{
			var response = _sizeMasterRepository.GetById(id);
			if (response == null || response.Id == 0)
			{
				return ApiResponse<SizeMasterResponse>.Failure("Data Not Found !!");
			}
			return ApiResponse<SizeMasterResponse>.Success(_mapper.Map<SizeMasterResponse>(response));
		}

		public ApiResponse<long> Update(SizeMasterRequest viewModel)
		{
			var response = _sizeMasterRepository.Update(viewModel);
			if (response.Value == -1)
			{
				return ApiResponse<long>.Failure("Size Master with the same name already exists.");
			}
			return ApiResponse<long>.Success(response.Value);
		}
	}
}
