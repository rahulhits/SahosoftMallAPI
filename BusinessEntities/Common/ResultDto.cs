﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Common
{
	public class ResultDto<T>
	{
		public bool IsSuccess { get; set; }
		public T Data{ get; set; }
		public List<string> Errors { get; set; }
	}
}
