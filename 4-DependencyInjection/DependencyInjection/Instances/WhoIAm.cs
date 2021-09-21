using System;
using DependencyInjection.Interfaces;

namespace DependencyInjection.Instances
{
    public class WhoIAm: IScopedWhoIAm,ISingletonWhoIAm,ITransientWhoIAm
    {
        private readonly int _identificationNumber;

        public WhoIAm()
        {
            _identificationNumber = new Random().Next(1, 10);
        }
        public string TellMeYourId()
        {
            return $"Soy la instancia {_identificationNumber}";
        }
    }
}
