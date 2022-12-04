//namespace Application.ExtensionMethods.Mappings;

//using Domain.Dtos.ControllerDTOs;
//using Domain.Models.ControllerModels;

//internal static class ControllerDTOsExtensionMethods
//{
//    public static Controller AsDomainModel(this AddControllerCommand dto)
//    => new Controller(
//               dto.Name,
//               dto.UserName,
//                dto.Password,
//               dto.MACAddress,
//               dto.OAK,
//               dto.IsOneDoor,
//        dto.Entity);

//    public static Controller AsDomainModel(this Get_ControllerIdAndOneDoorConfigDTO dto)
//    => new(
//              default!,
//              default!,
//              default!,
//              default!,
//              default!,
//               dto.IsOneDoor,
//               default!)
//    { Id = dto.Id };


//    public static Controller AsDomainModel(this Update_ControllerDTO dto)
//    {
//        return new Controller
//            (
//            dto.Name,
//               dto.UserName,
//                dto.Password,
//               dto.MACAddress,
//               dto.OAK,
//               dto.IsOneDoor,  
//  dto.ControllerModel!
//            )
//        { Id = dto.Id };
//    }

//    public static Controller AsDomainModel(this Delete_ControllerDTO dto)
//    {
//        return new Controller
//            (
//        default!,
//       default!,
//       default!,
//       default!,
//        default!,
//       default!,
//       default!
//)
//        { Id = dto.Id };
//    }
//}
