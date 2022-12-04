namespace Persistence.Constants;

using Domain.Exceptions;

internal static class Constants
{

    public static string GetToken_PostFix(string tableName) => tableName switch
    {
        "Controller" => "cntrl",
        "Schedule" => "schd",
        "Door" => "door",
        "Reader" => "reader",
        "CardFormat" => "crdfrmt",
        "AccessLevel" => "accslvl",
        "QUser" => "qUser",
        "Card" => "crd",
        _ => throw new QException($"No Token is found against the {tableName} Table.")
    };
}
