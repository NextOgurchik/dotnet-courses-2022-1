using System.ComponentModel.DataAnnotations;

namespace UsersRewardsWeb.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Имя пользователя обязательно")]
        [RegularExpression(@"^[a-zA-Z0-9]{3,20}$",
            ErrorMessage = "Только латиница и цифры, от 3 до 20 символов")]
        [Display(Name = "Имя пользователя")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email обязателен")]
        [EmailAddress(ErrorMessage = "Введите корректный email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Пароль обязателен")]
        [MinLength(6, ErrorMessage = "Минимум 6 символов")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d).+$",
            ErrorMessage = "Пароль должен содержать буквы и цифры")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Подтвердите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Решите капчу")]
        [Display(Name = "Капча")]
        public string CaptchaAnswer { get; set; }

        // ЭТИ ПОЛЯ МЫ БУДЕМ ПЕРЕДАВАТЬ ЯВНО, А НЕ ЧЕРЕЗ asp-for
        public string CaptchaExpression { get; set; }
        public int CaptchaResult { get; set; }
    }
}