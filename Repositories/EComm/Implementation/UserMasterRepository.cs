using BusinessEntities.EComm.RequestDTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Repositories.EComm.Common;
using Repositories.EComm.DbEntity;
using Repositories.EComm.Interface;

namespace Repositories.EComm.Implementation
{
	public class UserMasterRepository : IUserMasterRepository
	{
		private readonly ECommDBContext _context;

		public UserMasterRepository(ECommDBContext context)
		{
			_context = context;
		}

		public DBResponseInt Add(UserMasterRequest viewModel)
		{
			DBResponseInt response = _context.ResponseInts.FromSqlRaw(" execute InsertUserMaster @FirstName,@LastName,@Email,@Password,@UserTypeId,@CreatedBy",
			   new SqlParameter("@FirstName", viewModel.FirstName),
			   new SqlParameter("@LastName", viewModel.LastName),
			   new SqlParameter("@Email", viewModel.Email),
			   new SqlParameter("@Password", viewModel.Password),
			   new SqlParameter("@UserTypeId", viewModel.UserTypeId),
			   new SqlParameter("@CreatedBy", viewModel.CreatedBy)
			   ).AsEnumerable().FirstOrDefault() ?? new DBResponseInt();
			return response;
		}

		public DBResponseInt Delete(long id)
		{

			DBResponseInt response = _context.ResponseInts.FromSqlRaw(" execute DeleteUserMaster @Id",
					 new SqlParameter("@Id", id)
					 ).AsEnumerable().FirstOrDefault() ?? new DBResponseInt();
			return response;
		}

		public IEnumerable<DBUserMaster> GetAll(GetAllUserListRequest viewModel)
		{
			IEnumerable<DBUserMaster> response = _context.UserMasters.FromSqlRaw("execute GetAllUsers @UserTypeId,@UserId",
				  new SqlParameter("@UserTypeId", viewModel.UserTypeId),
				  new SqlParameter("@UserId", viewModel.UserId));
			return response;
		}

		public DBUserMaster GetById(long id)
		{
			DBUserMaster response = _context.UserMasters.FromSqlRaw("execute GetUserbyId @Id",
				  new SqlParameter("@Id", id)
				  ).AsEnumerable().FirstOrDefault() ?? new DBUserMaster();
			return response;
		}

		public IEnumerable<DBUserMaster_GetUserByUserType> GetUserByUserType(GetUserByUserTypeRequest viewModel)
		{
			IEnumerable<DBUserMaster_GetUserByUserType> response = _context.UserMaster_GetUserByUserTypes.FromSqlRaw("execute Proc_GetUserByUserType_UserMaster @UserTypeId,@UserId",
				new SqlParameter("@UserTypeId", viewModel.UserTypeId),
				new SqlParameter("@UserId", viewModel.UserId));
			return response;
		}

		public DBUserMasterLogin Login(LoginRequest viewModel)
		{
			DBUserMasterLogin response = _context.UserMasterLogins.FromSqlRaw("execute GetLogin @UserName,@Password",
				  new SqlParameter("@UserName", viewModel.UserName),
				  new SqlParameter("@Password", viewModel.Password)
				  ).AsEnumerable().FirstOrDefault() ?? new DBUserMasterLogin();
			return response;
		}

		public DBResponseInt Update(UserMasterRequest viewModel)
		{
			DBResponseInt response = _context.ResponseInts.FromSqlRaw(" execute UpdateUserMaster @UserId,@FirstName,@LastName,@Email,@Password,@UserTypeId,@ModifiedBy,@ModifiedOn",
				   new SqlParameter("@UserId", viewModel.Id),
				   new SqlParameter("@FirstName", viewModel.FirstName),
				   new SqlParameter("@LastName", viewModel.LastName),
				   new SqlParameter("@Email", viewModel.Email),
				   new SqlParameter("@Password", viewModel.Password),
				   new SqlParameter("@UserTypeId", viewModel.UserTypeId),
				   new SqlParameter("@ModifiedBy", viewModel.ModifiedBy),
				   new SqlParameter("@ModifiedOn", viewModel.ModifiedOn)
				   ).AsEnumerable().FirstOrDefault() ?? new DBResponseInt();
			return response;
		}

		public DBResponseInt UpdateProfile(UpdateProfileRequest viewModel)
		{
			DBResponseInt response = _context.ResponseInts.FromSqlRaw(" execute UpdateProfile @Id,@ImagePath",
					  new SqlParameter("@Id", viewModel.Id),
					  new SqlParameter("@ImagePath", viewModel.ImagePath)
					  ).AsEnumerable().FirstOrDefault() ?? new DBResponseInt();
			return response;
		}
	}
}
