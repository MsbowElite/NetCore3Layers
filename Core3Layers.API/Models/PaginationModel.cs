using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core3Layers.API.Models
{
    public class PaginationModel
    {
        public int PageIndex { get; private set; }

        public int PageSize { get; private set; }
    }
}
