﻿namespace eComApp.Application.Exceptions;

public class ItemNotFoundException(string message) : Exception(message)
{
}