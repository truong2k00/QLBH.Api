using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.Api.Extensions;
using QLBH.Business;
using QLBH.Business.CMS;
using QLBH.Models;
using static QLBH.Commons.Common_Constants;

namespace QLBH.Api.Controllers
{
    [Route(AppSettingKeys.DEFAULT_CONTROLER_RAUTER)]
    [ApiController]
    public class BillsController : ControllerBase
    {
        private readonly IBillServices _billServices;
        private readonly IInvoiceDetailsServices _invoiceServices;

        public BillsController(IBillServices billServices, IInvoiceDetailsServices invoiceServices)
        {
            _billServices = billServices;
            _invoiceServices = invoiceServices;
        }
        #region GetBill
        [HttpGet("GetBill")]
        public IActionResult GetBillAsync()
        {
            return Ok(_billServices.GetBillAsync());
        }


        [HttpGet("GetBillDelete")]
        [Authorize(RoleKeyString.Admin, RoleKeyString.Manager)]
        public IActionResult GetBill([FromQuery] bool IsDelete = false)
        {
            return Ok(_billServices.GetBillAsync(0, IsDelete));
        }


        [HttpGet("GetBillDelete/{accountId}")]
        [Authorize(RoleKeyString.Admin, RoleKeyString.Manager)]
        public IActionResult GetBill(long accountId, [FromQuery] bool IsDelete = false)
        {
            return Ok(_billServices.GetBillAsync(accountId, IsDelete));
        }


        [HttpGet("GetBillAccount")]
        [Authorize(RoleKeyString.User)]
        public IActionResult GetBillAccount()
        {
            return Ok(_billServices.GetBillAsync(long.Parse(HttpContext.User.FindFirst(Clames.ID).Value)));
        }


        [HttpGet("GetBill/{id}")]
        public async Task<IActionResult> GetByID(long id)
        {
            return Ok(await _billServices.GetByIDAsync(id));
        }
        #endregion


        [HttpPost("Create")]
        [Authorize(RoleKeyString.User, RoleKeyString.Guest, RoleKeyString.Superuser, RoleKeyString.Guest)]
        public async Task Create([FromQuery] DataRequest_Bill data)
        {
            data.accountID = long.Parse(HttpContext.User.FindFirst(Clames.ID).Value);
            await _billServices.Create(data);
        }


        [HttpPut("Update/{id}")]
        public async Task Update(long id)
        {
            await _billServices.Update(id);
        }


        [HttpDelete("Delete/{id}")]
        public async Task Delete(long id)
        {
            await _billServices.Delete(id);
        }


        [HttpDelete("InvoiceDelete/{invoiceId}")]
        public async Task DeleteInvoice(long invoiceId)
        {
            await _billServices.DeleteInvoice(invoiceId);
        }


        //Invoice Bill
        [HttpPut("InvoiceUpdate/{id}")]
        [Authorize]
        public async Task Update(long id, [FromQuery] DataRequest_InvoidDetails dataRequest_)
        {
            await _invoiceServices.Update(long.Parse(HttpContext.User.FindFirst(Clames.ID).Value), id, dataRequest_);
        }


        [HttpPut("Admin/InvoiceUpdate/{id}")]
        [Authorize(RoleKeyString.Admin, RoleKeyString.Manager)]
        public async Task UpdateAsync(long id, [FromQuery] DataRequest_InvoidDetails dataRequest_)
        {
            await _invoiceServices.Update(0, id, dataRequest_);
        }
    }
}
