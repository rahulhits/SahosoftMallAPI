using BusinessEntities.Common;
using BusinessEntities.EComm.RequestDTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Repositories.EComm.Common;
using Repositories.EComm.DbEntity;
using Repositories.EComm.Interface;

namespace Repositories.EComm.Implementation
{
	public class CategoryMasterRepository : ICategoryMasterRepository
	{
		private ECommDBContext _context;
		public CategoryMasterRepository(ECommDBContext context)
		{
			_context = context;
		}
		public DBResponseInt Add(CategoryMasterRequest viewModel)
		{
			DBResponseInt response = _context.ResponseInts.FromSqlRaw(" execute InsertCategoryMaster @Name,@Title,@ImagePath,@IsSave,@Link,@CreatedBy",
				new SqlParameter("@Name", viewModel.Name),
				new SqlParameter("@Title", viewModel.Title),
				new SqlParameter("@ImagePath", viewModel.ImagePath),
				new SqlParameter("@IsSave", viewModel.IsSave),
				new SqlParameter("@Link", viewModel.Link),
				new SqlParameter("@CreatedBy", viewModel.CreatedBy)
				).AsEnumerable().FirstOrDefault() ?? new DBResponseInt();
			return response;
		}

		public DBResponseInt Delete(long id)
		{
			DBResponseInt response = _context.ResponseInts.FromSqlRaw(" execute DeleteCategoryMaster @Id",
					 new SqlParameter("@Id", id)
					 ).AsEnumerable().FirstOrDefault() ?? new DBResponseInt();
			return response;
		}

		public IEnumerable<DBCategoryMaster> GetAll(GetAllByUserId model)
		{
			IEnumerable<DBCategoryMaster> response = _context.CategoryMasters.FromSqlRaw("execute Proc_GetAll_CategoryMaster @UserId",
				  new SqlParameter("@UserId", model.UserId));
			return response;
		}

		public DBCategoryMaster GetById(long id)
		{
			DBCategoryMaster response = _context.CategoryMasters.FromSqlRaw("execute GetCategoryMasterById @Id",
					new SqlParameter("@Id", id)
					).AsEnumerable().FirstOrDefault() ?? new DBCategoryMaster();
			return response;
		}

		public DBResponseInt Update(CategoryMasterRequest viewModel)
		{
			DBResponseInt response = _context.ResponseInts.FromSqlRaw(" execute UpdateCategoryMaster @Id,@Name,@Title,@ImagePath,@IsSave,@Link,@ModifiedBy,@ModifiedOn",
					new SqlParameter("@Id", viewModel.Id),
					new SqlParameter("@Name", viewModel.Name),
				new SqlParameter("@Title", viewModel.Title),
				new SqlParameter("@ImagePath", viewModel.ImagePath),
				new SqlParameter("@IsSave", viewModel.IsSave),
				new SqlParameter("@Link", viewModel.Link),
					new SqlParameter("@ModifiedBy", viewModel.ModifiedBy),
					new SqlParameter("@ModifiedOn", viewModel.ModifiedOn)
					).AsEnumerable().FirstOrDefault() ?? new DBResponseInt();
			return response;
		}
	}
}