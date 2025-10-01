using BusinessEntities.Common;
using BusinessEntities.EComm.RequestDTO;
using BusinessEntities.EComm.ResponseDTO;
using BusinessService.EComm.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SahosoftMallAPI.Areas.EComm.Controllers
{
	[Area("EComm")]
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class SizeController : ControllerBase
	{
		private readonly ISizeMasterService sizeMasterService;
		public SizeController(ISizeMasterService sizeMasterService)
		{
			sizeMasterService = sizeMasterService;
		}

		[ProducesResponseType(typeof(ResultDto<IEnumerable<SizeMasterResponse>>), 200)]
		[ProducesResponseType(typeof(ResultDto<IEnumerable<SizeMasterResponse>>), 404)]

		[HttpGet("GetAll")]
		public IActionResult GetAll()
		{
			var response = sizeMasterService.GetAll();
			if (response.IsSuccess)
			{
				return Ok(response);
			}
			return NotFound(response);
		}

		[ProducesResponseType(typeof(ResultDto<IEnumerable<SizeMasterResponse>>), 200)]
		[ProducesResponseType(typeof(ResultDto<IEnumerable<SizeMasterResponse>>), 404)]

		[HttpGet("GetById/{id}")]
		public IActionResult GetById(long id)
		{
			var response = sizeMasterService.GetById(id);
			if (response.IsSuccess)
			{
				return Ok(response);
			}
			return NotFound(response);
		}

		[ProducesResponseType(typeof(ResultDto<IEnumerable<SizeMasterResponse>>), 200)]
		[ProducesResponseType(typeof(ResultDto<IEnumerable<SizeMasterResponse>>), 400)]

		[HttpPost("Save")]
		public IActionResult Add([FromBody] SizeMasterRequest viewModel)
		{
			var response = sizeMasterService.Add(viewModel);
			if (response.IsSuccess)
			{
				return Ok(response);
			}
			return NotFound(response);
		}


		[ProducesResponseType(typeof(ResultDto<IEnumerable<SizeMasterResponse>>), 200)]
		[ProducesResponseType(typeof(ResultDto<IEnumerable<SizeMasterResponse>>), 400)]

		[HttpPost("Update")]
		public IActionResult Update([FromBody] SizeMasterRequest viewModel)
		{
			var response = sizeMasterService.Update(viewModel);

			if (response.IsSuccess)
			{
				return Ok(response);
			}
			return BadRequest(response);
		}


		[ProducesResponseType(typeof(ResultDto<long>), 200)]
		[ProducesResponseType(typeof(ResultDto<long>), 404)]
		[HttpPost("Delete")]
		public IActionResult Delete([FromBody] ValueRequestInt model)
		{
			var response = sizeMasterService.Delete(model.Id);
			if (response.IsSuccess)
			{
				return Ok(response);
			}
			return NotFound(response);
		}

	}
}
