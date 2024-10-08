﻿using ASPProjekat.ApplicationLayer.DTO;
using ASPProjekat.ApplicationLayer.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.ApplicationLayer.Queries
{
    public interface IGetUniqueBooks:IQuery<PagedResponseDto<UniqueBookDto>,UniqueBookSearchDto>
    {
    }
}
