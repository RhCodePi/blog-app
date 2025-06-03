namespace BlogApp.Application.Abstractions.Services
{
    public interface IDateTimeFormatter
    {
        string ConvertToString(DateTime date);
    }
}
