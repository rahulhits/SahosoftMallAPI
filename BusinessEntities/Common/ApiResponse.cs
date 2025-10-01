using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Common
{
	public class ApiResponse<T>
	{
		public bool IsSuccess { get; set; }
		public T Data { get; set; }
		public string Errors { get; set; }
		
		public static ApiResponse<T> Success(T data)
		{
			return new ApiResponse<T>
			{
				IsSuccess = true,
				Data = data,
				Errors = null
			};
		}
		public static ApiResponse<T> Failure(string error)
		{
			return new ApiResponse<T>
			{
				IsSuccess = false,
				Data = default(T),
				Errors = error
			};
		}
	}
}
