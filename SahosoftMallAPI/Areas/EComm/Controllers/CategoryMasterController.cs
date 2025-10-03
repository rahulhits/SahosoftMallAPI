using BusinessEntities.Common;
using BusinessEntities.EComm.RequestDTO;
using BusinessEntities.EComm.ResponseDTO;
using BusinessService.EComm.Implementation;
using BusinessService.EComm.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace SahosoftMallAPI.Areas.EComm.Controllers
{
	[Area("EComm")]
	[Route("api/ecomm/[controller]")]
	[ApiController]
	public class CategoryMasterController : ControllerBase
	{
		private readonly ICategoryMasterService _CategoryMasterService;
		public CategoryMasterController(ICategoryMasterService CategoryMasterService)
		{
			_CategoryMasterService = CategoryMasterService;
		}

		[ProducesResponseType(typeof(ApiResponse<IEnumerable<CategoryMasterResponse>>), 200)]
		[ProducesResponseType(typeof(ApiResponse<IEnumerable<CategoryMasterResponse>>), 404)]
		[HttpPost("GetAll")]
		public IActionResult GetAll(GetAllByUserId model)
		{
			var response = _CategoryMasterService.GetAll(model);
			if (response.IsSuccess)
			{
				return Ok(response);
			}
			return NotFound(response);
		}

		[ProducesResponseType(typeof(ApiResponse<CategoryMasterResponse>), 200)]
		[ProducesResponseType(typeof(ApiResponse<CategoryMasterResponse>), 404)]
		[HttpGet("GetById/{id}")]
		public IActionResult GetById(long id)
		{
			var response = _CategoryMasterService.GetById(id);
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
			var Title = Request.Form["Title"][0];
			var IsSave = Convert.ToInt32(Request.Form["IsSave"][0]);
			var Link = Request.Form["Link"][0];
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

				CategoryMasterRequest viewModel = new CategoryMasterRequest()
				{
					Name = LogoName,
					Title = Title,
					IsSave = IsSave,
					Link = Link,
					ImagePath = FileName,
					CreatedBy = CreatedBy
				};

				var response = _CategoryMasterService.Add(viewModel);
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
			var Title = Request.Form["Title"][0];
			var IsSave = Convert.ToInt32(Request.Form["IsSave"][0]);
			var Link = Request.Form["Link"][0];
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

				CategoryMasterRequest viewModel = new CategoryMasterRequest()
				{
					Id = Id,
					Name = LogoName,
					Title = Title,
					IsSave = IsSave,
					Link = Link,
					ImagePath = FileName,
					ModifiedBy = ModifiedBy,
					ModifiedOn = DateTime.Now
				};

				var response = _CategoryMasterService.Update(viewModel);
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
			var response = _CategoryMasterService.Delete(model.Id);
			if (response.IsSuccess)
			{
				return Ok(response);
			}
			return NotFound(response);
		}
	}
}
