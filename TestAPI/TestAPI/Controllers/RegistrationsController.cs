using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    [Route("/v1/registration")]
    [ApiController]
    public class RegistrationsController : ControllerBase
    {

        private readonly ILogger<RegistrationsController> _logger;
        public RegistrationsController(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<RegistrationsController>();
        }

        [HttpPost]
        [Route("step-1")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]

        public async Task<IActionResult> Register([FromBody] RegistrationStep1RequestDto registrationStep1RequestDto)
        {
            try
            {
                _logger.LogInformation($"Start call api register step 1 with [Email = {registrationStep1RequestDto.Email}, Screen name = {registrationStep1RequestDto.ScreenName}].....");
                //var response = await _registrationService.SetStep1Async(registrationStep1RequestDto);
                _logger.LogInformation($"Create account for [Email = {registrationStep1RequestDto.Email}, Screen name = {registrationStep1RequestDto.ScreenName}] ");
                return Ok();
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex, ex.Message.ToString());
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Fail to register");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
