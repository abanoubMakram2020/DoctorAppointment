using SharedKernal.Common.Enum;

namespace SharedKernal.Middlewares.ResourcesReader.Message
{
    public interface IMessageResourceReader
    {
        string GetMessage(ResponseStatusCode responseStatus);
        string GetMessage(string messageKey);
        string GetValidationMessage(string messageKey);
    }
}
