namespace Domain.Dtos.Door
{
    using Domain.Dtos.ControllerDTOs.DoorDTOs.RexDTOs;
    using Domain.Dtos.ReaderDTOs;

    public record Door_Add_DTO(
       long ControllerId,
       string Name,
       string Lock,
       DoorType DoorType,
       AddDoorAdvanceConfgDTO DoorAdvanceConfig,
       AddReaderDTO[] Readers,
       Rex_Add_DTO[] Rexes
    );

    public record UpdateDoorDTO(
        long Id,
        long ControllerId,
        string Name,
        string Lock,
        DoorType DoorType,
        UpdateDoorAdvanceConfgDTO DoorAdvanceConfig,
        IEnumerable<UpdateReaderDTO> Readers,
        IEnumerable<UpdateRexDTO> Rexes
    );

    public record Door_GetById_DTO(
        long Id,
        long ControllerId,
        string Name,
        string Lock,
        DoorType DoorType,
        DoorAdvanceConfig_GetById_DTO DoorAdvanceConfig,
        IEnumerable<Reader_GetById_DTO> Readers,
        IEnumerable<Rex_GetById_DTO> Rexes
    );

    public record GetAllDoorsDTO(
        long Id,
        string Name
        //long OrganizationId,
        //long ControllerId,
        //string DoorType
    ){}

    public record DeleteDoorDTO(long Id);
}
