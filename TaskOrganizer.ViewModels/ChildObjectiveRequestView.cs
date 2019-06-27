using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskOrganizer.ViewModels.Shared
{
    public class ChildObjectiveRequestView
    {
        public long mainObjectiveId { get; set; }
        public ChildObjectiveView childObjective { get; set; }
    }
}
