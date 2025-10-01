using BusinessEntities.EComm.RequestDTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Repositories.EComm.DbEntity;
using Repositories.EComm.Interface;

namespace Repositories.EComm.Implementation
{
	
	public class SizeMasterRepository : ISizeMasterRepository

	{
		private ECommDBContext _context;
		public SizeMasterRepository(ECommDBContext context)
		{
			_context = context;
		}
		public long Add(SizeMasterRequest viewModel)
		{
				var response = _context.Database.ExecuteSqlRaw("execute InsertSizeMaster @Name, @CreatedBy",

					new SqlParameter("@Name", viewModel.Name),
					new SqlParameter("@CreatedBy", viewModel.CreatedBy)
					);
				return response;
		}

		public long Delete(long Id)
		{
			var response = _context.Database.ExecuteSqlRaw("execute DeleteSizeMaster @Id",
					new SqlParameter("@Id", Id)
					);
			return response;
		}

		public IEnumerable<DBSizeMaster> GetAll()
		{
			IEnumerable<DBSizeMaster> response = _context.SizeMasters.FromSqlRaw("execute GetAllSizeMaster");
			return response;
		}

		public DBSizeMaster GetById(long Id)
		{
			DBSizeMaster response = _context.SizeMasters.FromSqlRaw("execute GetSizeMasterById @Id",
					new SqlParameter("@Id", Id)
					).AsEnumerable().FirstOrDefault()??new DBSizeMaster();
			return response;
		}

		public long Update(SizeMasterRequest viewModel)
		{
			var response = _context.Database.ExecuteSqlRaw("execute UpdateSizeMaster @Id @Name, @CreatedBy",
					new SqlParameter("@CreatedBy", viewModel.Id),
					new SqlParameter("@Name", viewModel.Name),
					new SqlParameter("@CreatedBy", viewModel.CreatedBy)
					
					);
			return response;
		}
	}
}
