using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fmmApp.Views
{

    public class MasterMasterMenuItem
    {
        public MasterMasterMenuItem()
        {
            TargetType = typeof(MasterMasterMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}