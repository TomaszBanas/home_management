using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Models.Dto
{
    public class PaggingMetadata
    {
        public int ItemsCount { get; set; }
        public int AllItemsCount { get; set; }
    }

    public class PaggingResponse<T> where T : class
    {
        public PaggingMetadata Metadata { get; set; }
        public List<T> Items { get; set; }
    }
}
