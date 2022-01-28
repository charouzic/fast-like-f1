namespace F1Api.Domain.Exceptions;

public class DriverNotFoundException : Exception
{
    public DriverNotFoundException(string surname) : base($"Driver with surname {surname} could not be found") {}
}