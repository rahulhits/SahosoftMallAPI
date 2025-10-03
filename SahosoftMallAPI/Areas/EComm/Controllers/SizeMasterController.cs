using BusinessEntities.Common;
using BusinessEntities.EComm.RequestDTO;
using BusinessEntities.EComm.ResponseDTO;
using BusinessService.EComm.Interface;
using Microsoft.AspNetCore.Mvc;

namespace SahosoftMallAPI.Areas.EComm.Controllers
{
	[Area("EComm")]
	[Route("api/ecomm/[controller]")]
	[ApiController]
	public class SizeMasterController : ControllerBase
	{
		private readonly ISizeMasterService _sizeMasterService;
		public SizeMasterController(ISizeMasterService sizeMasterService)
		{
			_sizeMasterService = sizeMasterService;
		}

		[ProducesResponseType(typeof(ApiResponse<IEnumerable<SizeMasterResponse>>), 200)]
		[ProducesResponseType(typeof(ApiResponse<IEnumerable<SizeMasterResponse>>), 404)]
		[HttpPost("GetAll")]
		public IActionResult GetAll(GetAllByUserId model)
		{
			var response = _sizeMasterService.GetAll(model);
			if (response.IsSuccess)
			{
				return Ok(response);
			}
			return NotFound(response);
		}

		[ProducesResponseType(typeof(ApiResponse<SizeMasterResponse>), 200)]
		[ProducesResponseType(typeof(ApiResponse<SizeMasterResponse>), 404)]
		[HttpGet("GetById/{id}")]
		public IActionResult GetById(long id)
		{
			var response = _sizeMasterService.GetById(id);
			if (response.IsSuccess)
			{
				return Ok(response);
			}
			return NotFound(response);
		}

		[ProducesResponseType(typeof(ApiResponse<long>), 200)]
		[ProducesResponseType(typeof(ApiResponse<long>), 400)]
		[HttpPost("Save")]
		public IActionResult Add([FromBody] SizeMasterRequest viewModel)
		{
			var response = _sizeMasterService.Add(viewModel);
			if (response.IsSuccess)
			{
				return Ok(response);
			}
			return BadRequest(response);
		}

		[ProducesResponseType(typeof(ApiResponse<long>), 200)]
		[ProducesResponseType(typeof(ApiResponse<long>), 400)]
		[HttpPost("Update")]
		public IActionResult Update([FromBody] SizeMasterRequest viewModel)
		{
			var response = _sizeMasterService.Update(viewModel);
			if (response.IsSuccess)
			{
				return Ok(response);
			}
			return BadRequest(response);
		}


		[ProducesResponseType(typeof(ApiResponse<long>), 200)]
		[ProducesResponseType(typeof(ApiResponse<long>), 404)]
		[HttpPost("Delete")]
		public IActionResult Delete([FromBody] ValueRequestInt model)
		{
			var response = _sizeMasterService.Delete(model.Id);
			if (response.IsSuccess)
			{
				return Ok(response);
			}
			return NotFound(response);
		}
	}
}
