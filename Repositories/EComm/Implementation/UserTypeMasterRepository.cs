using BusinessEntities.Common;
using BusinessEntities.EComm.RequestDTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Repositories.EComm.Common;
using Repositories.EComm.DbEntity;
using Repositories.EComm.Interface;

namespace Repositories.EComm.Implementation
{
	public class UserTypeMasterRepository : IUserTypeMasterRepository
	{
		private ECommDBContext _context;
		public UserTypeMasterRepository(ECommDBContext context)
		{
			_context = context;
		}

		public DBResponseInt Add(UserTypeMasterRequest viewModel)
		{
			DBResponseInt response = _context.ResponseInts.FromSqlRaw("execute InsertUserType @Name,@CreatedBy",
				new SqlParameter("@Name", viewModel.Name),
				new SqlParameter("@CreatedBy", viewModel.CreatedBy)
				).AsEnumerable().FirstOrDefault() ?? new DBResponseInt();

			return response;
		}

		public DBResponseInt Delete(long Id)
		{
			DBResponseInt response = _context.ResponseInts.FromSqlRaw("execute DeleteUserType @Id",
			   new SqlParameter("@Id", Id)
			   ).AsEnumerable().FirstOrDefault() ?? new DBResponseInt();

			return response;
		}

		public IEnumerable<DBUserTypeMaster> GetAll(GetAllByUserId viewModel)
		{
			IEnumerable<DBUserTypeMaster> response = _context.UserTypeMasters.FromSqlRaw("GetAllUserType @UserId",
				 new SqlParameter("@UserId", viewModel.UserId)
				);
			return response;
		}

		public IEnumerable<DBUserTypeMaster> GetAllForUserRights(GetAllByUserId viewModel)
		{
			IEnumerable<DBUserTypeMaster> response = _context.UserTypeMasters.FromSqlRaw("GetAllUserType_ForUserRights @UserId",
				 new SqlParameter("@UserId", viewModel.UserId)
				);
			return response;
		}

		public DBUserTypeMaster GetById(long Id)
		{
			DBUserTypeMaster response = _context.UserTypeMasters.FromSqlRaw("GetUserTypebyId @Id",
				new SqlParameter("@Id", Id)
			   ).AsEnumerable().FirstOrDefault() ?? new DBUserTypeMaster();
			return response;
		}

		public DBResponseInt Update(UserTypeMasterRequest viewModel)
		{
			DBResponseInt response = _context.ResponseInts.FromSqlRaw("execute UpdateUserType @Id,@Name,@ModifiedBy,@ModifiedOn",
			  new SqlParameter("@Id", viewModel.Id),
			  new SqlParameter("@Name", viewModel.Name),
			  new SqlParameter("@ModifiedBy", viewModel.ModifiedBy),
			  new SqlParameter("@ModifiedOn", viewModel.ModifiedOn)
			  ).AsEnumerable().FirstOrDefault() ?? new DBResponseInt();

			return response;
		}
	}
}
