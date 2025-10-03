using BusinessEntities.Common;
using BusinessEntities.EComm.RequestDTO;
using BusinessEntities.EComm.ResponseDTO;

namespace BusinessService.EComm.Interface
{
	public interface ICategoryMasterService
	{
		ApiResponse<long> Add(CategoryMasterRequest viewModel);
		ApiResponse<long> Update(CategoryMasterRequest viewModel);
		ApiResponse<long> Delete(long id);
		ApiResponse<IEnumerable<CategoryMasterResponse>> GetAll(GetAllByUserId viewModel);
		ApiResponse<CategoryMasterResponse> GetById(long id);
	}
}
