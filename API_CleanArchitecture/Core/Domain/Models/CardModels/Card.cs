using Domain.Dtos.CardDtos;
using Domain.Events.CardEvents;
using Domain.Models.QUserModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.CardModels
{
    public partial record Card : AggregateRoot<long>, IMustHaveOrganization, IMustHaveToken
    {
        Card() { }

        Card(string? cardNumber, string? cardRaw, int? facilityCode, DateTime? validFrom, DateTime? validTo, CardStatus cardStatus, bool isAdOverride, long QUserId) 
        {
            var e = new Card_Added( cardNumber,  cardRaw,  facilityCode, validFrom,  validTo,  cardStatus, isAdOverride,  QUserId);
            RegisterEvent(e);
        }
        public string Token { get; set; } = default!;
        public long OrganizationId { get; set; }


        public  string? Description { get; private set; } = default!;
        public  bool? IsEnable { get; private set; } = default!;
        public  bool? IsAntiPassBack { get; private set; } = default!;
       public  string? CardNumber { get; private set; } = default!;
       public string? CardRaw  { get; private set; } = default!; 
       public string? Pin { get; private set; } = default!; 
       public int? FacilityCode  { get; private set; } = default!; 
       public DateTime? ValidFrom { get; private set; } = default!;
       public DateTime? ValidTo  { get; private set; } = default!;
        public  QUser QUser { get; set; }
        public long? QUserId { get; private set; } = default!;
       public long? LastAccessDoorId  { get; private set; } = default!;
       public long? LastAccessAreaId  { get; private set; } = default!;
       public bool? DoNotExpire { get; private set; } = default!;
       public CardStatus CardStatus { get; private set; } = default;
       public bool? IsCard { get; private set; } = default!;
       public string?  LpnNumber   { get; private set; } = default!;
       public bool IsAdOverride { get; private set; } = default!;  
       public bool? IsFacial { get; private set; } = default!;

       
    }
}
