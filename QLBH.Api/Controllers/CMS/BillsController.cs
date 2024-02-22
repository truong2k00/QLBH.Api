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


        [HttpGet("GetBill/{ID}")]
        public async Task<IActionResult> GetByID(long ID)
        {
            return Ok(await _billServices.GetByIDAsync(ID));
        }
        #endregion


        [HttpPost("Create")]
        [Authorize(RoleKeyString.User, RoleKeyString.Guest, RoleKeyString.Superuser, RoleKeyString.Guest)]
        public async Task<IActionResult> Create([FromQuery] DataRequest_Bill data)
        {
            data.accountID = long.Parse(HttpContext.User.FindFirst(Clames.ID).Value);
            return Ok(await _billServices.Create(data));
        }


        [HttpPut("Update/{ID}")]
        public async Task<IActionResult> Update(long ID)
        {
            return Ok(await _billServices.Update(ID));
        }


        [HttpDelete("Delete/{ID}")]
        public async Task<IActionResult> Delete(long ID)
        {
            return Ok(await _billServices.Delete(ID));
        }


        [HttpDelete("InvoiceDelete/{invoiceId}")]
        public async Task<IActionResult> DeleteInvoice(long invoiceId)
        {
            return Ok(await _billServices.DeleteInvoice(invoiceId));
        }


        //Invoice Bill
        [HttpPut("InvoiceUpdate/{ID}")]
        [Authorize]
        public async Task<IActionResult> Update(long ID, [FromQuery] DataRequest_InvoidDetails dataRequest_)
        {
            return Ok(await _invoiceServices.Update(long.Parse(HttpContext.User.FindFirst(Clames.ID).Value), ID, dataRequest_));
        }


        [HttpPut("Admin/InvoiceUpdate/{ID}")]
        [Authorize(RoleKeyString.Admin, RoleKeyString.Manager)]
        public async Task<IActionResult> UpdateAsync(long ID, [FromQuery] DataRequest_InvoidDetails dataRequest_)
        {
            return Ok(await _invoiceServices.Update(0, ID, dataRequest_));
        }
    }
}
