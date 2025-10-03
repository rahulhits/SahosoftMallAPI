using BusinessEntities.Common;
using BusinessEntities.EComm.RequestDTO;
using BusinessEntities.EComm.ResponseDTO;

namespace BusinessService.EComm.Interface
{
	public interface IColorMasterService
	{
		ApiResponse<long> Add(ColorMasterRequest viewModel);
		ApiResponse<long> Update(ColorMasterRequest viewModel);
		ApiResponse<long> Delete(long id);
		ApiResponse<IEnumerable<ColorMasterResponse>> GetAll(GetAllByUserId viewModel);
		ApiResponse<ColorMasterResponse> GetById(long id);
	}
}
