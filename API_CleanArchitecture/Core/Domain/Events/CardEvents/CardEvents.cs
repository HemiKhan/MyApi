using Domain.Dtos.CardDtos;
using Domain.Models.CardModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events.CardEvents
{
  public record Card_Added(string? cardNumber, string? cardRaw, int? facilityCode, DateTime? validFrom, DateTime? validTo, CardStatus cardStatus, bool isAdOverride, long QUserId) :IDomainEvent;
  public record Card_Updated(long Id, Card_UpdateEventParameter OldValue, Card_UpdateEventParameter NewValue) :IDomainEvent;
  public record Card_Deleted(Card Card) : IDeleteDomainEvent { }  
}
