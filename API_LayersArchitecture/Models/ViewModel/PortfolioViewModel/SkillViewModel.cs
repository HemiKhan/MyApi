using Models.Model.PortfolioModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model.PortfolioViewModel
{
    public class SkillViewModel
    {
        public Guid SkillId { get; set; }
        public string? Name { get; set; }
        public int Percentage { get; set; }
        public Guid PeronalinfoId { get; set; }
    }

    public static class SkillExtensions
    {
        public static List<SkillViewModel> SkillMapperList(this List<Skill> data)
        {
            List<SkillViewModel> list = new List<SkillViewModel>();
            foreach (var item in data)
            {
                SkillViewModel res = new SkillViewModel();
                res.SkillId = item.SkillId;
                res.Name = item.Name;
                res.Percentage = item.Percentage;
                res.PeronalinfoId = item.PeronalinfoId;
                list.Add(res);
            }
            return list;
        }

        public static SkillViewModel SkillMapper(this Skill data)
        {
            SkillViewModel res = new SkillViewModel();
            res.SkillId = data.SkillId;
            res.Name = data.Name;
            res.Percentage = data.Percentage;
            res.PeronalinfoId = data.PeronalinfoId;
            return res;
        }

        public static Skill SkillMapper(this SkillViewModel data)
        {
            Skill res = new Skill();
            res.SkillId = data.SkillId;
            res.Name = data.Name;
            res.Percentage = data.Percentage;
            res.PeronalinfoId = data.PeronalinfoId;
            return res;
        }
    }
}
