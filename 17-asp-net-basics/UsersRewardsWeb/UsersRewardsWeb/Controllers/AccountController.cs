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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            // ============================================================
            // 1. ПРОВЕРКА КАПЧИ
            // ============================================================
            if (!_accountBL.IsCaptchaValid(model.CaptchaAnswer, model.CaptchaResult))
            {
                ModelState.AddModelError("CaptchaAnswer", "Неверный ответ капчи");

            
                var (expression, result) = _accountBL.GenerateCaptcha();
                model.CaptchaExpression = expression;
                model.CaptchaResult = result;
                model.CaptchaAnswer = string.Empty;

                return View(model);
            }

            // ============================================================
            // 2. ПРОВЕРКА MODELSTATE (пароль, подтверждение и т.д.)
            // ============================================================
            if (!ModelState.IsValid)
            {
 
                var (expression, result) = _accountBL.GenerateCaptcha();
                model.CaptchaExpression = expression;
                model.CaptchaResult = result;
                model.CaptchaAnswer = string.Empty;

                return View(model);
            }

            // ============================================================
            // 3. ПРОВЕРКА УНИКАЛЬНОСТИ ИМЕНИ
            // ============================================================
            if (await _accountBL.IsUsernameExistsAsync(model.Username))
            {
                ModelState.AddModelError("Username", "Пользователь с таким именем уже существует");


                var (expression, result) = _accountBL.GenerateCaptcha();
                model.CaptchaExpression = expression;
                model.CaptchaResult = result;
                model.CaptchaAnswer = string.Empty;

                return View(model);
            }

            // ============================================================
            // 4. ПРОВЕРКА УНИКАЛЬНОСТИ EMAIL
            // ============================================================
            if (await _accountBL.IsEmailExistsAsync(model.Email))
            {
                ModelState.AddModelError("Email", "Пользователь с таким email уже зарегистрирован");

          
                var (expression, result) = _accountBL.GenerateCaptcha();
                model.CaptchaExpression = expression;
                model.CaptchaResult = result;
                model.CaptchaAnswer = string.Empty;

                return View(model);
            }

            // ============================================================
            // 5. РЕГИСТРАЦИЯ
            // ============================================================
            try
            {
                await _accountBL.RegisterAsync(model.Username, model.Email, model.Password);

                TempData["SuccessMessage"] = "Регистрация успешна! Войдите в систему.";
                return RedirectToAction("Login");
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("", ex.Message);

              
                var (expression, result) = _accountBL.GenerateCaptcha();
                model.CaptchaExpression = expression;
                model.CaptchaResult = result;
                model.CaptchaAnswer = string.Empty;

                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Ошибка: {ex.Message}");
                if (ex.InnerException != null)
                {
                    ModelState.AddModelError("", $"Внутренняя ошибка: {ex.InnerException.Message}");
                }

              
                var (expression, result) = _accountBL.GenerateCaptcha();
                model.CaptchaExpression = expression;
                model.CaptchaResult = result;
                model.CaptchaAnswer = string.Empty;

                return View(model);
            }
        }

        // ==================== LOGIN (GET) ====================
        [HttpGet]
        public IActionResult Login()
        {
            if (_httpContextAccessor.HttpContext.Session.GetString("UserId") != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // ==================== LOGIN (POST) ====================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try
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
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Ошибка при входе: {ex.Message}");
                return View(model);
            }
        }

        // ==================== LOGOUT ====================
        [HttpGet]
        public IActionResult Logout()
        {
            _httpContextAccessor.HttpContext.Session.Clear();
            Response.Cookies.Delete("Username");
            return RedirectToAction("Login");
        }

        // ==================== ОБНОВЛЕНИЕ КАПЧИ (AJAX) ====================
        [HttpGet]
        public IActionResult RefreshCaptcha()
        {
            var (expression, result) = _accountBL.GenerateCaptcha();
            return Json(new { expression, result });
        }
    }
}