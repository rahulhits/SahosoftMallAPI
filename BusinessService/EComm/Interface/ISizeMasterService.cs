using BusinessEntities.Common;
using BusinessEntities.EComm.RequestDTO;
using BusinessEntities.EComm.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService.EComm.Interface
{
	public interface ISizeMasterService
	{
		ApiResponse<long> Add(SizeMasterRequest viewModel);
		ApiResponse<long> Update(SizeMasterRequest viewModel);
		ApiResponse<long> Delete(long id);
		ApiResponse<IEnumerable<SizeMasterResponse>> GetAll();
		ApiResponse<SizeMasterResponse> GetById(long id);
	}
}
