using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orders.API.Dtos;
using Oreders.API.Dtos;
using Oreders.API.Models;
namespace Oreders.API.Controllers {
    //  [Authorize]
    [Route ("api/[controller]")]
    [ApiController]

    public class OrdersController : ControllerBase {
        private readonly DataContext _context;

        public OrdersController (DataContext context) {
            _context = context;
        }
        // GET api/Orders
        [HttpGet ("Orders")]
        public async Task<IActionResult> GetOrders ([FromBody] int id) {
            var orders = await (
                from u in _context.Users join order in _context.orders on u.Id equals order.UserId into oru from userorder in oru.DefaultIfEmpty () join orderitem in _context.orderItems on userorder.Id equals orderitem.OrderId into oritem from orditems in oritem.DefaultIfEmpty () join item in _context.Items on orditems.ItemsId equals item.Id into itemoforder from orderitem in itemoforder.DefaultIfEmpty () join unit in _context.Units on orderitem.UnitsId equals unit.Id into unititem from iteunit in unititem.DefaultIfEmpty () where u.Id == id select new {
                    Customer = u.UserName,
                        Date = userorder.Date,
                        TotalAmount = userorder.TotalAmount,
                        orderId = userorder.Id,
                        Item = orderitem.ItemName,
                        Unit = iteunit.unitName,
                        Amount = orditems.Amount

                }).ToListAsync ();
            return Ok (orders);
        }
        [HttpGet("OrderDetails/{id}")]
        public async Task<IActionResult> orderDetails(int id)
        {
            var orderDetails = await (
            from order in _context.orders
            join orderitem in _context.orderItems on order.Id equals orderitem.OrderId into oritem
            from orditems in oritem.DefaultIfEmpty()
            join item in _context.Items on orditems.ItemsId equals item.Id into itemoforder
            from orderitem in itemoforder.DefaultIfEmpty()
            join unit in _context.Units on orderitem.UnitsId equals unit.Id into unititem
            from iteunit in unititem.DefaultIfEmpty()
            where order.Id == id
            select new
            {
                Item = orderitem.ItemName,
                Unit = iteunit.unitName,
                Amount = orditems.Amount

            }).ToListAsync();
            return Ok(orderDetails);
        }
        [HttpGet ("units")]
        public async Task<IActionResult> units () {
            var units = await (
                from Units in _context.Units select new {
                    unitid = Units.Id,
                        UnitName = Units.unitName
                }).ToListAsync ();
            return Ok (units);
        }

        [HttpGet ("item")]
        public async Task<IActionResult> Items () {
            var items = await (
                from item in _context.Items select new {
                    itemid = item.Id,
                        itemName = item.ItemName
                }).ToListAsync ();
            return Ok (items);
        }

        [HttpPost ("InsertOrder")]
        public async Task<IActionResult> insertOrder ( [FromBody] OrderItemsDto orderitemsdto) {
            Console.WriteLine("insertorder");
          //  if (!ModelState.IsValid) {
          //      return BadRequest (ModelState);
          //  }
          //  var orders = new Order {
          //      Date = DateTime.Now,
          //      UserId = orderItemsDto.itemid
          //  };
          //  await _context.orders.AddAsync (orders);
          //  await _context.SaveChangesAsync ();

          //  var orderid = await (from Order in _context.orders select new {
          //      orderid = Order.Id
          //  }).LastOrDefaultAsync ();

          //// insertOrderItems ();
          //  var itemtotalitem = await (from Orderitem in _context.orderItems where Orderitem.ItemsId == orderid.orderid select new {
          //      itId = Orderitem.ItemsId
          //  }).CountAsync ();

          //  _context.SaveChanges ();

            return StatusCode (200);

        }

        public void insertOrderItems (List<ItemDto> orderitemslsit) {
            foreach (var ordertem in orderitemslsit) {
                var orderitemtable = new OrderItems ();
                orderitemtable.ItemsId = ordertem.itemId;
                orderitemtable.OrderId = ordertem.orderId;
                orderitemtable.Amount = ordertem.Amount;
                _context.orderItems.Add (orderitemtable);
                _context.SaveChanges ();
                orderitemtable = null;
            }

        }

        // [HttpPost ("insertOrderdetail")]
        // public async Task<IActionResult> insertOrderdetail (OrdersDto ordersDto) {
        //     if (!ModelState.IsValid) {
        //         return BadRequest (ModelState);
        //     }
        //     var orders = new Order {
        //         Date = DateTime.Now,
        //         UserId = ordersDto.UserId
        //     };
        //     await _context.orders.AddAsync (orders);
        //     await _context.SaveChangesAsync ();

        //     // var orderid = await (from Order in _context.orders select new {
        //     //     orderid = Order.Id
        //     // }).LastOrDefaultAsync ();
        //     var orderitems = new OrderItems {
        //         ItemsId = ordersDto.itemId,
        //         Amount = ordersDto.Amount,
        //         OrderId = orderid.orderid

        //     };
        //     await _context.orderItems.AddAsync (orderitems);
        //     await _context.SaveChangesAsync ();

        //     var itemtotalitem = await (from Orderitem in _context.orderItems where Orderitem.ItemsId == orderid.orderid select new {
        //         itId = Orderitem.ItemsId
        //     }).CountAsync ();

        //     var addTotalAmount = (from Order in _context.orders where Order.Id == orderid.orderid select Order).ToList ();
        //     foreach (var addto in addTotalAmount) {
        //         addto.TotalAmount = itemtotalitem;
        //     }
        //     _context.SaveChanges ();

        //     return StatusCode (200);

        // }

        // PUT api/Orders/5
        // [HttpPost ("Update")]

        // public void UpdateOrder (OrdersDto orddto) {
        //     var getorder = _context.orders.Find (orddto.orderId);
        //     var getorderitem = _context.orderItems.Find (orddto.itemId);
        //     getorder.Date = orddto.Date;
        //     getorder.UserId = orddto.UserId;
        //     getorder.TotalAmount = orddto.TotalAmount;
        //     getorderitem.ItemsId = orddto.itemId;
        //     getorderitem.OrderId = orddto.orderId;
        //     getorderitem.Amount = orddto.Amount;

        //     _context.SaveChanges ();
        // }

        // DELETE api/Orders/5
        [HttpDelete ("Delete/{id}")]
        public void Delete (int id) {
            var deorder = _context.orders.Find (id);
            var deorderitem = _context.orderItems.Find (id);

            _context.orders.Remove (deorder);
            _context.orderItems.Remove (deorderitem);
            _context.SaveChanges ();
        }
    }

}