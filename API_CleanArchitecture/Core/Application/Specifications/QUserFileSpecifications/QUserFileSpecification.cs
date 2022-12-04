using Application.Specifications.Base;
using Domain.Models.PrioritiesModels;
using Domain.Models.QUserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal static partial class QUserFileSpecification
{
    internal static GenericQSpec<QUserFile, QUserFile> GetQUserFileByQUserId(long QUserId)
    {
        return new()
        {
            SpecificationFunc = _ => _.Where(o => o.QUserId == QUserId)
        };
    }
}

