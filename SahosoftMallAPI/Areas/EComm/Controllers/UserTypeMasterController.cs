using BusinessEntities.Common;
using BusinessEntities.EComm.RequestDTO;
using BusinessEntities.EComm.ResponseDTO;
using BusinessService.EComm.Implementation;
using BusinessService.EComm.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SahosoftMallAPI.Areas.EComm.Controllers
{
	[Area("EComm")]
	[Route("api/[controller]")]
	[ApiController]
	public class UserTypeMasterController : ControllerBase
	{
		private readonly IUserTypeMasterService _service;

		public UserTypeMasterController(IUserTypeMasterService service)
		{
			_service = service;
		}

		[ProducesResponseType(typeof(ApiResponse<IEnumerable<UserTypeMasterResponse>>), 200)]
		[ProducesResponseType(typeof(ApiResponse<IEnumerable<UserTypeMasterResponse>>), 404)]
		[HttpPost("GetAll")]
		public IActionResult GetAll(GetAllByUserId model)
		{
			var response = _service.GetAll(model);
			if (response.IsSuccess)
			{
				return Ok(response);
			}
			return NotFound(response);
		}

		[ProducesResponseType(typeof(ApiResponse<IEnumerable<UserTypeMasterResponse>>), 200)]
		[ProducesResponseType(typeof(ApiResponse<IEnumerable<UserTypeMasterResponse>>), 404)]
		[HttpPost("GetAllForUserRights")]
		public IActionResult GetAllForUserRights(GetAllByUserId model)
		{
			var response = _service.GetAll(model);
			if (response.IsSuccess)
			{
				return Ok(response);
			}
			return NotFound(response);
		}

		[ProducesResponseType(typeof(ApiResponse<UserTypeMasterResponse>), 200)]
		[ProducesResponseType(typeof(ApiResponse<UserTypeMasterResponse>), 404)]
		[HttpGet("GetById/{id}")]
		public IActionResult GetById(long id)
		{
			var response = _service.GetById(id);
			if (response.IsSuccess)
			{
				return Ok(response);
			}
			return NotFound(response);
		}

		[ProducesResponseType(typeof(ApiResponse<long>), 200)]
		[ProducesResponseType(typeof(ApiResponse<long>), 400)]
		[HttpPost("Save")]
		public IActionResult Add([FromBody] UserTypeMasterRequest viewModel)
		{
			var response = _service.Add(viewModel);
			if (response.IsSuccess)
			{
				return Ok(response);
			}
			return BadRequest(response);
		}

		[ProducesResponseType(typeof(ApiResponse<long>), 200)]
		[ProducesResponseType(typeof(ApiResponse<long>), 400)]
		[HttpPost("Update")]
		public IActionResult Update([FromBody] UserTypeMasterRequest viewModel)
		{
			var response = _service.Update(viewModel);
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
			var response = _service.Delete(model.Id);
			if (response.IsSuccess)
			{
				return Ok(response);
			}
			return NotFound(response);
		}
	}
}
