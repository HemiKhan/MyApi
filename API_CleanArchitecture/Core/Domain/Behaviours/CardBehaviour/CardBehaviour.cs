using Domain.Behaviours.ControllerBehaviours.Base;
using Domain.Dtos.CardDtos;
using Domain.Events.CardEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.CardModels
{
    public partial record Card
    {
        public static Card Create(string? cardNumber, string? cardRaw, int? facilityCode, DateTime? validFrom, DateTime? validTo, CardStatus cardStatus, bool isAdOverride, long QUserId) =>
            new Card(cardNumber, cardRaw, facilityCode, validFrom, validTo, cardStatus, isAdOverride, QUserId);

        public Deleted<Card> Delete()
        {
            var e = new Card_Deleted(this);
            RegisterEvent(e);
            return new Deleted<Card>(this, e);
        }


        public void Update(Update_Card_DTO dto)
        {
            var OldValue = new Card_UpdateEventParameter();
            var NewValue = new Card_UpdateEventParameter();
            bool hasChanges = false;

            if (!CardNumber!.Equals(dto.cardNumber))
            {
                OldValue.cardNumber = CardNumber;
                NewValue.cardNumber = dto.cardNumber;
                hasChanges = true;
            }

            if (!CardRaw!.Equals(dto.cardRaw))
            {
                OldValue.cardRaw = CardRaw;
                NewValue.cardRaw = dto.cardRaw;
                hasChanges = true;
            }

            if (!FacilityCode.Equals(dto.facilityCode))
            {
                OldValue.facilityCode = FacilityCode;
                NewValue.facilityCode = dto.facilityCode;
                hasChanges = true;
            }

            if (!ValidFrom.Equals(dto.validFrom))
            {
                OldValue.validFrom = ValidFrom;
                NewValue.validFrom = dto.validFrom;
                hasChanges = true;
            }

            if (!ValidTo.Equals(dto.validTo))
            {
                OldValue.validTo = ValidTo;
                NewValue.validTo = dto.validTo;
                hasChanges = true;
            }

            if (!IsAdOverride.Equals(dto.isAdOverride))
            {
                OldValue.isAdOverride = IsAdOverride;
                NewValue.isAdOverride = dto.isAdOverride;
                hasChanges = true;
            }

            if (hasChanges)
            {
                var e = new Card_Updated(dto.Id, OldValue, NewValue);
                RegisterEvent(e);
            }

        }

    }
}
