using System.ComponentModel.DataAnnotations;

namespace Int.MobileUI.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "请输入账号。")]
        public string LoginName { get; set; }
        [Required(ErrorMessage = "请输入密码。")]
        public string Password { get; set; }
        [Required(ErrorMessage = "请输入密码确认。")]
        [Compare("Password", ErrorMessage = "密码输入不一致。")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "请输入员工姓名。")]
        public string Name { get; set; }
    }
    public class LoginModel
    {
        [Required(ErrorMessage = "请输入账号。")]
        public string LoginName { get; set; }
        [Required(ErrorMessage = "请输入密码。")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
