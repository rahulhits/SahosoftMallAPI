using AutoMapper;
using BusinessEntities.Common;
using BusinessEntities.EComm.RequestDTO;
using BusinessEntities.EComm.ResponseDTO;
using BusinessService.EComm.Interface;
using Repositories.EComm.Interface;

namespace BusinessService.EComm.Implementation
{
	public class BrandLogoMasterService : IBrandLogoMasterService
	{
		private readonly IBrandLogoMasterRepository _BrandLogoMasterRepository;
		private IMapper _mapper;
		public BrandLogoMasterService(IBrandLogoMasterRepository BrandLogoMasterRepository, IMapper mapper)
		{
			_BrandLogoMasterRepository = BrandLogoMasterRepository;
			_mapper = mapper;
		}
		public ApiResponse<long> Add(BrandLogoMasterRequest viewModel)
		{
			var response = _BrandLogoMasterRepository.Add(viewModel);
			if (response.Value == -1)
			{
				return ApiResponse<long>.Failure("BrandLogo with the same name already exists.");
			}
			return ApiResponse<long>.Success(response.Value);
		}

		public ApiResponse<long> Delete(long id)
		{
			var response = _BrandLogoMasterRepository.Delete(id);
			if (response.Value == -1)
			{
				return ApiResponse<long>.Failure("Data Not Found.");
			}
			return ApiResponse<long>.Success(response.Value);
		}
		public ApiResponse<IEnumerable<BrandLogoMasterResponse>> GetAll(GetAllByUserId model)
		{
			var response = _BrandLogoMasterRepository.GetAll(model);
			if (response == null)
			{
				return ApiResponse<IEnumerable<BrandLogoMasterResponse>>.Failure("Data Not Found !!");
			}
			return ApiResponse<IEnumerable<BrandLogoMasterResponse>>.Success(_mapper.Map<IEnumerable<BrandLogoMasterResponse>>(response));
		}

		public ApiResponse<BrandLogoMasterResponse> GetById(long id)
		{
			var response = _BrandLogoMasterRepository.GetById(id);
			if (response == null || response.Id == 0)
			{
				return ApiResponse<BrandLogoMasterResponse>.Failure("Data Not Found !!");
			}
			return ApiResponse<BrandLogoMasterResponse>.Success(_mapper.Map<BrandLogoMasterResponse>(response));
		}

		public ApiResponse<long> Update(BrandLogoMasterRequest viewModel)
		{
			var response = _BrandLogoMasterRepository.Update(viewModel);
			if (response.Value == -1)
			{
				return ApiResponse<long>.Failure("BrandLogo with the same name already exists.");
			}
			return ApiResponse<long>.Success(response.Value);
		}
	}
}