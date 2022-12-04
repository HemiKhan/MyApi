namespace Infrastructure.Services.ScheduleServices;

using System.Threading;

using Application.Common;
using Application.Handlers;
using Application.Interfaces;
using Application.Interfaces.Services.ScheduleServices;
using Domain.Dtos.Schedule.ScheduleItemsDtos;
using Domain.Exceptions;
using Domain.Models.ScheduleModels;

using AutoWrapper.Wrappers;
using App_CleanArchitecture.Helpers;

public record ScheduleItemService(IQSender QSender) : IScheduleItemService
{
    #region AddItems
    async Task<ApiResponse> IScheduleItemService.AddScheduleItemsAsync(AddScheduleItemDto Request, CancellationToken cancellationToken)
    {
        try
        {
            // checking schedule is subtract or not
            var add_Command_Request = await ValidateAddRequest(Request);

            var result = await AddScheduleItemsInDb(add_Command_Request, cancellationToken);

            AddDefinitionIntoSchedule(add_Command_Request, cancellationToken);

            return result.Result!;
            async Task<ScheduleItems_AddUpDate_Request> ValidateAddRequest(AddScheduleItemDto input)
            {
                ScheduleItems_AddUpDate_Request add_Command_Request = new();
                add_Command_Request.Summary = input.Summary;
                add_Command_Request.ScheduleId = input.ScheduleId;
                add_Command_Request.RecurrenceDays = input.RecurrenceDays;
                add_Command_Request.StartTime = input.StartTime;
                add_Command_Request.EndTime = input.EndTime;
                add_Command_Request.EndBy = input.EndBy;
                add_Command_Request.StartDate = input.StartDate;
                add_Command_Request.EndDate = input.EndDate;
                add_Command_Request.IsWeekly = input.IsWeekly;
                add_Command_Request.IsRecurrence = input.IsRecurrence;
                add_Command_Request.IsAllday = input.IsAllDay;
                add_Command_Request.IsEndBy = input.IsEndBy;
                AddScheduleItemsValidation(add_Command_Request);
                return await Task.FromResult(add_Command_Request);
            }
        }
        catch (Exception ex)
        {
            throw AutoWrapperHelper.GenerateError(ex);
        }
    }
    private void AddDefinitionIntoSchedule(ScheduleItems_AddUpDate_Request request, CancellationToken cancellationToken)
    {
        var result = CreateDefinitionForSchedule(request, cancellationToken);
        var updateDefinitionDto = new UpdateScheduleDefinitionDTO(request.ScheduleId, result);
        var addScheduleResult = QSender.Send(new CommandRequest<UpdateScheduleDefinitionDTO>(updateDefinitionDto), cancellationToken).Result;
        if (addScheduleResult.Status is Status.Exception)
            throw new ApiException("Request Cannot processed");
    }

    private async Task<QResult<long?>> AddScheduleItemsInDb(ScheduleItems_AddUpDate_Request Request, CancellationToken cancellationToken)
    {
        return await QSender.Send(new CommandRequest<ScheduleItems_AddUpDate_Request>(Request), cancellationToken);
    }
    #endregion
    #region DataValidatation
    private void AddScheduleItemsValidation(ScheduleItems_AddUpDate_Request Request)
    {
        if (Request.IsRecurrence)
        {
            // checking DuringScheduleId is weekly or yearly
            AddScheduleIfWeekly(Request);
        }
        else
        {
            //checking is all day
            AddEndDateIfAllDay(Request);
            Request.ItemDefinition = CreateBodyDefinition(Request, "OneTime");
        }
    }

    private static bool CheckRecurrenceDaysValidation(ScheduleItems_AddUpDate_Request Request)
    {
        //FETCHING FIRST 2 CHAR DAY NAME FROM DATE
        string startday = Request.StartDate.ToString("ddd").ToUpper()[..2]!;
        var days = Request.RecurrenceDays!;
        //CHECKING RECURRENCE DAYS LIST CONTAIN START DATE DAY
        var isRecurrenceDaysValidate = days.Contains(startday);
        return isRecurrenceDaysValidate;
    }

    private void AddEndDateIfAllDay(ScheduleItems_AddUpDate_Request Request)
    {
        if (Request.IsAllday)
        {
            // CONVERTING DATE TIME TO STRING USING FORMATE TO VALIDATE THAT GIVEN DATE IS  VALI OR NOT
            var convertedDate = Request.StartDate.ToString("yyyy/MM/dd");
            if (!ValidateDate(convertedDate)!)
                throw new QException("Invalid date");
            DateTime? startdate = Request.StartDate;
            //enddate = startdate + one day
            Request.EndDate = startdate!.Value.AddDays(1);
        }
        else
        {
            DateTimeValidation(Request);
        }
    }
    private void AddEndDateIfIsRecurrence(ScheduleItems_AddUpDate_Request Request)
    {
        // CONVERTING DATE TIME TO STRING USING FORMATE TO VALIDATE THAT GIVEN DATE IS  VALI OR NOT
        var convertedDate = Request.StartDate.ToString("yyyy/MM/dd");
        if (!ValidateDate(convertedDate)!)
            throw new QException("Invalid date");
        DateTime? startdate = Request.StartDate;
        //enddate = startdate + one day
        Request.EndDate = startdate!.Value.AddDays(1);

    }

    private static void DateTimeValidation(ScheduleItems_AddUpDate_Request Request)
    {
        try
        {
            // CHECKING START DATE GRATER THAND END DATE OR NOT
            if (Request.StartDate > Request.EndDate)
                throw new QException("End date must be grater than start date");

            ValidateTime(Request);
        }
        catch (Exception)
        {
            throw;
        }
        //if (Request.scheduleItems_AddUpdate_Request.StartDate == null || Request.scheduleItems_AddUpdate_Request.EndDate == null)
        //    throw new QException("Start date and End date required");
    }

    private static void ValidateTime(ScheduleItems_AddUpDate_Request Request)
    {
        // CONVERYTING AND SPLITING TIME 00:00 TO THIS 0000 FOR VALIDATE START TIME IS NOT GRATER THAND END TIME
        var sTime = SplitTime(Request.StartTime!);
        if (sTime == "Invalid Time")
            throw new QException("Invalid Time");
        var eTime = SplitTime(Request.EndTime!);
        if (eTime == "Invalid Time")
            throw new QException("Invalid Time");
        int startTime = Convert.ToInt32(sTime);
        int endTime = Convert.ToInt32(eTime);
        if (startTime > endTime)
            throw new QException("End time must be grater than start time");
    }

    private static string SplitTime(string time)
    {
        if (time.Contains(":"))
        {
            if (time.Length == 5)
            {
                var splitedTime = time.Split(":");
                var concate = splitedTime[0] + splitedTime[1];
                if (concate.All(char.IsDigit))
                    return concate;
            }
        }
        return "Invalid Time";
    }

    private bool ValidateDate(string date)
    {
        try
        {
            // for US, alter to suit if splitting on hyphen, comma, etc.
            string[] dateParts = date.Split('/');

            // create new date from the parts; if this does not fail
            // the method will return true and the date is valid
            DateTime testDate = new
                DateTime(Convert.ToInt32(dateParts[0]),
                Convert.ToInt32(dateParts[1]),
                Convert.ToInt32(dateParts[2]));

            return true;
        }
        catch
        {
            // if a test date cannot be created, the
            // method will return false
            return false;
        }
    }
    private void AddScheduleIfWeekly(ScheduleItems_AddUpDate_Request Request)
    {
        if (Request.IsWeekly)
        {
            if (Request.RecurrenceDays!.Any())
            {
                AddEndDateIfIsRecurrence(Request);

                if (!CheckRecurrenceDaysValidation(Request))
                    throw new QException("First occurrence must be a checked day");

                Request.ItemDefinition = CreateBodyDefinition(Request, "Weekly");
            }
        }
        else
        {
            AddEndDateIfIsRecurrence(Request);
            Request.ItemDefinition = CreateBodyDefinition(Request, "Yearly");
        }
    }
    #endregion

    #region CreatingDefinition
    private string CreateDefinitionForSchedule(ScheduleItems_AddUpDate_Request request, CancellationToken cancellationToken)
    {
        string Definition = $"BEGIN:VCALENDAR\r\nPRODID:\r\nVERSION:2.0\r\n";
        var itemRequest = new GetScheduleItemByScheduleDTO(request.ScheduleId);
        var result = QSender.Send(new QueryRequest<GetScheduleItemByScheduleDTO, IEnumerable<ScheduleItem>>(itemRequest)).Result;
        foreach (var item in result.Value!)
        {
            Definition += item.ItemDefinition + $"\r\n";
        }
        Definition += $"\r\nEND:VCALENDAR";
        return Definition;
    }

    private string CreateBodyDefinition(ScheduleItems_AddUpDate_Request request, string ScheduleType)
    {
        string startTime = "";
        string endTime = "";
        if (request.IsAllday == true)
        {
            startTime = "0000";
            request.StartTime = startTime;
        }
        else
        {
            startTime = SplitTime(request.StartTime!);
        }
        if (request.IsAllday == true)
        {
            endTime = "0000";
            request.EndTime = endTime;
        }
        else
        {
            endTime = SplitTime(request.EndTime!);
        }
        var DTEND = request.StartTime == request.EndTime ? request.StartDate.AddDays(1).ToString("yyyyMMdd") : request.StartDate.ToString("yyyyMMdd");
        return $"BEGIN:VEVENT\r\nSUMMARY:{request.Summary}\r\nDTSTART:{request.StartDate.ToString("yyyyMMdd")}TEntity{startTime}00\r\nDTEND:{DTEND}TEntity{endTime}00\r\n{(ScheduleType == "OneTime" ? null : $"RRULE:{PRULE(ScheduleType, request.EndDate, request.IsEndBy, request.RecurrenceDays)}")}\r\nEND:VEVENT";
    }
    private string PRULE(string scheduleType, DateTime? EndDate, bool IsEndBy, string RecurrenceDays)
    {
        string definition = "";
        if (scheduleType == "Weekly" && IsEndBy == false)
        {
            definition += $"FREQ=WEEKLY;BYDAY={RecurrenceDays}";
        }
        if (scheduleType == "Weekly" && IsEndBy == true)
        {
            definition += $"FREQ=WEEKLY;BYDAY={RecurrenceDays};UNTIL={EndDate?.ToString("yyyyMMdd")}T185959";
        }
        if (scheduleType == "Yearly" && IsEndBy == false)
        {
            definition += "FREQ=YEARLY";
        }
        if (scheduleType == "Yearly" && IsEndBy == true)
        {
            definition += $"FREQ=YEARLY;UNTIL={EndDate?.ToString("yyyyMMdd")}T185959";
        }
        return definition;
    }

    #endregion CreatingDefinition

    #region DeleteItems
    public async Task<ApiResponse> DeleteItemAsync(DeleteScheduleItemDto Dto, CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await QSender.Send(new CommandRequest<DeleteScheduleItemDto>(Dto));
            return result.Result!;
        }
        catch (Exception ex)
        {
            throw AutoWrapperHelper.GenerateError(ex);
        }
    }
    #endregion

    #region UpdateItem
    public async Task<ApiResponse> UpdateScheduleItemsAsync(UpdateScheduleItemDto dto, CancellationToken cancellationToken = default)
    {
        try
        {
            // checking schedule is subtract or not
            var add_Command_Request = await ValidateAddRequest(dto);

            var result = await AddScheduleItemsInDb(add_Command_Request, cancellationToken);

            AddDefinitionIntoSchedule(add_Command_Request, cancellationToken);

            return result.Result!;
            async Task<ScheduleItems_AddUpDate_Request> ValidateAddRequest(UpdateScheduleItemDto input)
            {
                ScheduleItems_AddUpDate_Request add_Command_Request = new();
                add_Command_Request.Id = input.Id;
                add_Command_Request.ScheduleId = input.ScheduleId;
                add_Command_Request.Summary = input.Summary;
                add_Command_Request.RecurrenceDays = input.RecurrenceDays;
                add_Command_Request.StartTime = input.StartTime;
                add_Command_Request.EndTime = input.EndTime;
                add_Command_Request.EndBy = input.EndBy;
                add_Command_Request.StartDate = input.StartDate;
                add_Command_Request.EndDate = input.EndDate;
                add_Command_Request.IsWeekly = input.IsWeekly;
                add_Command_Request.IsRecurrence = input.IsRecurrence;
                add_Command_Request.IsAllday = input.IsAllDay;
                add_Command_Request.IsEndBy = input.IsEndBy;
                AddScheduleItemsValidation(add_Command_Request);
                return await Task.FromResult(add_Command_Request);
            }
        }
        catch (Exception ex)
        {
            throw AutoWrapperHelper.GenerateError(ex);
        }
    }
    #endregion

    #region GetItems

    public async Task<ApiResponse> GetItemByIdAsync(GetScheduleItemByIdDTO dto, CancellationToken cancellationToken = default)
    {
        var result = await QSender.Send(new QueryRequest<GetScheduleItemByIdDTO, GetScheduleItemDTO>(dto));
        return result.Result!;
    }
    #endregion
}
