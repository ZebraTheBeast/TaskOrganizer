using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskOrganizer.ViewModels
{
    public class UpdateStatusRequestView
    {
        public long objectiveId { get; set; }
        public long statusId { get; set; }
    }
}
