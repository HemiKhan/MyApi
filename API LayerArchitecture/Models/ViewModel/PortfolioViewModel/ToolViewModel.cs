using Models.Model.PortfolioModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model.PortfolioViewModel
{
    public class ToolViewModel
    {
        public Guid ToolId { get; set; }
        public string? Name { get; set; }
        public Guid PeronalinfoId { get; set; }
    }

    public static class ToolExtensions
    {
        public static List<ToolViewModel> ToolMapperList(this List<Tool> data)
        {
            List<ToolViewModel> list = new List<ToolViewModel>();
            foreach (var item in data)
            {
                ToolViewModel res = new ToolViewModel();
                res.ToolId = item.ToolId;
                res.Name = item.Name;
                res.PeronalinfoId = item.PeronalinfoId;
                list.Add(res);
            }
            return list;
        }

        public static ToolViewModel ToolMapper(this Tool data)
        {
            ToolViewModel res = new ToolViewModel();
            res.ToolId = data.ToolId;
            res.Name = data.Name;
            res.PeronalinfoId = data.PeronalinfoId;
            return res;
        }

        public static Tool ToolMapper(this ToolViewModel data)
        {
            Tool res = new Tool();
            res.ToolId = data.ToolId;
            res.Name = data.Name;
            res.PeronalinfoId = data.PeronalinfoId;
            return res;
        }
    }
}
