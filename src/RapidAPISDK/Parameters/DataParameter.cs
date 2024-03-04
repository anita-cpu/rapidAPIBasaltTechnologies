using System.Net.Http;

namespace RapidAPISDK
{
    public class DataParameter : Parameter
    {
        #region C'tor

        // Default constructor
        public DataParameter()
        {
        }

        // Constructor with key parameter
        public DataParameter(string key) : base(key)
        {
        }

        // Constructor with key and value parameters
        public DataParameter(string key, string value) : base(key)
        {
            Value = value;
        }

        #endregion

        #region Public Properties

        // Value property to hold the parameter value
        public string Value { get; set; }

        #endregion

        #region Overrides of Parameter

        // Add the parameter to the content of the multipart form data
        public override void AddToContent(MultipartFormDataContent content)
        {
            // Add the parameter as a string content to the provided content
            content.Add(new StringContent(Value ?? string.Empty), Key);
        }

        #endregion
    }
}
