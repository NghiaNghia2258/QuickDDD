﻿namespace WebApi.Shared.Exceptions;

public class RecordAlreadyExistsException : Exception
{
    public RecordAlreadyExistsException() : base("Record already exists !!!") { }
    public RecordAlreadyExistsException(string message) : base(message) { }
    public RecordAlreadyExistsException(string message, Exception inner) : base(message, inner) { }
    protected RecordAlreadyExistsException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}
