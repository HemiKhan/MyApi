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
    public class ServiceViewModel
    {
        public Guid ServiceId { get; set; }
        public string? Name { get; set; }
        public Guid PeronalinfoId { get; set; }
    }

    public static class ServiceExtensions
    {
        public static List<ServiceViewModel> ServiceMapperList(this List<Service> data)
        {
            List<ServiceViewModel> list = new List<ServiceViewModel>();
            foreach (var item in data)
            {
                ServiceViewModel res = new ServiceViewModel();
                res.ServiceId = item.ServiceId;
                res.Name = item.Name;
                res.PeronalinfoId = item.PeronalinfoId;
                list.Add(res);
            }
            return list;
        }

        public static ServiceViewModel ServiceMapper(this Service data)
        {
            ServiceViewModel res = new ServiceViewModel();
            res.ServiceId = data.ServiceId;
            res.Name = data.Name;
            res.PeronalinfoId = data.PeronalinfoId;
            return res;
        }

        public static Service ServiceMapper(this ServiceViewModel data)
        {
            Service res = new Service();
            res.ServiceId = data.ServiceId;
            res.Name = data.Name;
            res.PeronalinfoId = data.PeronalinfoId;
            return res;
        }
    }
}
