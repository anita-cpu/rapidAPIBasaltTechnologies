using System;

namespace RapidAPISDK.Events
{
    /// <summary>
    /// Represents a delegate type for handling message events.
    /// </summary>
    /// <param name="message">The message received.</param>
    public delegate void MessageCallback(string message);

    /// <summary>
    /// Represents a delegate type for handling error events.
    /// </summary>
    /// <param name="reason">The reason for the error.</param>
    public delegate void ErrorCallback(string reason);

    /// <summary>
    /// Represents a delegate type for handling timeout events.
    /// </summary>
    public delegate void TimeOutCallback();

    /// <summary>
    /// Represents a delegate type for handling connection events.
    /// </summary>
    public delegate void ConnectCallback();
}

