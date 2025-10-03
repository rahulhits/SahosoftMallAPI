using BusinessEntities.Common;
using BusinessEntities.EComm.RequestDTO;
using BusinessEntities.EComm.ResponseDTO;
using BusinessService.EComm.Implementation;
using BusinessService.EComm.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace SahosoftMallAPI.Areas.EComm.Controllers
{
	[Area("EComm")]
	[Route("api/ecomm/[controller]")]
	[ApiController]
	public class UserMasterController : ControllerBase
	{
		private readonly IUserMasterService _UserMasterService;
		public UserMasterController(IUserMasterService UserMasterService)
		{
			_UserMasterService = UserMasterService;
		}

		[ProducesResponseType(typeof(ApiResponse<IEnumerable<UserMasterResponse>>), 200)]
		[ProducesResponseType(typeof(ApiResponse<IEnumerable<UserMasterResponse>>), 404)]
		[HttpPost("GetAll")]
		public IActionResult GetAll(GetAllUserListRequest model)
		{
			var response = _UserMasterService.GetAll(model);
			if (response.IsSuccess)
			{
				return Ok(response);
			}
			return NotFound(response);
		}

		[ProducesResponseType(typeof(ApiResponse<UserMasterResponse>), 200)]
		[ProducesResponseType(typeof(ApiResponse<UserMasterResponse>), 404)]
		[HttpGet("GetById/{id}")]
		public IActionResult GetById(long id)
		{
			var response = _UserMasterService.GetById(id);
			if (response.IsSuccess)
			{
				return Ok(response);
			}
			return NotFound(response);
		}

		[ProducesResponseType(typeof(ApiResponse<long>), 200)]
		[ProducesResponseType(typeof(ApiResponse<long>), 400)]
		[HttpPost("Save")]
		public IActionResult Add([FromBody] UserMasterRequest viewModel)
		{
			var response = _UserMasterService.Add(viewModel);
			if (response.IsSuccess)
			{
				return Ok(response);
			}
			return BadRequest(response);
		}

		[ProducesResponseType(typeof(ApiResponse<long>), 200)]
		[ProducesResponseType(typeof(ApiResponse<long>), 400)]
		[HttpPost("Update")]
		public IActionResult Update([FromBody] UserMasterRequest viewModel)
		{
			var response = _UserMasterService.Update(viewModel);
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
			var response = _UserMasterService.Delete(model.Id);
			if (response.IsSuccess)
			{
				return Ok(response);
			}
			return NotFound(response);
		}

		[ProducesResponseType(typeof(ApiResponse<IEnumerable<UserMaster_GetUserByUserTypeResponse>>), 200)]
		[ProducesResponseType(typeof(ApiResponse<IEnumerable<UserMaster_GetUserByUserTypeResponse>>), 404)]
		[HttpPost("GetUserByUserType")]
		public IActionResult GetUserByUserType(GetUserByUserTypeRequest model)
		{
			var response = _UserMasterService.GetUserByUserType(model);
			if (response.IsSuccess)
			{
				return Ok(response);
			}
			return NotFound(response);
		}

		[ProducesResponseType(typeof(ApiResponse<IEnumerable<UserMasterLoginResponse>>), 200)]
		[ProducesResponseType(typeof(ApiResponse<IEnumerable<UserMasterLoginResponse>>), 404)]
		[HttpPost("Login")]
		public IActionResult Login([FromBody] LoginRequest viewModel)
		{
			var response = _UserMasterService.Login(viewModel);
			if (response.IsSuccess)
			{
				return Ok(response);
			}
			return BadRequest(response);
		}


		[ProducesResponseType(typeof(ApiResponse<long>), 200)]
		[ProducesResponseType(typeof(ApiResponse<long>), 400)]
		[HttpPost("UpdateProfile")]
		public IActionResult UpdateProfile()
		{
			var Id = Convert.ToInt32(Request.Form["Id"][0]);
			var ModifiedBy = Convert.ToInt32(Request.Form["UserId"][0]);
			var PostedFile = Request.Form.Files["Image"];
			var FolderName = @"wwwroot\Images\Users";
			var PathToSave = Path.Combine(Directory.GetCurrentDirectory(), FolderName);

			if (PostedFile == null || PostedFile.Length == 0)
			{
				return BadRequest(new ApiResponse<long> { IsSuccess = false, Errors = "No file uploaded." });
			}
			else
			{
				var FileName = ContentDispositionHeaderValue.Parse(PostedFile.ContentDisposition).FileName.Trim('"');
				var FullPath = Path.Combine(PathToSave, FileName);
				using (var stream = new FileStream(FullPath, FileMode.Create))
				{
					PostedFile.CopyTo(stream);
				}

				UpdateProfileRequest viewModel = new UpdateProfileRequest()
				{
					Id = Id,
					ImagePath = FileName,
					ModifiedBy = ModifiedBy,
					ModifiedOn = DateTime.Now
				};

				var response = _UserMasterService.UpdateProfile(viewModel);
				if (response.IsSuccess)
				{
					return Ok(response);
				}
				else
				{
					return BadRequest(response);
				}
			}
		}
	}
}
