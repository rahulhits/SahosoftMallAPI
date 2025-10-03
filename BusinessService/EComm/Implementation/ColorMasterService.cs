using AutoMapper;
using BusinessEntities.Common;
using BusinessEntities.EComm.RequestDTO;
using BusinessEntities.EComm.ResponseDTO;
using BusinessService.EComm.Interface;
using Repositories.EComm.Interface;

namespace BusinessService.EComm.Implementation
{
	public class ColorMasterService : IColorMasterService
	{
		private readonly IColorMasterRepository _colorMasterRepository;
		private readonly IMapper _mapper;

		public ColorMasterService(IColorMasterRepository colorMasterRepository, IMapper mapper)
		{
			_colorMasterRepository = colorMasterRepository;
			_mapper = mapper;
		}
		public ApiResponse<long> Add(ColorMasterRequest viewModel)
		{
			var response = _colorMasterRepository.Add(viewModel);
			if (response.Value == -1)
			{
				return ApiResponse<long>.Failure("color Master with the same name already exists.");
			}
			return ApiResponse<long>.Success(response.Value);
		}

		public ApiResponse<long> Delete(long id)
		{
			var response = _colorMasterRepository.Delete(id);
			if (response.Value == -1)
			{
				return ApiResponse<long>.Failure("Data Not Found.");
			}
			return ApiResponse<long>.Success(response.Value);
		}
		public ApiResponse<IEnumerable<ColorMasterResponse>> GetAll(GetAllByUserId model)
		{
			var response = _colorMasterRepository.GetAll(model);
			if (response == null)
			{
				return ApiResponse<IEnumerable<ColorMasterResponse>>.Failure("Data Not Found !!");
			}
			return ApiResponse<IEnumerable<ColorMasterResponse>>.Success(_mapper.Map<IEnumerable<ColorMasterResponse>>(response));
		}

		public ApiResponse<ColorMasterResponse> GetById(long id)
		{
			var response = _colorMasterRepository.GetById(id);
			if (response == null || response.Id == 0)
			{
				return ApiResponse<ColorMasterResponse>.Failure("Data Not Found !!");
			}
			return ApiResponse<ColorMasterResponse>.Success(_mapper.Map<ColorMasterResponse>(response));
		}

		public ApiResponse<long> Update(ColorMasterRequest viewModel)
		{
			var response = _colorMasterRepository.Update(viewModel);
			if (response.Value == -1)
			{
				return ApiResponse<long>.Failure("Color Master with the same name already exists.");
			}
			return ApiResponse<long>.Success(response.Value);
		}
	}
}
