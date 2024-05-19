﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SUT23_Projekt___Avancerad_.NET.Services;

namespace SUT23_Projekt___Avancerad_.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChangeLogController : ControllerBase
    {
        private readonly IChangeLogRepository _changeLogRepository;

        public ChangeLogController(IChangeLogRepository changeLogRepository)
        {
            _changeLogRepository = changeLogRepository;
        }

        [HttpGet("Changelog")]
        [Authorize(Policy = "CompanyPolicy")]
        public async Task<IActionResult> GetChangelog()
        {
            try
            {
                return Ok(await _changeLogRepository.ChangeLogHistory());
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
