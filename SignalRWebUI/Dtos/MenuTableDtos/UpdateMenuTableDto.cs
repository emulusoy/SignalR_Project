﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.Dtos.MenuTableDtos
{
	public class UpdateMenuTableDto
	{
		public int MenuTableID { get; set; }
        public string MenuTableName { get; set; }
        public bool MenuTableStatus { get; set; }
    }
}
