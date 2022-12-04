namespace Domain.Models.ControllerModels.DoorModels.ReaderModels;

using Domain.Dtos.ControllerDTOs.DoorDTOs.ReaderDTOs;
using Domain.Dtos.ReaderDTOs;
using Domain.Events.ControllerEvents.DoorEvents;
using Domain.Events.ControllerEvents.DoorEvents.ReaderEvents;

using System.Collections.Generic;

public partial record Reader
{
    // Behavior
    public static Reader Create(long controllerId, long doorId, string name, string description, ReaderProtocol protocol, LEDType? lEDType, long? areaInId, long? areaOutId, string location, int heartbeatInterval, int timeout, string lPNCameraSN, bool isTimeAttendance, bool isEnrollmentReader, ActiveType lEDActiveLevel, ActiveType tamperingType, ActiveType beeperType, ReaderType readerType, AddReaderIdentificationTypeDTO[] readerIdentificationType)
    {
        return new Reader(controllerId,
                                    doorId,
                                    name,
                                    description,
                                    protocol,
                                    lEDType,
                                    areaInId,
                                    areaOutId,
                                    location,
                                    heartbeatInterval,
                                    timeout,
                                    lPNCameraSN,
                                    isTimeAttendance,
                                    isEnrollmentReader,
                                    lEDActiveLevel,
                                    tamperingType,
                                    beeperType,
                                    readerType,
                                    readerIdentificationType);

    }

    public bool UpdateReader(Reader_GetById_DTO dto)
    {
        bool detectChanges = false;
        var oldValue = new Reader_GetById_UpdateEventparametersDTO();
        var newValue = new Reader_GetById_UpdateEventparametersDTO();

        if (!Name.Equals(dto.Name))
        {
            oldValue.Name = Name;
            newValue.Name = dto.Name;
            detectChanges = true;
        }

        if (!Description.Equals(dto.Description))
        {
            oldValue.Description = Description;
            newValue.Description = dto.Description;
            detectChanges = true;
        }

        if (!Protocol.Equals(dto.Protocol))
        {
            oldValue.Protocol = Protocol;
            newValue.Protocol = dto.Protocol;
            detectChanges = true;
        }

        if (!LEDType.Equals(dto.LEDType))
        {
            oldValue.LEDType = LEDType;
            newValue.LEDType = dto.LEDType;
            detectChanges = true;
        }

        if (!AreaInId.Equals(dto.AreaInId))
        {
            oldValue.AreaInId = AreaInId;
            newValue.AreaInId = dto.AreaInId;
            detectChanges = true;
        }

        if (!AreaOutId.Equals(dto.AreaOutId))
        {
            oldValue.AreaOutId = AreaOutId;
            newValue.AreaOutId = dto.AreaOutId;
            detectChanges = true;
        }

        if (!Location.Equals(dto.Location))
        {
            oldValue.Location = Location;
            newValue.Location = dto.Location;
            detectChanges = true;
        }

        if (!HeartbeatInterval.Equals(dto.HeartbeatInterval))
        {
            oldValue.HeartbeatInterval = HeartbeatInterval;
            newValue.HeartbeatInterval = dto.HeartbeatInterval;
            detectChanges = true;
        }

        if (!Timeout.Equals(dto.Timeout))
        {
            oldValue.Timeout = Timeout;
            newValue.Timeout = dto.Timeout;
            detectChanges = true;
        }

        if (LPNCameraSN != dto.LPNCameraSN)
        {
            oldValue.LPNCameraSN = LPNCameraSN;
            newValue.LPNCameraSN = dto.LPNCameraSN;
            detectChanges = true;
        }

        if (!IsTimeAttendance.Equals(dto.IsTimeAttendance))
        {
            oldValue.IsTimeAttendance = IsTimeAttendance;
            newValue.IsTimeAttendance = dto.IsTimeAttendance;
            detectChanges = true;
        }

        if (!IsEnrollmentReader.Equals(dto.IsEnrollmentReader))
        {
            oldValue.IsEnrollmentReader = IsEnrollmentReader;
            newValue.IsEnrollmentReader = dto.IsEnrollmentReader;
            detectChanges = true;
        }

        if (!LEDActiveLevel.Equals(dto.LEDActiveLevel))
        {
            oldValue.LEDActiveLevel = LEDActiveLevel;
            newValue.LEDActiveLevel = dto.LEDActiveLevel;
            LEDActiveLevel = dto.LEDActiveLevel;
            detectChanges = true;
        }

        if (!TamperingType.Equals(dto.TamperingType))
        {
            oldValue.TamperingType = TamperingType;
            newValue.TamperingType = dto.TamperingType;
            detectChanges = true;
        }

        if (!BeeperType.Equals(dto.BeeperType))
        {
            oldValue.BeeperType = BeeperType;
            newValue.BeeperType = dto.BeeperType;
            detectChanges = true;
        }

        if (!ReaderType.Equals(dto.ReaderType))
        {
            oldValue.ReaderType = ReaderType;
            newValue.ReaderType = dto.ReaderType;
            detectChanges = true;
        }



        bool hasChnages = UpdateReaderIdentificationTypeDTO(dto.ReaderIdentificationType.ToList());
        if (hasChnages)
        {
            detectChanges = true;
        }

        if (detectChanges)
        {
            var e = new Reader_Updated(dto.Id, oldValue, newValue);
            RegisterEvent(e);
        }
        return detectChanges;
    }

    private bool UpdateReaderIdentificationTypeDTO(IEnumerable<ReaderIdentificationType_GetById_DTO> command)
    {
        //List<ReaderIdentificationType_GetById_UpdateEventDTO> oldValues = new List<ReaderIdentificationType_GetById_UpdateEventDTO>();
        // List<ReaderIdentificationType_GetById_UpdateEventDTO> newValues = new List<ReaderIdentificationType_GetById_UpdateEventDTO>();

        bool hasChanges = false;
        if (!(command.Any() && ReaderIdentificationType.Any()))
            return hasChanges;


        foreach (var rit in ReaderIdentificationType)
        {
            if (!command.Any(_ => _.Id == rit.Id))
            {
                rit.Delete();
                continue;
            }

            foreach (var dto in command)
            {

                if (rit.Id == dto.Id)
                {
                    //  var newValueObj = new ReaderIdentificationType_GetById_UpdateEventDTO();
                    //  var oldValueObj = new ReaderIdentificationType_GetById_UpdateEventDTO();
                    bool detectChanges = rit.Update(dto);
                    if (detectChanges)
                    {
                        hasChanges = true;
                    }
                    //  newValues.Add(newValueObj);
                    //  oldValues.Add(oldValueObj);

                }
                else
                {
                    var oldValueObj = new ReaderIdentificationType_GetById_UpdateEventDTO();


                    var newRITObj = ReaderModeds.ReaderIdentificationType.Create(ControllerId, dto.IdentificationType, dto.DuringScheduleId, dto.ExceptScheduleId);
                    var newValueObj = new ReaderIdentificationType_GetById_UpdateEventDTO()
                    {
                        IdentificationType = dto.IdentificationType,
                        DuringScheduleId = dto.DuringScheduleId,
                        ExceptScheduleId = dto.ExceptScheduleId,
                    };

                    //  newValues.Add(newValueObj);
                    //  oldValues.Add(oldValueObj);
                    hasChanges = true;
                }
            }


        }
        return hasChanges;
    }
}
