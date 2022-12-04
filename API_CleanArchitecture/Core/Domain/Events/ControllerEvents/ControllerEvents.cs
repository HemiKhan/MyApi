namespace Domain.Events.ControllerEvents;

using Domain.Dtos.Door;
using Domain.Models.ControllerModels;
using Domain.Models.ControllerModels.DoorModels;

internal record Controller_Added(string Name, string UserName, string Password, string MACAddress, string OAK, bool IsOneDoor, ControllerModel Model) : IDomainEvent;
internal record Controller_Deleted(Controller Controller) : IDeleteDomainEvent;

internal record Controller_Door1StatusAdded(bool Status) : IDomainEvent;
internal record Controller_Door2StatusAdded(long Id, bool Old, bool New) : IDomainEvent;
internal record Controller_DoorAdded(Door_Add_DTO Values) : IDomainEvent;
internal record Controller_DoorUpdated(Door Values) : IDomainEvent;

internal record Controller_Object_Created(long Id) : IDomainEvent;


internal record Controller_DoorConfigUpdated(long Id, bool Old, bool New) : IDomainEvent;
internal record Controller_NameUpdated(long Id, string Old, string New) : IDomainEvent;
internal record Controller_MACAddressUpdated(long Id, string Old, string New) : IDomainEvent;
internal record Controller_PasswordUpdated(long Id, string Old, string New) : IDomainEvent;
internal record Controller_UserNameUpdated(long Id, string Old, string New) : IDomainEvent;
internal record Controller_OAKUpdated(long Id, string Old, string New) : IDomainEvent;
internal record Controller_ModelUpdated(long Id, ControllerModel Old, ControllerModel New) : IDomainEvent;