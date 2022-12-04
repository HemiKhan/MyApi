using Domain.Dtos.AccessLevelDTOs;
using Domain.Dtos.CardDtos;
using Domain.Dtos.QUserDtos;
using Domain.Dtos.QUserDtos.QUserFileDTOs;
using Domain.Models.QUserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events.QUserEvents
{
   public record QUser_Added(string firstName, string lastName, string? middleName, string? employeeId, string? department, string? company,
            string? gender, DateTime? lastUse, string? lastLocation, string? nationality, string? email, string? qUserType,
            string? phone, Add_Card_DTO[] cards, Add_QUserAccessLevels_DTO[] qUserAccessLevels, Add_QUserFile_DTO qUserFile) : IDomainEvent;

    public record Quser_Deleted(QUser QUser) : IDeleteDomainEvent { }



    public record QUser_Updated(long Id, Update_QUser_EventParameters OldValue, Update_QUser_EventParameters NewValue) : IDomainEvent;
}
