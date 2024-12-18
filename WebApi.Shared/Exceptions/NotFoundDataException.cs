﻿namespace WebApi.Shared.Exceptions;

public class NotFoundDataException : Exception
{
    public NotFoundDataException() : base("Not found data") { }
    public NotFoundDataException(string message) : base(message) { }
    public NotFoundDataException(string message, Exception inner) : base(message, inner) { }
    protected NotFoundDataException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}
