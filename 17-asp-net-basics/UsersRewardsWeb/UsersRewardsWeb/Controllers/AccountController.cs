using BLL;
using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UsersRewardsWeb.Models;

namespace UsersRewardsWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountBL _accountBL;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountController(IAccountBL accountBL, IHttpContextAccessor httpContextAccessor)
        {
            _accountBL = accountBL;
            _httpContextAccessor = httpContextAccessor;
        }

        // ==================== REGISTER (GET) ====================
        [HttpGet]
        public IActionResult Register()
        {
            var model = new RegisterViewModel();
            var (expression, result) = _accountBL.GenerateCaptcha();
            model.CaptchaExpression = expression;
            model.CaptchaResult = result;
            return View(model);
        }

        // ==================== REGISTER (POST) ====================
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            // Проверяем капчу
            if (!_accountBL.IsCaptchaValid(model.CaptchaAnswer, model.CaptchaResult))
            {
                ModelState.AddModelError("CaptchaAnswer", "Неверный ответ капчи");

                // Генерируем НОВУЮ капчу
                var (expression, result) = _accountBL.GenerateCaptcha();
                model.CaptchaExpression = expression;
                model.CaptchaResult = result;
                model.CaptchaAnswer = string.Empty;

                return View(model);
            }

            // Проверяем ModelState
            if (!ModelState.IsValid)
            {
                var (expression, result) = _accountBL.GenerateCaptcha();
                model.CaptchaExpression = expression;
                model.CaptchaResult = result;
                model.CaptchaAnswer = string.Empty;

                return View(model);
            }

            // Проверяем уникальность имени
            if (await _accountBL.IsUsernameExistsAsync(model.Username))
            {
                ModelState.AddModelError("Username", "Пользователь с таким именем уже существует");

                var (expression, result) = _accountBL.GenerateCaptcha();
                model.CaptchaExpression = expression;
                model.CaptchaResult = result;
                model.CaptchaAnswer = string.Empty;

                return View(model);
            }

            // Проверяем уникальность email
            if (await _accountBL.IsEmailExistsAsync(model.Email))
            {
                ModelState.AddModelError("Email", "Пользователь с таким email уже зарегистрирован");

                var (expression, result) = _accountBL.GenerateCaptcha();
                model.CaptchaExpression = expression;
                model.CaptchaResult = result;
                model.CaptchaAnswer = string.Empty;

                return View(model);
            }

            // Регистрируем
            try
            {
                await _accountBL.RegisterAsync(model.Username, model.Email, model.Password);
                TempData["SuccessMessage"] = "Регистрация успешна! Войдите в систему.";
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ошибка регистрации: " + ex.Message);

                var (expression, result) = _accountBL.GenerateCaptcha();
                model.CaptchaExpression = expression;
                model.CaptchaResult = result;
                model.CaptchaAnswer = string.Empty;

                return View(model);
            }
        }

        // ==================== LOGIN ====================
        [HttpGet]
        public IActionResult Login()
        {
            if (_httpContextAccessor.HttpContext.Session.GetString("UserId") != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var account = await _accountBL.LoginAsync(model.Username, model.Password);

            if (account == null)
            {
                ModelState.AddModelError("", "Неверное имя пользователя или пароль");
                return View(model);
            }

            _httpContextAccessor.HttpContext.Session.SetString("UserId", account.Id.ToString());
            _httpContextAccessor.HttpContext.Session.SetString("Username", account.Username);

            if (model.RememberMe)
            {
                Response.Cookies.Append("Username", account.Username, new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(30),
                    HttpOnly = true
                });
            }

            return RedirectToAction("Index", "Home");
        }

        // ==================== LOGOUT ====================
        [HttpGet]
        public IActionResult Logout()
        {
            _httpContextAccessor.HttpContext.Session.Clear();
            Response.Cookies.Delete("Username");
            return RedirectToAction("Login");
        }

        // ==================== ОБНОВЛЕНИЕ КАПЧИ ====================
        [HttpGet]
        public IActionResult RefreshCaptcha()
        {
            var (expression, result) = _accountBL.GenerateCaptcha();
            return Json(new { expression, result });
        }
    }
}