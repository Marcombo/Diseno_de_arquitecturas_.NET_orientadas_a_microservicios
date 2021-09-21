using DependencyInjection.Interfaces;
namespace DependencyInjection.Services
{
    public interface IServiceWhoIAm {
        dynamic Invoke();
    }

    public class ServiceWhoIAm : IServiceWhoIAm
    {
        private readonly ISingletonWhoIAm _singletonWhoIAm;
        private readonly IScopedWhoIAm _scopedWhoIAm;
        private readonly ITransientWhoIAm _transientWhoIAm;

        public ServiceWhoIAm(ISingletonWhoIAm singletonWhoIAm
                           , IScopedWhoIAm scopedWhoIAm
                           , ITransientWhoIAm transientWhoIAm) {
            _singletonWhoIAm = singletonWhoIAm;
            _scopedWhoIAm = scopedWhoIAm;
            _transientWhoIAm = transientWhoIAm;
        }

        public dynamic Invoke() => new {
            Singleton   = _singletonWhoIAm.TellMeYourId(),
            Scoped      = _scopedWhoIAm.TellMeYourId(),
            Transient   = _transientWhoIAm.TellMeYourId()
        };
    }
}
