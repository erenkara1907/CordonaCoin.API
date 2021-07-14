using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet("getall")]
        [Authorize]
        public IActionResult GetList()
        {
            var result = _dashboardService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getlistbyuser")]
        [Authorize]
        public IActionResult GetListByUser(int userId)
        {
            var result = _dashboardService.GetListByUser(userId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        [Authorize]
        public IActionResult GetById(int dashboardId)
        {
            var result = _dashboardService.GetById(dashboardId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getbyuser")]
        [Authorize]
        public IActionResult GetByUser(int userId)
        {
            var result = _dashboardService.GetByUser(userId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        [Authorize]
        public IActionResult Add(Dashboard dashboard)
        {
            var result = _dashboardService.Add(dashboard);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        [Authorize]
        public IActionResult Update(Dashboard dashboard)
        {
            var result = _dashboardService.Update(dashboard);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        [Authorize]
        public IActionResult Delete(Dashboard dashboard)
        {
            var result = _dashboardService.Delete(dashboard);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("transaction")]
        [Authorize]
        public IActionResult TransactionTest(Dashboard dashboard)
        {
            var result = _dashboardService.TransactionalOperation(dashboard);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}
