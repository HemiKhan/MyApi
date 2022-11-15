using Models.Model.PortfolioModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model.PortfolioViewModel
{
    public class ProjectTypeViewModel
    {
        public Guid ProjecttypeId { get; set; }
        public string? Name { get; set; }
        public Guid PeronalinfoId { get; set; }
    }
    public static class ProjectTypeExtensions
    {
        public static List<ProjectTypeViewModel> ProjectTypeMapperList(this List<ProjectType> data)
        {
            List<ProjectTypeViewModel> list = new List<ProjectTypeViewModel>();
            foreach (var item in data)
            {
                ProjectTypeViewModel res = new ProjectTypeViewModel();
                res.ProjecttypeId = item.ProjecttypeId;
                res.Name = item.Name;
                res.PeronalinfoId = item.PeronalinfoId;
                list.Add(res);
            }
            return list;
        }

        public static ProjectTypeViewModel ProjectTypeMapper(this ProjectType data)
        {
            ProjectTypeViewModel res = new ProjectTypeViewModel();
            res.ProjecttypeId = data.ProjecttypeId;
            res.Name = data.Name;
            res.PeronalinfoId = data.PeronalinfoId;
            return res;
        }

        public static ProjectType ProjectTypeMapper(this ProjectTypeViewModel data)
        {
            ProjectType res = new ProjectType();
            res.ProjecttypeId = data.ProjecttypeId;
            res.Name = data.Name;
            res.PeronalinfoId = data.PeronalinfoId;
            return res;
        }
    }
}
