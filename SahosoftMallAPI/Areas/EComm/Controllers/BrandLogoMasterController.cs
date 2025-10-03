using BusinessEntities.Common;
using BusinessEntities.EComm.RequestDTO;
using BusinessEntities.EComm.ResponseDTO;
using BusinessService.EComm.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace SahosoftMallAPI.Areas.EComm.Controllers
{
	[Area("EComm")]
	[Route("api/ecomm/[controller]")]
	[ApiController]
	public class BrandLogoMasterController : ControllerBase
	{

		private readonly IBrandLogoMasterService _BrandLogoMasterService;
		public BrandLogoMasterController(IBrandLogoMasterService BrandLogoMasterService)
		{
			_BrandLogoMasterService = BrandLogoMasterService;
		}

		[ProducesResponseType(typeof(ApiResponse<IEnumerable<BrandLogoMasterResponse>>), 200)]
		[ProducesResponseType(typeof(ApiResponse<IEnumerable<BrandLogoMasterResponse>>), 404)]
		[HttpPost("GetAll")]
		public IActionResult GetAll(GetAllByUserId model)
		{
			var response = _BrandLogoMasterService.GetAll(model);
			if (response.IsSuccess)
			{
				return Ok(response);
			}
			return NotFound(response);
		}

		[ProducesResponseType(typeof(ApiResponse<BrandLogoMasterResponse>), 200)]
		[ProducesResponseType(typeof(ApiResponse<BrandLogoMasterResponse>), 404)]
		[HttpGet("GetById/{id}")]
		public IActionResult GetById(long id)
		{
			var response = _BrandLogoMasterService.GetById(id);
			if (response.IsSuccess)
			{
				return Ok(response);
			}
			return NotFound(response);
		}

		[ProducesResponseType(typeof(ApiResponse<long>), 200)]
		[ProducesResponseType(typeof(ApiResponse<long>), 400)]
		[HttpPost("Save")]
		public IActionResult Add()
		{
			var LogoName = Request.Form["Name"][0];
			var CreatedBy = Convert.ToInt32(Request.Form["UserId"][0]);
			var PostedFile = Request.Form.Files["Image"];
			var FolderName = @"wwwroot\Images\EComm";
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

				BrandLogoMasterRequest viewModel = new BrandLogoMasterRequest()
				{
					Name = LogoName,
					ImagePath = FileName,
					CreatedBy = CreatedBy
				};

				var response = _BrandLogoMasterService.Add(viewModel);
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

		[ProducesResponseType(typeof(ApiResponse<long>), 200)]
		[ProducesResponseType(typeof(ApiResponse<long>), 400)]
		[HttpPost("Update")]
		public IActionResult Update()
		{
			var Id = Convert.ToInt32(Request.Form["Id"][0]);
			var LogoName = Request.Form["Name"][0];
			var ModifiedBy = Convert.ToInt32(Request.Form["UserId"][0]);
			var PostedFile = Request.Form.Files["Image"];
			var FolderName = @"wwwroot\Images\EComm";
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

				BrandLogoMasterRequest viewModel = new BrandLogoMasterRequest()
				{
					Id = Id,
					Name = LogoName,
					ImagePath = FileName,
					ModifiedBy = ModifiedBy,
					ModifiedOn = DateTime.Now
				};

				var response = _BrandLogoMasterService.Update(viewModel);
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


		[ProducesResponseType(typeof(ApiResponse<long>), 200)]
		[ProducesResponseType(typeof(ApiResponse<long>), 404)]
		[HttpPost("Delete")]
		public IActionResult Delete([FromBody] ValueRequestInt model)
		{
			var response = _BrandLogoMasterService.Delete(model.Id);
			if (response.IsSuccess)
			{
				return Ok(response);
			}
			return NotFound(response);
		}
	}
}