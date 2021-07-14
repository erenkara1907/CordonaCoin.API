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
    public class TransactionController : ControllerBase
    {
        private ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("getall")]
        [Authorize]
        public IActionResult GetList()
        {
            var result = _transactionService.GetList();
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
            var result = _transactionService.GetListByUser(userId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        [Authorize]
        public IActionResult GetById(int transactionId)
        {
            var result = _transactionService.GetById(transactionId);
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
            var result = _transactionService.GetByUser(userId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        [Authorize]
        public IActionResult Add(Transaction transactionn)
        {
            var result = _transactionService.Add(transactionn);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        [Authorize]
        public IActionResult Update(Transaction transactionn)
        {
            var result = _transactionService.Update(transactionn);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        [Authorize]
        public IActionResult Delete(Transaction transactionn)
        {
            var result = _transactionService.Delete(transactionn);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("transaction")]
        [Authorize]
        public IActionResult TransactionTest(Transaction transactionn)
        {
            var result = _transactionService.TransactionalOperation(transactionn);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}
