using BusinessEntities.Common;
using BusinessEntities.EComm.RequestDTO;
using BusinessEntities.EComm.ResponseDTO;
using BusinessService.EComm.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SahosoftMallAPI.Areas.EComm.Controllers
{
	[Area("EComm")]
	[Route("api/[controller]")]
	[ApiController]
	public class ColorMasterController : ControllerBase
	{
		private readonly IColorMasterService _colorMasterService;
		public ColorMasterController(IColorMasterService colorMasterService)
		{
			_colorMasterService = colorMasterService;
		}

		[ProducesResponseType(typeof(ApiResponse<long>), 200)]
		[ProducesResponseType(typeof(ApiResponse<long>), 400)]
		[HttpPost("Add")]
		public IActionResult Add(ColorMasterRequest viewModel)
		{
			var response = _colorMasterService.Add(viewModel);
			if (!response.IsSuccess)
			{
				return BadRequest(response);
			}
			return Ok(response);
		}

		[ProducesResponseType(typeof(ApiResponse<long>), 200)]
		[ProducesResponseType(typeof(ApiResponse<long>), 400)]
		[HttpPost("Update")]
		public IActionResult Update(ColorMasterRequest viewModel)
		{
			var response = _colorMasterService.Update(viewModel);
			if (!response.IsSuccess)
			{
				return BadRequest(response);
			}
			return Ok(response);
		}
		[ProducesResponseType(typeof(ApiResponse<long>), 200)]
		[ProducesResponseType(typeof(ApiResponse<long>), 400)]
		[HttpPost("Delete")]
		public IActionResult Delete([FromBody] ValueRequestInt model)
		{
			var response = _colorMasterService.Delete(model.Id);
			if (!response.IsSuccess)
			{
				return BadRequest(response);
			}
			return Ok(response);
		}

		[ProducesResponseType(typeof(ResultDto<IEnumerable<ColorMasterResponse>>), 200)]
		[ProducesResponseType(typeof(ResultDto<IEnumerable<ColorMasterResponse>>), 404)]
		[HttpPost("GetAll")]
		public IActionResult GetAll(GetAllByUserId model)
		{
			var response = _colorMasterService.GetAll(model);
			if (!response.IsSuccess)
			{
				return BadRequest(response);
			}
			return Ok(response);
		}

		[ProducesResponseType(typeof(ResultDto<ColorMasterResponse>), 200)]
		[ProducesResponseType(typeof(ResultDto<ColorMasterResponse>), 404)]
		[HttpGet("GetById/{id}")]
		public IActionResult GetById(long id)
		{
			var response = _colorMasterService.GetById(id);
			if (!response.IsSuccess)
			{
				return BadRequest(response);
			}
			return Ok(response);
		}
	}
}
