using Domain.Behaviours.ControllerBehaviours.Base;
using Domain.Dtos.AccessLevelDTOs;
using Domain.Dtos.CardDtos;
using Domain.Dtos.QUserDtos;
using Domain.Events.AccessLevelEvents;
using Domain.Events.QUserEvents;
using Domain.Models.AccessLevelModels;
using Domain.Models.CardModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.QUserModels
{
    public partial record QUser
    {
        public static QUser Create(ADD_QUser_DTO command) => new QUser(
                      command.firstName,
                      command.lastName,
                      command.middleName,
                      command.employeeId,
                      command.department,
                      command.company,
                      command.gender,
                      command.lastUse,
                      command.lastLocation,
                      command.nationality,
                      command.email,
                      command.qUserType,
                      command.lastArea,
                      command.phone,
                      command.Cards!,
                      command.QUserAccessLevels!,
                      command.QUserFile!);


        public Deleted<QUser> Delete()
        {
            var e = new Quser_Deleted(this);
            RegisterEvent(e);
            return new Deleted<QUser>(this, e);
        }


        public void Update(Update_QUser_DTO dto) {

            var OldValues = new Update_QUser_EventParameters();
            var NewValues = new Update_QUser_EventParameters();
            bool hasChanges = false;

            if (!FirstName.Equals(dto.firstName))
            {
                OldValues.firstName = FirstName;
                NewValues.firstName = dto.firstName;
                hasChanges = true;
            }

            if (!LastName.Equals(dto.lastName))
            {
                OldValues.lastName = LastName;
                NewValues.lastName = dto.lastName;
                hasChanges = true;
            }

            if (!MiddleName!.Equals(dto.middleName))
            {
                OldValues.middleName = MiddleName;
                NewValues.middleName = dto.middleName;
                hasChanges = true;
            }

            if (!Email!.Equals(dto.email))
            {
                OldValues.email = Email;
                NewValues.email = dto.email;
                hasChanges = true;

            }

            if (!DepartmentName!.Equals(dto.department))
            {
                OldValues.department = DepartmentName;
                NewValues.department = dto.department;
                hasChanges = true;
            }

            if (!CompanyName!.Equals(dto.company))
            {
                OldValues.company = CompanyName;
                NewValues.company = dto.company;
                hasChanges = true;
            }

            if (!Gender.Equals(dto.gender))
            {
                OldValues.gender = Gender;
                NewValues.gender = dto.gender;
                hasChanges = true;
            }

            if (!QUserType.Equals(dto.qUserType))
            {
                OldValues.qUserType = QUserType;
                NewValues.qUserType = dto.qUserType;
                hasChanges = true;
            }

            if (!Phone.Equals(dto.phone))
            {
                OldValues.phone = Phone;
                NewValues.phone = dto.phone;
                hasChanges = true;
            }

            if (LastArea != null && !LastArea.Equals(dto.lastArea))
            {
                OldValues.lastArea = LastArea;
                NewValues.lastArea = dto.lastArea;
                hasChanges = true;
            }

            if (!LastUse.Equals(dto.lastUse))
            {
                OldValues.lastUse = LastUse;
                NewValues.lastUse = dto.lastUse;
                hasChanges = true;
            }

            if (!LastLocation.Equals(dto.lastLocation))
            {
                OldValues.lastLocation = LastLocation;
                NewValues.lastLocation = dto.lastLocation;
                hasChanges = true;
            }

            if (!EmployeeId.Equals(dto.employeeId))
            {
                OldValues.employeeId = EmployeeId;
                NewValues.employeeId = dto.employeeId;
                hasChanges = true;
            }

            if (!Nationality.Equals(dto.nationality))
            {
                OldValues.nationality = Nationality;
                NewValues.nationality = dto.nationality;
                hasChanges = true;

            }
            if (dto.QUserFile != null)
            {
                if(QUserFiles != null)
                   QUserFiles.Update(dto.QUserFile);
            }
            else
            {
                if (QUserFiles != null)
                { 
                 QUserFiles.Delete();
                 QUserFiles = null;
                }
            }
           
            UpdateQUserAccessLevels(dto.QUserAccessLevels);
            UpdateCards(dto.Cards, dto.Id);

            if (hasChanges)
            {
                var e = new QUser_Updated(dto.Id, OldValues, NewValues);
                RegisterEvent(e);
            }

           

        }
        public void UpdateQUserAccessLevels(List<Update_QUserAccessLevels_DTO> dto)
        {
            var deleteQUserAccessLevels = new List<QUserAccessLevel>();
            List<long> Ids = new List<long>();
            if (!dto.Any()) {
                QUserAccessLevels.Clear();
            }; 

            foreach (var qlevel in QUserAccessLevels)
            {
                if (!dto.Any(x => x.Id == qlevel.Id))
                {
                    deleteQUserAccessLevels.Add(qlevel);
                }

                foreach (var uQLevel in dto)
                {
                    if (qlevel.Id == uQLevel.Id)
                    {
                        qlevel.Update(uQLevel);
                        Ids.Add(qlevel.Id);
                    }
                }
            }

            var newQUserAccessLevels = dto.Where(x=> !Ids.Contains(x.Id)).ToList();

            foreach (var addQUserAccessLevel in newQUserAccessLevels)
            {
               QUserAccessLevels.Add(QUserAccessLevel.Create((long)addQUserAccessLevel.QUserId!, (long)addQUserAccessLevel.AccessLevelId!));
            }

            foreach (var deleteQUserAccessLevel in deleteQUserAccessLevels)
            {
                        QUserAccessLevels.Remove(deleteQUserAccessLevel);
            }
        }

        public void UpdateCards(List<Update_Card_DTO> dto,long qUserId)
        {
            var deleteCards = new List<Card>();
            List<long> Ids = new List<long>();
            if (!dto.Any()) {
                Cards.Clear();
            }

            foreach (var card in Cards)
            {
                if (!dto.Any(x => x.Id == card.Id))
                {
                    deleteCards.Add(card);
                }

                var cardToUpdate = dto.Where(x=>x.Id == card.Id).FirstOrDefault();
                if (cardToUpdate != null)
                {
                    card.Update(cardToUpdate);
                    Ids.Add(cardToUpdate.Id);
                }
            }

            var newCard = dto.Where(x => !Ids.Contains(x.Id));

            foreach (var addCard in newCard)
            {
                Cards.Add(Card.Create(addCard.cardNumber,addCard.cardRaw,addCard.facilityCode,addCard.validFrom,addCard.validTo,addCard.cardStatus,(bool)addCard.isAdOverride!, qUserId));
            }

            foreach (var deleteCard in deleteCards)
            {
                Cards.Remove(deleteCard);
            }
        }
    }
}
