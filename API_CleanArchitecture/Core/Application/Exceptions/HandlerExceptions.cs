namespace Application.Exceptions;

using Application.Constants;
using Domain.Exceptions;
using static Application.Constants.HandlerMessages;

internal static class HandlerExceptions
{
    public static class ControllerHandlerExceptions
    {
        public static QException ControllerNameAlreadyExist =>
            new(ValidationExceptions.GetValidationErrors("." + QMessages.CommonMessages.AlreadyExist, ModelFields.ControllerFields.ControllerName));
        public static QException ControllerDoesNotExists =>
                  new(ValidationExceptions.GetValidationErrors("." + QMessages.CommonMessages.DoesNotExist, ModelFields.ControllerFields.Controller));

    }

    public static class CommonHandlerExceptions
    {
        internal static QException NameAlreadyExist =>
            new(ValidationExceptions.GetValidationErrors( QMessages.CommonMessages.AlreadyExist, ModelFields.CommonFields.Name));
        internal static QException IdDoesNotExist =>
                new(ValidationExceptions.GetValidationErrors(QMessages.CommonMessages.DoesNotExist, ModelFields.CommonFields.Id));
        internal static QException ItemNotFound =>
                        new(ValidationExceptions.GetValidationErrors(QMessages.CommonMessages.DoesNotExist, ModelFields.CommonFields.Item));

    }

    internal static class DoorHandlerException
    {
        public static QException DoorDoesNotExists =>
            new(ValidationExceptions.GetValidationErrors(QMessages.CommonMessages.DoesNotExist, ModelFields.CommonFields.Id));
    }

    internal static class PrioritiesHandlerException
    {
        internal static QException PriorityNameAlreadyExists
            => new(ValidationExceptions.GetValidationErrors(QMessages.CommonMessages.AlreadyExist, ModelFields.CommonFields.Name));

        internal static QException PriorityLevelAlreadyExists
           => new(ValidationExceptions.GetValidationErrors(QMessages.CommonMessages.AlreadyExist, ModelFields.PriorityFields.PriorityLevel));
        internal static QException NoPriorityExists
                => new(ValidationExceptions.GetValidationErrors(QMessages.CommonMessages.NotFound, ModelFields.PriorityFields.Priority));

    }
    public static class CardformatHandlerExceptions
    {
        public static QException CardformatNameAlreadyExist =>
            new(ValidationExceptions.GetValidationErrors("." + QMessages.CommonMessages.AlreadyExist, ModelFields.CardFormatFields.CardFormatName));
    }

    public static class AccessLevelsExceptions
    {
        public static QException AccessLevelNameAlready =>
            new(ValidationExceptions.GetValidationErrors("." + QMessages.CommonMessages.AlreadyExist, ModelFields.CardFormatFields.CardFormatName));
    }

    public static class QUserCardExecptions
    {
        public static QException CardNumberAlreadyExist =>
            new QException(ValidationExceptions.GetValidationErrors("" + QMessages.CommonMessages.AlreadyExist, ModelFields.Card.CardNumber));

        public static QException CardRawAlreadyExist =>
            new QException(ValidationExceptions.GetValidationErrors("" + QMessages.CommonMessages.AlreadyExist, ModelFields.Card.CardRaw));
    }

    public static class QUserAccessLevelsExecptions
    {
        public static QException SingleAccessLevelCantBeAssignedMultipleTimes =>
            new QException(ValidationExceptions.GetValidationErrors(","+ QUserAccessLevelHanderMessages.SingleUserAccessLevelValidationError, ModelFields.QUserAccessLevel.AccessLevelId));
    }

    public static class AccessConfigExceptions
    {
        public static QException AccessConfigKeyDoesNotExist =>
            new(ValidationExceptions.GetValidationErrors(QMessages.CommonMessages.DoesNotExist, ModelFields.AccessConfigFields.AccessConfigKey));
        public static QException ConfigurationNotFound =>
                  new(ValidationExceptions.GetValidationErrors(QMessages.CommonMessages.NotFound, ModelFields.AccessConfigFields.Configuration));
    }

}
