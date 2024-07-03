using Microsoft.AspNetCore.Mvc;
using LogAnalyzer;
using System;
using System.Collections.Generic;

namespace LogAnalyzerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogAnalyzerController : ControllerBase
    {
        private readonly LogAnalyzer _logAnalyzer;

        public LogAnalyzerController()
        {
            _logAnalyzer = new LogAnalyzer();
        }

        [HttpGet("search")]
        public IActionResult SearchLogs([FromQuery] string[] directories, [FromQuery] string searchPattern)
        {
            _logAnalyzer.SearchLogs(directories, searchPattern);
            return Ok("Logs searched successfully.");
        }

        [HttpGet("count-unique-errors")]
        public IActionResult CountUniqueErrors([FromQuery] string[] directories, [FromQuery] string searchPattern)
        {
            _logAnalyzer.CountUniqueErrors(directories, searchPattern);
            return Ok("Unique errors counted successfully.");
        }

        [HttpGet("count-duplicated-errors")]
        public IActionResult CountDuplicatedErrors([FromQuery] string[] directories, [FromQuery] string searchPattern)
        {
            _logAnalyzer.CountDuplicatedErrors(directories, searchPattern);
            return Ok("Duplicated errors counted successfully.");
        }

        [HttpPost("archive-logs")]
        public IActionResult ArchiveLogs([FromQuery] string[] directories, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            _logAnalyzer.ArchiveLogs(directories, startDate, endDate);
            return Ok("Logs archived successfully.");
        }

       
    }
}
