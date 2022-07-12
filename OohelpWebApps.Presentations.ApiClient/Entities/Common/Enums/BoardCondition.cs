namespace OohelpWebApps.Presentations.ApiClient.Entities.Common.Enums;

public enum BoardCondition
{
    //Базовые состояния
    Free = 0,
    Booked = 1,
    Reserved = 2,
    Cancelled = 3,

    //Исключительные состояния        
    Inactive = 11,
    Dismantled = 12,

    //Запросы на изменение состояния
    BookingRequest = 41,
    ReserveRequest = 42,
    CancellationRequest = 43,

    //Состояния ожидания изменений
    WaitingBookingConfirmation = 61,
    WaitingReserveConfirmation = 62,
    WaitingCancellationConfirmation = 63
}
