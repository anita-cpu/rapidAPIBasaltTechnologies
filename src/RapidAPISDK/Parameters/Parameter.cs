using System.Net.Http;

namespace RapidAPISDK
{
    /// <summary>
    /// Represents a base class for parameters used in RapidAPI SDK.
    /// </summary>
    public abstract class Parameter
    {
        #region Constructors

        /// <summary>
        /// Default constructor for Parameter class.
        /// </summary>
        protected Parameter()
        {
        }

        /// <summary>
        /// Constructor for Parameter class with a specified key.
        /// </summary>
        /// <param name="key">The key associated with the parameter.</param>
        protected Parameter(string key)
        {
            Key = key;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the key associated with the parameter.
        /// </summary>
        public string Key { get; set; }

        #endregion

        #region Abstract Methods

        /// <summary>
        /// Adds the parameter to the content of the multipart form data.
        /// </summary>
        /// <param name="content">The multipart form data content to which the parameter will be added.</param>
        public abstract void AddToContent(MultipartFormDataContent content);

        #endregion
    }
}
