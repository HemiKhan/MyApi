namespace Domain.Constants;
using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ControllerState
{
    Pending,
    Disable,
    Active
}
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DoorState
{
    Unknown,
    Locked
}
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DoorType
{
    Door,
    Door1,
    Door2
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum LockMonitorType
{
    lock1,
    lock2
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RelayStateLockedType
{
    Open,
    Closed
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum LockType
{
    Relay,
    None
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum LockMonitor
{
    open_circuit_locked,
    open_circuit_unlocked
}
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DoorMonitor
{
    open_open_circuit,
    open_closed_circuit
}
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ActiveType
{
    ActiveLow,
    ActiveHigh
}
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum LEDType
{
    SingleLED,
    DualLED,
}
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ReaderProtocol
{
    Wiegand,
    OSDP   //RS-485HD API value
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SetMode
{
    Manual,
    NTP,
    System
}
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ControllerModel
{
    A1601,
    A1001
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RexType
{
    Rex1,
    Rex2
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ReaderType
{
    Reader1,
    Reader2
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Identification
{
    Card,
    CardNr,
    PIN,
    FacilityCode,
    LPN
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum IdentificationType
{
    FacilityCodeOnly,
    CardNumberOnly,
    CardRawOnly,
    PINOnly,
    CardRawAndPIN,
    FacilityCodeAndPIN,
    CardNumberAndPIN,
    LicensePlateOnly
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AntipassbackModeType
{
    Logical,
    TimeLogical
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AntiPassbackEnforcementModeType
{
    Hard,
    Soft
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum CardStatus
{
    Enabled,
    Disabled,
    Lost,
    Suspend


}
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PortType
{
    Input,
    Output
}
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum State
{
    Groundedcircut,
    Opencircut
}
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ManualCtrlAction
{
    Unlock,
    LockDown,
    Momentary,
    GetCurrentState
}