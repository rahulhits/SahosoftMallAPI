using BusinessEntities.Common;
using BusinessEntities.EComm.RequestDTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Repositories.EComm.Common;
using Repositories.EComm.DbEntity;
using Repositories.EComm.Interface;

namespace Repositories.EComm.Implementation
{
	public class BrandLogoMasterRepository : IBrandLogoMasterRepository
	{
		private ECommDBContext _context;
		public BrandLogoMasterRepository(ECommDBContext context)
		{
			_context = context;
		}
		public DBResponseInt Add(BrandLogoMasterRequest viewModel)
		{
			DBResponseInt response = _context.ResponseInts.FromSqlRaw(" execute InsertBrandLogo @Name,@ImagePath,@CreatedBy",
				new SqlParameter("@Name", viewModel.Name),
				new SqlParameter("@ImagePath", viewModel.ImagePath),
				new SqlParameter("@CreatedBy", viewModel.CreatedBy)
				).AsEnumerable().FirstOrDefault() ?? new DBResponseInt();
			return response;
		}

		public DBResponseInt Delete(long id)
		{
			DBResponseInt response = _context.ResponseInts.FromSqlRaw(" execute DeleteBrandLogo @Id",
					 new SqlParameter("@Id", id)
					 ).AsEnumerable().FirstOrDefault() ?? new DBResponseInt();
			return response;
		}

		public IEnumerable<DBBrandLogoMaster> GetAll(GetAllByUserId model)
		{
			IEnumerable<DBBrandLogoMaster> response = _context.BrandLogoMasters.FromSqlRaw("execute Proc_GetAll_BrandLogo @UserId",
				  new SqlParameter("@UserId", model.UserId));
			return response;
		}

		public DBBrandLogoMaster GetById(long id)
		{
			DBBrandLogoMaster response = _context.BrandLogoMasters.FromSqlRaw("execute GetBrandLogoById @Id",
					new SqlParameter("@Id", id)
					).AsEnumerable().FirstOrDefault() ?? new DBBrandLogoMaster();
			return response;
		}

		public DBResponseInt Update(BrandLogoMasterRequest viewModel)
		{
			DBResponseInt response = _context.ResponseInts.FromSqlRaw(" execute UpdateBrandLogo @Id,@Name,@ImagePath,@ModifiedBy,@ModifiedOn",
					new SqlParameter("@Id", viewModel.Id),
					new SqlParameter("@Name", viewModel.Name),
					new SqlParameter("@ImagePath", viewModel.ImagePath),
					new SqlParameter("@ModifiedBy", viewModel.ModifiedBy),
					new SqlParameter("@ModifiedOn", viewModel.ModifiedOn)
					).AsEnumerable().FirstOrDefault() ?? new DBResponseInt();
			return response;
		}
	}
}
