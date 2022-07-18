using SharedKernal.Common.Enum;

namespace SharedKernal.Middlewares.ResourcesReader.Message
{
    public class MessageResourceReader : FileReader, IMessageResourceReader
    {
        public MessageResourceReader()
        {
        }
        public string GetMessage(ResponseStatusCode responseStatus) => GetKeyValue(key: responseStatus.ToString());
        public string GetMessage(string messageKey) => GetKeyValue(key: messageKey);
        public string GetValidationMessage(string messageKey) => GetValidationKeyValue(key: messageKey);
    }
}