using Mec.WebUI.Entity;
using Mec.WebUI.Identity;
using Mec.WebUI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mec.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private DataContext db = new DataContext();
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            _userManager = new UserManager<ApplicationUser>(userStore);
            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            _roleManager = new RoleManager<ApplicationRole>(roleStore);
        }
        [Authorize]
        public ActionResult Index()
        {
            var username = User.Identity.Name;
            var orders = db.Orders
                .Where(x => x.Username == username)
                .Select(x=>new UserOrderModel()
                { 
                    Id=x.Id,
                    OrderNumber=x.OrderNumber,
                    OrderDate=x.OrderDate,
                    Total=x.Total,
                    OrderState=x.OrderState
                
                }).OrderByDescending(x=>x.OrderDate).ToList();

            return View(orders);
        }
        [Authorize]
        public ActionResult Details(int id)
        {
            var entity = db.Orders.Where(x => x.Id == id)
                                    .Select(x => new OrderDetailsModel()
                                    {
                                        OrderId = x.Id,
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
                                            ProductId=i.ProductId,
                                            ProductName=i.Product.Name.Length>50? i.Product.Name.Substring(0,47)+"...": i.Product.Name,
                                            Image=i.Product.Image,
                                            Quantity=i.Quantity,
                                            Price=i.Price

                                        }).ToList()
                                    }).FirstOrDefault();
            return View(entity);
        }
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                //Kayıt İşlemleri

                var user = new ApplicationUser();
                user.Name = model.Name;
                user.UserName = model.Username;
                user.Email = model.Email;
                user.Surname = model.Surname;

                IdentityResult result= _userManager.Create(user, model.Password);

                if (result.Succeeded)
                {
                    //Kullanıcı oluşur ve rol atanır.
                    if (_roleManager.RoleExists("user"))
                    {
                        _userManager.AddToRole(user.Id, "user");
                    }
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("RegisterUserError", "Kullanıcı oluşturulamadı.");
                }
            }
            return View(model);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model,string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                //Giriş İşlemleri
                var user=_userManager.Find(model.Username, model.Password);
                if (user!=null)
                {
                    //Daha önce oluşturulan kullanıcıyı sisteme dail et.
                    //ApplicationCookie bırakarak belli bir süre login şekilde kalmasını sağla.

                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var IdentityClaims = _userManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.RememberMe;
                    authManager.SignIn(authProperties,IdentityClaims);
                    if (!String.IsNullOrEmpty(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "Kullanıcı bulunamadı.");
                }
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Index","Home");
        }
    }
}