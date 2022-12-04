namespace Application.Constants;
internal static partial class ModelMessages
{
    public static class Controller
    {
        public const string ControllerNotFound = "Controller.NoFound";
        public const string NameAlreadyExist = "ControllerName.AlreadyExists";
    }
    public static class Door
    {
        public const string IdNotExist = "Id not exist";
    }

    public static class ScheduleMessages
    {
        public const string NotFound = "DuringScheduleId.NoFound";
        public const string NameAlreadyExist = "DuringScheduleId.Name already exist please try with different name";
    }

    public static class DatetimeSettingMessages
    {
        public const string DateMaxMinErrorMessage = "Date must be greater thand 1970 and less than 2037";
    }
}
