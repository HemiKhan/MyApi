using Models.Model.PortfolioViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel.PortfolioViewModel
{
    public class OtherViewModel
    {
        public List<SkillViewModel>? Skills { get; set; }
        public List<ServiceViewModel>? Services { get; set; }
        public List<ToolViewModel>? Tools { get; set; }
    }
}
