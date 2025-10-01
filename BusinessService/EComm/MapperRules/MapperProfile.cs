using AutoMapper;
using BusinessEntities.EComm.ResponseDTO;
using Repositories.EComm.DbEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService.EComm.MapperRules
{
	public  class MapperProfile:Profile
	{
		public MapperProfile()
		{
			CreateMap<DBSizeMaster, SizeMasterResponse>();
		}
	}
}
