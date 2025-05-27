using System.ComponentModel.DataAnnotations;
public class UserModel
{
    [Display(Name = "Email Adresi")]
    [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
    [StringLength(100, ErrorMessage = "E-posta adresi en fazla 100 karakter olabilir.")]
    [MinLength(5, ErrorMessage = "E-posta adresi en az 5 karakter olmalıdır.")]
    [Required(ErrorMessage = "Email gereklidir")]
    public string Email { get; set; }

    [MaxLength(8, ErrorMessage = "Kullanıcı adı en fazla 8 karakter olabilir.")]
    [MinLength(6, ErrorMessage = "Kullanıcı adı en az 2 karakter olmalıdır.")]
    [Required(ErrorMessage = "Şifre alanı boş bırakılamaz.")]
    [Display(Name = "Şifre")]
    public string Password { get; set; }

    [Display(Name = "Şifre Tekrarı")]
    [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
    [Required(ErrorMessage = "Şifre onayı alanı boş bırakılamaz.")]
    public string PasswordConfirm { get; set; }

}