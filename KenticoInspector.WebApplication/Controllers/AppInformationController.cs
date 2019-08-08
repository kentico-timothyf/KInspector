using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using KenticoInspector.Core;
using KenticoInspector.Core.Helpers;
using System.Reflection;
using System.Diagnostics;
using Newtonsoft.Json;
using KenticoInspector.Core.Models;

namespace KenticoInspector.WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppInformationController : ControllerBase
    {
        // GET api/values
        [HttpGet("semversion")]
        public ActionResult<SemVer> Get()
        {
            var applicationVersion = ApplicationInformationHelper.GetSemVersion();

            return applicationVersion;
        }

        // GET api/values
        [HttpGet("stringversion")]
        public ActionResult<string> Get()
        {
            var applicationVersion = ApplicationInformationHelper.GetStringVersion();

            return applicationVersion;
        }
    }
}