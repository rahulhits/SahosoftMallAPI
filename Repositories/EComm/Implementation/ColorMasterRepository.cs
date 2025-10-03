using BusinessEntities.Common;
using BusinessEntities.EComm.RequestDTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Repositories.EComm.Common;
using Repositories.EComm.DbEntity;
using Repositories.EComm.Interface;

namespace Repositories.EComm.Implementation
{
	public class ColorMasterRepository : IColorMasterRepository
	{
		private ECommDBContext _context;
		public ColorMasterRepository(ECommDBContext context)
		{
			_context = context;
		}

		public DBResponseInt Add(ColorMasterRequest viewModel)
		{
			DBResponseInt response = _context.ResponseInts.FromSqlRaw(" execute InsertColorMaster @Name,@Code,@CreatedBy",
				new SqlParameter("@Name", viewModel.Name),
				new SqlParameter("@Code", viewModel.Code),
				new SqlParameter("@CreatedBy", viewModel.CreatedBy)
				).AsEnumerable().FirstOrDefault() ?? new DBResponseInt();
			return response;
		}

		public DBResponseInt Delete(long id)
		{
			DBResponseInt response = _context.ResponseInts.FromSqlRaw(" execute DeleteColorMaster @Id",
					 new SqlParameter("@Id", id)
					 ).AsEnumerable().FirstOrDefault() ?? new DBResponseInt();
			return response;
		}

		public IEnumerable<DBColorMaster> GetAll(GetAllByUserId model)
		{
			IEnumerable<DBColorMaster> response = _context.ColorMasters.FromSqlRaw("execute Proc_GetAll_ColorMaster @UserId",
				  new SqlParameter("@UserId", model.UserId));
			return response;
		}

		public DBColorMaster GetById(long id)
		{
			DBColorMaster response = _context.ColorMasters.FromSqlRaw("execute GetColorMasterById @Id",
					new SqlParameter("@Id", id)
					).AsEnumerable().FirstOrDefault() ?? new DBColorMaster();
			return response;
		}

		public DBResponseInt Update(ColorMasterRequest viewModel)
		{
			DBResponseInt response = _context.ResponseInts.FromSqlRaw(" execute UpdateColorMaster @Id,@Name,@Code,@ModifiedBy,@ModifiedOn",
					new SqlParameter("@Id", viewModel.Id),
					new SqlParameter("@Name", viewModel.Name),
					new SqlParameter("@Code", viewModel.Code),
					new SqlParameter("@ModifiedBy", viewModel.ModifiedBy),
					new SqlParameter("@ModifiedOn", viewModel.ModifiedOn)
					).AsEnumerable().FirstOrDefault() ?? new DBResponseInt();
			return response;
		}
	}
}

