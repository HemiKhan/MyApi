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
        protected override void When(IDomainEvent @event)
        {
            switch (@event)
            {
                case
                    Card_Added e:
                    Apply(e);
                    break;
                case
                     Card_Updated e:
                    Apply(e);
                    break;
                    case Card_Deleted e:
                    break;

                default:
                    throw QExceptions.EventsExceptions.EventCantBeAddedInWhenMethod;

            }
        }

        public void Apply(Card_Added e)
        {
            CardNumber = e.cardNumber;
            CardRaw = e.cardRaw;
            ValidFrom = e.validFrom;
            ValidTo = e.validTo;
            CardStatus = e.cardStatus;
            FacilityCode = e.facilityCode;
            IsAdOverride = e.isAdOverride;
            QUserId = e.QUserId;

        }


        public void Apply(Card_Updated e)
        {
            if(!CardNumber.Equals(e.NewValue.cardNumber) && !string.IsNullOrEmpty(e.NewValue.cardNumber))
            CardNumber = e.NewValue.cardNumber;

            if (!CardRaw.Equals(e.NewValue.cardRaw) && !string.IsNullOrEmpty(e.NewValue.cardRaw))
                CardRaw = e.NewValue.cardRaw;

            if (!ValidFrom.Equals(e.NewValue.validFrom) && e.NewValue.validFrom != null)
                ValidFrom = e.NewValue.validFrom;

            if (!ValidTo.Equals(e.NewValue.validTo) && e.NewValue.validTo != null)
                ValidTo = e.NewValue.validTo;

            if (!CardStatus.Equals(e.NewValue.cardStatus) && e.NewValue.cardStatus != null)
                CardStatus = e.NewValue.cardStatus;

            if (!FacilityCode.Equals(e.NewValue.facilityCode) && e.NewValue.facilityCode != null)
                FacilityCode = e.NewValue.facilityCode;

            if (!IsAdOverride.Equals(e.NewValue.isAdOverride) && e.NewValue.isAdOverride != null)
                IsAdOverride = (bool)e.NewValue.isAdOverride;
          
        }
    }
}
