using AutoMapper;
using BusinessEntities.Common;
using BusinessEntities.EComm.RequestDTO;
using BusinessEntities.EComm.ResponseDTO;
using BusinessService.EComm.Interface;
using Repositories.EComm.Implementation;
using Repositories.EComm.Interface;

namespace BusinessService.EComm.Implementation
{
	public class SizeMasterService : ISizeMasterService
	{
		private readonly ISizeMasterRepository _sizeMasterRepository;
		private IMapper _mapper;
		public SizeMasterService(SizeMasterRepository sizeMasterRepository, IMapper mapper)
		{
			_sizeMasterRepository = sizeMasterRepository;
			_mapper = mapper;
		}

		public SizeMasterService(ISizeMasterRepository sizeMasterRepository)
		{
			_sizeMasterRepository = sizeMasterRepository;
		}

		public ResultDto<long> Add(SizeMasterRequest viewModel)
		{
			var res = new ResultDto<long>()
			{
				IsSuccess = false,
				Data = 0,
				Errors = new List<string>()
			};
			var response = _sizeMasterRepository.Add(viewModel);
			if (response== -1)
			{
				res.Errors.Add("Size Master with the same name already exists.");
			}
			else if(response == -2)
			{
				res.Errors.Add("Failed to add size master due to database error."); 
			}
			else if (response > 0)
			{
				res.IsSuccess = true;
				res.Data = response;
			}
			

				return res;


		}

		public ResultDto<long> Delete(long Id)
		{
			var res = new ResultDto<long>()
			{
				IsSuccess = false,
				Data = 0,
				Errors = new List<string>()
			};
			var response = _sizeMasterRepository.Delete(Id);
			if (response == -1)
			{
				res.Errors.Add("Size Master is in use and cannot be deleted.");
			}
			else if (response == -2)
			{
				res.Errors.Add("Failed to delete size master due to database error.");
			}
			else if (response > 0)
			{
				res.IsSuccess = true;
				res.Data = response;
			}
			return res;
		}

		public ResultDto<IEnumerable<SizeMasterResponse>> GetAll()
		{
			var res= new ResultDto<IEnumerable<SizeMasterResponse>>()
			{
				IsSuccess = false,
				Data = Enumerable.Empty<SizeMasterResponse>(),
				Errors = new List<string>()
			};
			var response = _sizeMasterRepository.GetAll();
			if (response ==null)
			{
				res.Errors.Add("Data not Found");
			}
			else
			{
				res.IsSuccess = true;
				res.Data = _mapper.Map<IEnumerable<SizeMasterResponse>>(response);
			}
			return res;
		}

		public ResultDto<SizeMasterResponse> GetById(long Id)
		{
			var res = new ResultDto<SizeMasterResponse>()
			{
				IsSuccess = false,
				Data = null,
				Errors = new List<string>()
			};
			var response = _sizeMasterRepository.GetById(Id);
			if (response == null)
			{
				res.Errors.Add("Data not Found");
			}
			else
			{
				res.IsSuccess = true;
				res.Data = _mapper.Map<SizeMasterResponse>(response);
			}
			return res;
		}

		public ResultDto<long> Update(SizeMasterRequest Viewmodel)
		{

			var res = new ResultDto<long>()
			{
				IsSuccess = false,
				Data = 0,
				Errors = new List<string>()
			};

			return res;

		}
	}
}
