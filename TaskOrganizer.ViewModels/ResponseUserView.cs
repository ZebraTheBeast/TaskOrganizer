using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskOrganizer.ViewModels.Shared;

namespace TaskOrganizer.ViewModels
{
    public class ResponseUserView
    {
        public UserView User { get; set; }
        public string Status { get; set; }
    }
}
