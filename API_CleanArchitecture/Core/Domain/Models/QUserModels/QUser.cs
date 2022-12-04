using Domain.Dtos.AccessLevelDTOs;
using Domain.Dtos.CardDtos;
using Domain.Dtos.QUserDtos.QUserFileDTOs;
using Domain.Events.QUserEvents;
using Domain.Models.AccessLevelModels;
using Domain.Models.CardModels;
using SharedKernel.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.QUserModels
{
    public partial record QUser : AggregateRoot<long>, IMustHaveOrganization, IMustHaveToken
    {
        private QUser() { }
        QUser(string firstName,string lastName,string? middleName,string? employeeId,string? department,string? company,
            string? gender,DateTime? lastUse,string? lastLocation,string? nationality,string? email,string? qUserType,string? lastArea,
            string? phone,Add_Card_DTO[] cards, Add_QUserAccessLevels_DTO[] qUserAccessLevels, Add_QUserFile_DTO qUserFile)
        {
            var e = new QUser_Added(firstName, lastName, middleName, employeeId, department, company,
             gender, lastUse, lastLocation, nationality, email, qUserType,
             phone,cards,qUserAccessLevels, qUserFile);
            RegisterEvent(e);
        }
        public string Token { get; set; } = string.Empty!;
        public long OrganizationId { get; set; }
        public string? EmployeeId { get; private set; } = string.Empty!;
        public string FirstName { get; private set; } = string.Empty!;
        public string LastName { get; private set; } = string.Empty!;
        public string? MiddleName { get; private set;} = string.Empty!;
        public string? Email { get; private set; } = string.Empty!;
        public string? DepartmentName { get; private set; } = string.Empty!;
        public string? CompanyName { get; private set; } = string.Empty!;
        public string? Gender { get; private set; } = string.Empty!;
        public string? QUserType { get; private set; } = string.Empty!;
        public string? Phone { get; private set; } = string.Empty!;
        public string? LastArea { get; private set; } = string.Empty!;
        public DateTime? LastUse { get; private set; }
        public string? Nationality { get; set; }
        public string? LastLocation { get; private set; } = string.Empty!;
        public bool? IsUnlockExtensionADA { get; private set; } = default!;
       
        public virtual List<Card> Cards { get; set; } = new List<Card>();
        public virtual List<QUserAccessLevel> QUserAccessLevels {get; set;}
        public  virtual QUserFile QUserFiles { get; set; }
    }
}
