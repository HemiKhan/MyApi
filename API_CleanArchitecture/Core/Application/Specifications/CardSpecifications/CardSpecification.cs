using Application.Specifications.Base;
using Domain.Dtos.CardDtos;
using Domain.Models.AccessLevelModels;
using Domain.Models.CardModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Specifications.CardSpecifications
{
    internal static class CardSpecification
    {
        internal static GenericQSpec<Card, object> GetCardByCardNumber(string cardNumber)
        {
            return new GenericQSpec<Card, object>()
            {
                SpecificationFunc = _ => _.Select(x => new { x.CardNumber }).Where(x => x.CardNumber == cardNumber)
            };
        }

        internal static GenericQSpec<Card, object> GetCardByCardRaw(string cardRaw)
        {
            return new GenericQSpec<Card, object>()
            {
                SpecificationFunc = _ => _.Select(x => new { x.CardRaw }).Where(x => x.CardRaw == cardRaw)
            };
        }


        internal static GenericQSpec<Card, CardValidationDTO> GetCardValidationData(string? cardNumber,string? cardRaw)
        {
            if (cardNumber != null)
            {
                var result = new GenericQSpec<Card, CardValidationDTO>()
                {
                    SpecificationFunc = _ => _.Select(x => new CardValidationDTO { Id = x.Id, CardNumber = x.CardNumber, CardRaw = x.CardRaw }).Where(x => x.CardNumber!.ToLower() == cardNumber.ToLower())
                };
                return result;
            }

            if (cardRaw != null)
            {
                var result = new GenericQSpec<Card, CardValidationDTO>()
                {
                    SpecificationFunc = _ => _.Select(x => new CardValidationDTO { Id = x.Id, CardNumber = x.CardNumber, CardRaw = x.CardRaw }).Where(x => x.CardRaw!.ToLower() == cardRaw!.ToLower())
                };
                return result;
            }

            return null;

        }
    }
}
