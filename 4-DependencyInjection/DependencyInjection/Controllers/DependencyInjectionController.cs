using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjection.Interfaces;
using DependencyInjection.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DependencyInjection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DependencyInjectionController : ControllerBase
    {
        private readonly ISingletonWhoIAm _singletonWhoIAm;
        private readonly IScopedWhoIAm _scopedWhoIAm;
        private readonly ITransientWhoIAm _transientWhoIAm;
        private readonly IServiceWhoIAm _serviceWhoIAm;

        public DependencyInjectionController(ISingletonWhoIAm singletonWhoIAm,
                                             IScopedWhoIAm scopedWhoIAm,
                                             ITransientWhoIAm transientWhoIAm,
                                             IServiceWhoIAm serviceWhoIAm) {
            _singletonWhoIAm = singletonWhoIAm;
            _scopedWhoIAm = scopedWhoIAm;
            _transientWhoIAm = transientWhoIAm;
            _serviceWhoIAm = serviceWhoIAm;
        }

        [HttpGet]
        public ActionResult Get() => Ok(new {
            ApiResponse = new {
                Singleton = _singletonWhoIAm.TellMeYourId(),
                Scoped = _scopedWhoIAm.TellMeYourId(),
                Transient = _transientWhoIAm.TellMeYourId()
            },
            ServiceResponse = _serviceWhoIAm.Invoke()
        });
    }
}
