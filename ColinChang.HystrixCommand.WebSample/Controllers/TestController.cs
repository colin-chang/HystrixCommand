﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColinChang.HystrixCommand.Services;
using Microsoft.AspNetCore.Mvc;

namespace ColinChang.HystrixCommand.WebSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestService _person;

        public TestController(ITestService person)
        {
            _person = person;
        }

        // try "api/test" and "api/test/colin"
        [HttpGet("{name?}")]
        public async Task<ActionResult<string>> Get(string name)
        {
            return await _person.RetryTestAsync(name);
        }
    }
}