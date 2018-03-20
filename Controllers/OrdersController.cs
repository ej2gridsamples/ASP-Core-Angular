using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularwithASPCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularwithASPCore.Controllers
{
    [Produces("application/json")]
    [Route("api/Orders")]
    public class OrdersController : Controller
    {
        // GET: api/Orders
        [HttpGet]

        public object Get()
        {

            int skip = Convert.ToInt32(HttpContext.Request.Query["$skip"].ToString());
            int take = Convert.ToInt32(HttpContext.Request.Query["$top"].ToString());
            var data = OrdersDetails.GetAllRecords().ToList();
            return new { Items = data.Skip(skip).Take(take).ToList(), Count = data.Count() };
        }

        // GET: api/Orders/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Orders
        [HttpPost]
        public object Post([FromBody]OrdersDetails value)
        {
            OrdersDetails.GetAllRecords().Insert(0, value);
            return value;
        }

        // PUT: api/Orders/5
        [HttpPut]
        public object Put(int id, [FromBody]OrdersDetails value)
        {


            var ord = value;
            OrdersDetails val = OrdersDetails.GetAllRecords().Where(or => or.OrderID == ord.OrderID).FirstOrDefault();
            val.OrderID = ord.OrderID;
            val.EmployeeID = ord.EmployeeID;
            val.CustomerID = ord.CustomerID;
            val.Freight = ord.Freight;
            val.OrderDate = ord.OrderDate;
            val.ShipCity = ord.ShipCity;
            return value;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id:int}")]
        [Route("Orders/{id:int}")]
        public object Delete(int id)
        {
            OrdersDetails.GetAllRecords().Remove(OrdersDetails.GetAllRecords().Where(or => or.OrderID == id).FirstOrDefault());
            return Json(id);
        }
    }
}
