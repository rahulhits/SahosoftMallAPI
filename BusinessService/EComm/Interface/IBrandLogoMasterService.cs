using BusinessEntities.Common;
using BusinessEntities.EComm.RequestDTO;
using BusinessEntities.EComm.ResponseDTO;

namespace BusinessService.EComm.Interface
{
	public interface IBrandLogoMasterService
	{
		ApiResponse<long> Add(BrandLogoMasterRequest viewModel);
		ApiResponse<long> Update(BrandLogoMasterRequest viewModel);
		ApiResponse<long> Delete(long id);
		ApiResponse<IEnumerable<BrandLogoMasterResponse>> GetAll(GetAllByUserId viewModel);
		ApiResponse<BrandLogoMasterResponse> GetById(long id);
	}
}
