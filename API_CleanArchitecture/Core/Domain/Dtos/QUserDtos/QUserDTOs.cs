using Domain.Dtos.AccessLevelDTOs;
using Domain.Dtos.CardDtos;
using Domain.Dtos.QUserDtos.QUserFileDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.QUserDtos
{
    public record ADD_QUser_DTO(string firstName, string lastName, string? middleName, string? employeeId, string? department, string? company,
            string? gender, DateTime? lastUse, string? lastLocation, string? nationality, string? email, string? qUserType,string? lastArea,
            string? phone,Add_Card_DTO?[] Cards,Add_QUserAccessLevels_DTO?[] QUserAccessLevels, Add_QUserFile_DTO? QUserFile);

    public record Update_QUser_DTO(long Id,string firstName, string lastName, string? middleName, string? employeeId, string? department, string? company,
            string? gender, DateTime? lastUse, string? lastArea , string? lastLocation, string? nationality, string? email, string? qUserType,
            string? phone, List<Update_Card_DTO>? Cards, List<Update_QUserAccessLevels_DTO>? QUserAccessLevels, Update_QUserFile_DTO? QUserFile);

    public record Delete_QUser_DTO(long Id);
    public record Delete_QUserCard_DTO(long Id);

    public record GetAll_QUser_DTO(long Id,string Name);


    public record GetById_QUser_DTO(long? Id, string? firstName, string? lastName, string? middleName, string? employeeId, string? department, string? company,
          string? gender, DateTime? lastUse, string? lastArea, string? lastLocation, string? nationality, string? email, string? qUserType,
          string? phone, List<Get_Card_DTO>? Cards, List<Get_QUserAccessLevels_DTO>? QUserAccessLevels, Get_QUserFile_DTO? QUserFile);

    public class Update_QUser_EventParameters {

        public long Id { get; set; }
        public string? firstName {get; set;}
        public string? lastName {get; set;}
        public string? middleName {get; set;}
        public string? employeeId {get; set;}
        public string? department {get; set;}
        public string? company {get; set;}
        public string? gender {get; set;}
        public DateTime? lastUse {get; set;}
        public string? lastLocation {get; set;}
        public string? nationality {get; set;}
        public string? email {get; set;}
        public string? qUserType {get; set;}
        public string? phone {get; set;}
        public string? lastArea { get; set; }
    }
}
