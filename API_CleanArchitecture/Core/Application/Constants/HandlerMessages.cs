namespace Application.Constants;
internal static partial class HandlerMessages
{
    internal static class ControllerHandlerMessages
    {
        public const string ControllerNameAlreadyExist = "ControlllerName.Already.Exist";
        public const string ControllerDoestNotFound = "Controller.NotFound";
    }

    internal static class ScheduleHandlerMessages
    {
        public const string ScheduleNameAlreadyExist = "ScheduleName.Already.Exist";
        public const string NotFound = ModelFields.ScheduleFields.Schedule + QMessages.CommonMessages.NotFound;
    }

    internal static class ScheduleItemHanderMessages
    {
        public const string NotFound = "ScheduleItem.NoFound";
        public const string NameAlreadyExist = "ScheduleItem.Already.Exist";
    }

    internal static class CardFormatHandlerMessages
    {
        public const string CardFormatNameAlreadyExist = "CardFormatName.Already.Exist";
        public const string NotFound = ModelFields.CardFormatFields.CardFormatName + QMessages.CommonMessages.NotFound;
    }

    internal static class CardFormatItemHanderMessages
    {
        public const string NotFound = "CardFormatItem.NoFound";
        public const string NameAlreadyExist = "CardFormatItem.Already.Exist";
    }

    internal static class PriorityHandlerMessages
    {
        public const string LevelAlreadyExists = "Priority Level Already Exists";
        //public const string NameAlreadyExist = "ScheduleItem.Already.Exist";
    }

    internal static class QUserAccessLevelHanderMessages {
        public const string SingleUserAccessLevelValidationError = "Single Access Level Can't Be Assigned Multiple Times.";
    }
}
