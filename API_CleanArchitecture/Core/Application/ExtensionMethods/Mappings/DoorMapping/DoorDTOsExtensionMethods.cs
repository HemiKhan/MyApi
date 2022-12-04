//using Domain.Dtos.Door;
//using Domain.Models.ControllerModels.DoorModels;

//namespace Application.ExtensionMethods.Mappings.DoorMapping
//{
//    internal static class DoorDTOsExtensionMethods
//    {
//        public static Door AsDomainModel(this Door_DTO_Template dto)
//        {
//            var door = new Door
//                (
//                dto.Name,
//                dto.Lock1,
//                dto.Lock2
//                )
//            { };
//            door.AddDoorAdvanceConfig(dto.DoorAdvanceConfg.AsDomainModel());



//            return door;
//        }


//        public static Door[] AsDomainModel(this Door_DTO_Template[] doorDTOs)
//        {
//            var doors = new Door[doorDTOs.Length];
//            for (int i = 0; i < doorDTOs.Length; i++)
//            {
//                doors[i] = doorDTOs[i].AsDomainModel();
//            }
//            return doors;
//        }

//        //public static Door AsDomainModel(this UpdateDoorDTO dto)
//        //{
//        //    return new Door
//        //        (
//        //        dto.Name,
//        //        dto.Relay
//        //        )
//        //    { Id = dto.Id, OrganizationId = dto.OrganizationId };
//        //}

//        public static Door AsDomainModel(this DeleteDoorDTO dto)
//        {
//            return new Door
//                (
//                default!,
//                default!,
//                default!
//                )
//            { Id = dto.Id };
//        }
//    }
//}
