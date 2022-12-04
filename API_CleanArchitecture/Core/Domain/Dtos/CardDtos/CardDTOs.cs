using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.CardDtos
{
    public record Add_Card_DTO(string? cardNumber, string? cardRaw, int? facilityCode, DateTime? validFrom, DateTime? validTo, CardStatus cardStatus,bool isAdOverride,long QUserId);
    public record Get_Card_DTO(long Id,string? cardNumber, string? cardRaw, int? facilityCode, DateTime? validFrom, DateTime? validTo, CardStatus cardStatus,bool? isAdOverride,long? QUserId);
    public record Update_Card_DTO(long Id,string? cardNumber, string? cardRaw, int? facilityCode, DateTime? validFrom, DateTime? validTo, CardStatus cardStatus,bool? isAdOverride,long? QUserId);


    public class Card_UpdateEventParameter {
          public string? cardNumber   {get; set;}
          public string? cardRaw   {get; set;}
          public int? facilityCode   {get; set;}
          public DateTime? validFrom   {get; set;}
          public DateTime? validTo   {get; set;}
          public CardStatus cardStatus   {get; set;}
          public bool? isAdOverride   {get; set;}
          public long? QUserId { get; set; }

    }

    public class CardValidationDTO {
       public long? Id { get; set; }
        public string? CardNumber { get; set; }
        public string? CardRaw { get; set; }
    }
    
}
