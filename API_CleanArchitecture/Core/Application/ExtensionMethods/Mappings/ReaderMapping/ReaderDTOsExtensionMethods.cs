//using Domain.Dtos.Reader;

//namespace Application.ExtensionMethods.Mappings.ReaderMapping;
//using Domain.Models.ControllerModels.DoorModels.ReaderModels;
//internal static class ReaderDTOsExtensionMethods
//{
//    public static Reader AsDomainModel(this AddReaderDTO dto)
//    {
//        return new Reader
//            (
//            dto.Protocol,
//            dto.IsRex
//            )
//        { Token = dto.Token, OrganizationId = dto.OrganizationId };
//    }

//    public static Reader AsDomainModel(this UpdateReaderDTO dto)
//    {
//        return new Reader
//            (
//         dto.Protocol,
//            dto.IsRex
//            )
//        { Id = dto.Id, Token = dto.Token, OrganizationId = dto.OrganizationId };
//    }


//    public static Reader AsDomainModel(this Reader_GetById_DTO dto)
//    {
//        return new Reader
//            (
//          dto.Protocol,
//            dto.IsRex
//            )
//        { Id = dto.Id, Token = dto.Token, OrganizationId = dto.OrganizationId };
//    }

//    public static Reader AsDomainModel(this DeleteReaderDTO dto)
//    {
//        return new Reader
//            (
//      default,
//           default
//            )
//        { Id = dto.Id };
//    }
//}
