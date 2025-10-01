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
		ResultDto<long> Add(SizeMasterRequest viewModel);
		ResultDto<long> Update(SizeMasterRequest viewModel);
		ResultDto<long> Delete(long id);
		ResultDto<IEnumerable<SizeMasterResponse>> GetAll();
		ResultDto<SizeMasterResponse> GetById(long id);
	}
}
