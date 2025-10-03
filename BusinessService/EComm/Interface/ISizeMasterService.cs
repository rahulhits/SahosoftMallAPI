using BusinessEntities.Common;
using BusinessEntities.EComm.RequestDTO;
using BusinessEntities.EComm.ResponseDTO;

namespace BusinessService.EComm.Interface
{
	public interface ISizeMasterService
	{
		ApiResponse<long> Add(SizeMasterRequest viewModel);
		ApiResponse<long> Update(SizeMasterRequest viewModel);
		ApiResponse<long> Delete(long id);
		ApiResponse<IEnumerable<SizeMasterResponse>> GetAll(GetAllByUserId viewModel);
		ApiResponse<SizeMasterResponse> GetById(long id);
	}
}
