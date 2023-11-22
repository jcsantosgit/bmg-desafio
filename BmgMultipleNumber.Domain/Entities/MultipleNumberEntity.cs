using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BmgMultipleNumber.Domain.Entities
{
    public class MultipleNumberEntity
    {
        public long Number { get; set; }
        public bool IsMultiple { get; set; }
    }
}