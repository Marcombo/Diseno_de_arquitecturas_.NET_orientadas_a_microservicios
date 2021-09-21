using System;
namespace DependencyInjection.Interfaces
{
    public interface ISingletonWhoIAm
    {
        string TellMeYourId();
    }
    public interface IScopedWhoIAm
    {
        string TellMeYourId();
    }
    public interface ITransientWhoIAm
    {
        string TellMeYourId();
    }
}
