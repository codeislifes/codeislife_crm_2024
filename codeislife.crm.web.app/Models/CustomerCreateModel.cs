using System.ComponentModel.DataAnnotations;

namespace codeislife.crm.web.app.Models;
public class CustomerCreateModel
{
    [Required(ErrorMessage = "Müşteri ünvan boş geçilemez!")]
    public required string Title { get; set; }

    [Required(ErrorMessage = "Cari kodu boş geçilemez!")]
    [MinLength(3, ErrorMessage = "Cari kodu en az 3 karakter olmalıdır!")]
    [MaxLength(10, ErrorMessage = "Cari kodu 10 karakteri geçemez!")]
    public required string Code { get; set; }
}
