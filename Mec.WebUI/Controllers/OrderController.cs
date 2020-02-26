using Mec.WebUI.Entity;
using Mec.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mec.WebUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class OrderController : Controller
    {
        DataContext db = new DataContext();
        // GET: Order
        public ActionResult Index()
        {
            var orders = db.Orders.Select(x => new AdminOrderModel()
            {
                Id=x.Id,
                OrderNumber=x.OrderNumber,
                Total=x.Total,
                OrderDate=x.OrderDate,
                OrderState=x.OrderState,
                Count=x.OrderLines.Count
            }).OrderByDescending(x=>x.OrderDate).ToList();
            return View(orders);
        }
        public ActionResult Details(int id)
        {
            var entity = db.Orders.Where(x => x.Id == id)
                                    .Select(x => new OrderDetailsModel()
                                    {
                                        OrderId = x.Id,
                                        Username=x.Username,
                                        OrderNumber = x.OrderNumber,
                                        Total = x.Total,
                                        OrderDate = x.OrderDate,
                                        OrderState = x.OrderState,
                                        AdresBasligi = x.AdresBasligi,
                                        Adres = x.Adres,
                                        Sehir = x.Sehir,
                                        Ilce = x.Ilce,
                                        Mahalle = x.Mahalle,
                                        PostaKodu = x.PostaKodu,
                                        OrderLines = x.OrderLines.Select(i => new OrderLineModel()
                                        {
                                            ProductId = i.ProductId,
                                            ProductName = i.Product.Name.Length > 50 ? i.Product.Name.Substring(0, 47) + "..." : i.Product.Name,
                                            Image = i.Product.Image,
                                            Quantity = i.Quantity,
                                            Price = i.Price

                                        }).ToList()
                                    }).FirstOrDefault();
            return View(entity);
            
        }
        public ActionResult UpdateOrderState(int OrderId,EnumOrderState orderState)
        {
            var order = db.Orders.FirstOrDefault(x => x.Id == OrderId);
            if (order!=null)
            {
                order.OrderState = orderState;
                db.SaveChanges();

                TempData["message"] = "Bilgileriniz Kayıt Edildi.";

                return RedirectToAction("Details", new { id = OrderId });
            }
            return RedirectToAction("Index");
        }
    }
}