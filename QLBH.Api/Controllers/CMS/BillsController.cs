using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.Api.Extensions;
using QLBH.Business;
using QLBH.Business.CMS;
using QLBH.Models;
using static QLBH.Commons.Common_Constants;

namespace QLBH.Api.Controllers
{
    [Route(DEFAULT_CONTROLER_RAUTER)]
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
        [HttpGet()]
        public IActionResult GetAllBill()
        {
            return Ok(_billServices.GetBillAsync());
        }


        [HttpGet()]
        [Authorize(RoleKeyString.Admin, RoleKeyString.Manager)]
        public IActionResult GetBill([FromQuery] bool IsDelete = false)
        {
            return Ok(_billServices.GetBillAsync(0, IsDelete));
        }


        [HttpGet("{accountId}")]
        [Authorize(RoleKeyString.Admin, RoleKeyString.Manager)]
        public IActionResult GetBill(long accountId, [FromQuery] bool IsDelete = false)
        {
            return Ok(_billServices.GetBillAsync(accountId, IsDelete));
        }


        [HttpGet()]
        [Authorize(RoleKeyString.User)]
        public IActionResult GetBillAccount()
        {
            return Ok(_billServices.GetBillAsync(long.Parse(HttpContext.User.FindFirst(Clames.ID).Value)));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(long id)
        {
            return Ok(await _billServices.GetByIDAsync(id));
        }
        #endregion


        [HttpPost()]
        [Authorize(RoleKeyString.User, RoleKeyString.Guest, RoleKeyString.Superuser, RoleKeyString.Guest)]
        public async Task<IActionResult> Create([FromQuery] DataRequest_Bill data)
        {
            data.accountID = long.Parse(HttpContext.User.FindFirst(Clames.ID).Value);
            await _billServices.Create(data);
            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id)
        {
            await _billServices.Update(id);
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _billServices.Delete(id);
            return Ok();
        }


        [HttpDelete("{invoiceId}")]
        public async Task<IActionResult> DeleteInvoice(long invoiceId)
        {
            await _billServices.DeleteInvoice(invoiceId);
            return Ok();
        }


        //Invoice Bill
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateInvoice(long id, [FromQuery] DataRequest_InvoiceDetails dataRequest_)
        {
            await _invoiceServices.Update(long.Parse(HttpContext.User.FindFirst(Clames.ID).Value), id, dataRequest_);
            return Ok();
        }


        [HttpPut("{id}")]
        [Authorize(RoleKeyString.Admin, RoleKeyString.Manager)]
        public async Task<IActionResult> UpdateInvoce(long id, [FromQuery] DataRequest_InvoiceDetails dataRequest_)
        {
            await _invoiceServices.Update(0, id, dataRequest_);
            return Ok();
        }
    }
}
