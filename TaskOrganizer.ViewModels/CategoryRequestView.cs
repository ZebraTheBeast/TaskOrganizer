using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskOrganizer.ViewModels.Shared
{
    public class CategoryRequestView
    {
        public long userId { get; set; }
        public CategoryView category { get; set; }
    }
}
