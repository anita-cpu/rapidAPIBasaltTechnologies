using System;

namespace RapidAPISDK
{
    /// <summary>
    /// Represents an exception specific to RapidAPI server errors.
    /// </summary>
    public class RapidAPIServerException : Exception
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the RapidAPIServerException class with the specified error object.
        /// </summary>
        /// <param name="error">The error object associated with the exception.</param>
        public RapidAPIServerException(object error) : base(error.ToString())
        {
            Error = error;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the error object associated with the exception.
        /// </summary>
        public object Error { get; }

        #endregion

        #region Overrides of Exception

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"Error: {Error} {Environment.NewLine} {base.ToString()}";
        }

        #endregion
    }
}
