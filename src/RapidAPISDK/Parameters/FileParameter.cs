using System;
using System.IO;
using System.Net.Http;

namespace RapidAPISDK
{
    public class FileParameter : Parameter
    {
        #region Constructors

        // Default constructor
        public FileParameter()
        {
        }

        // Constructor with key, stream, and fileName parameters
        public FileParameter(string key, Stream stream, string fileName) : base(key)
        {
            // Check for null arguments
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (fileName == null) throw new ArgumentNullException(nameof(fileName));

            // Set the stream and file name
            Stream = stream;
            FileName = fileName;
        }

        // Constructor with key, filePath, and fileName parameters
        public FileParameter(string key, string filePath, string fileName = null) : base(key)
        {
            // Check for null argument and file existence
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));
            if (!File.Exists(filePath)) throw new FileNotFoundException("File not exist or can't be read.");

            // Open a file stream with read access
            Stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            // Use the provided fileName or the file name from the filePath
            FileName = fileName ?? Path.GetFileName(filePath);
        }

        #endregion

        #region Public Properties

        // Stream property to hold the file stream
        public Stream Stream { get; set; }

        // FileName property to hold the file name
        public string FileName { get; set; }

        #endregion

        #region Overrides of Parameter

        // Add the file parameter to the content of the multipart form data
        public override void AddToContent(MultipartFormDataContent content)
        {
            // Create a stream content from the file stream
            StreamContent streamContent = new StreamContent(Stream);
            // Add the stream content to the provided content with key and file name
            content.Add(streamContent, Key, FileName);
        }

        #endregion
    }
}
