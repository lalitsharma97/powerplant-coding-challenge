using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Powerplant_Unit_Measurement.Entity;
using Powerplant_Unit_Measurement.Model;
using Powerplant_Unit_Measurement.Utilities;
using System.Net;

namespace Powerplant_Unit_Measurement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PowerProducedController : ControllerBase
    {
        private readonly ILogger<PowerProducedController> _logger;
        private IUnitCommitment _unitCommitment;

        public PowerProducedController(ILogger<PowerProducedController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Post json to calculate unit commitment
        /// Create by: Lalit Kumar
        /// Created on : 17-Oct-23
        /// Updated by : NA
        /// Updated on : 17-Oct-23
        /// </summary>
        /// <param name="powerPayload">json object</param>
        [AllowAnonymous]
        [HttpPost(Name = "PowerProduced")]
        public IEnumerable<PowerProduced> Post(dynamic powerPayload)
        {
            try
            {
                _unitCommitment = new UnitCommitment();             
                return _unitCommitment.CalculateUnitCommitment(powerPayload);
            }
            catch (Exception ex)
            {
                //Log Exception
                throw new HttpResponseException(HttpStatusCode.ExpectationFailed, ex.Message);
            }
        }
    }

    
}