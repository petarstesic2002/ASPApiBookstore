﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.ApplicationLayer.DTO
{
    public class UniqueBookSearchDto : PagedSearch
    {
        public int? Id { get; set; }
    }
}
