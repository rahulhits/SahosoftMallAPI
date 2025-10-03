using AutoMapper;
using BusinessEntities.EComm.ResponseDTO;
using Repositories.EComm.DbEntity;

namespace BusinessService.EComm.MapperRules
{
	public class MapperProfile : Profile
	{
		public MapperProfile()
		{
			// Define your object-object mapping rules here
			CreateMap<DBSizeMaster, SizeMasterResponse>();
			CreateMap<DBColorMaster, ColorMasterResponse>();
			CreateMap<DBUserTypeMaster, UserTypeMasterResponse>();
			CreateMap<DBCategoryMaster, CategoryMasterResponse>();
			CreateMap<DBBrandLogoMaster, BrandLogoMasterResponse>();

			CreateMap<DBUserMaster, UserMasterResponse>();
			CreateMap<DBUserMasterLogin, UserMasterLoginResponse>();
			CreateMap<DBUserMaster_GetUserByUserType, UserMaster_GetUserByUserTypeResponse>();

		}
	}
}
