namespace Domain.Exceptions;

using Domain.Constants;

internal static partial class QExceptions
{
    internal static class EventsExceptions
    {
        internal static QException EventCantBeAddedInWhenMethod => new(Messages.EventsMessages.EventCantBeAddedInWhenMethod);
    }

    internal static class ControllerExceptions
    {
        internal static QException Door1AlreadyExist => new(ValidationExceptions.GetValidationErrors(".Already.Exist", "Door1"), 400);
        internal static QException DoorsMustBeNotBeGreaterThan2 => new(Messages.ControllerMessages.DoorsMustBeNotBeGreaterThan2);

        internal static QException CannotAddDoorMoreThan1WhenOneDoorConfigIsEnabled => new(Messages.ControllerMessages.CannotAddDoorMoreThan1WhenOneDoorConfigIsEnabled);
    }

    internal static class DoorExceptions
    {
        internal static QException ReadersMustBeNotBeGreaterThan2OrLessThan1WhenDoorConfigIsEnabled => new(Messages.DoorMessages.ReadersMustBeNotBeGreaterThan2OrLessThan1WhenDoorConfigIsEnabled);
        internal static QException RexMustBeNotBeGreaterThan2OrLessThan1WhenDoorConfigIsEnabled => new(Messages.DoorMessages.RexMustBeNotBeGreaterThan2OrLessThan1WhenDoorConfigIsEnabled);

        internal static QException ReaderMustBeEqualTo1WhenOneDoorConfigIsDisabled => new(Messages.DoorMessages.ReaderMustBeEqualTo1WhenOneDoorConfigIsDisabled);
        internal static QException RexMustBeNotBeEqualTo1WhenOneDoorConfigIsDisabled => new(Messages.DoorMessages.RexMustBeNotBeEqualTo1WhenOneDoorConfigIsDisabled);
    }

    internal static class ReaderExceptions
    {
        internal static QException LEDTypeMustBeDefinedWhenProcotolIsWiegand => new(Messages.ReaderMessages.LedTypeMustNotBeNull);
    }
}
