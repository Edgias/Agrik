using System.Collections.Generic;

namespace Mutengi.WebAPI.Models.View
{
    public class APIResponse<T>
    {
        public int Count { get; set; }

        public IEnumerable<T> Data { get; set; }
    }
}
