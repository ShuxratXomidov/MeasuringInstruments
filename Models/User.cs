using System.ComponentModel.DataAnnotations;

public class User
{
    public int Id { get; set; }

    [Required]
    [MaxLength(15)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(15)]
    public string LastName { get; set; }

    [Required]
    [DataType(DataType.PhoneNumber, ErrorMessage ="Siz telifon raqamingizni kiritmadingiz")]
    public string PhoneNumber { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required]
    [MaxLength(15)]
    public string Login { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [MaxLength(10)]
    [Range(5, 10, ErrorMessage ="Siz kiritgan parol 5 ta simvoldan 10 ta simvol oralig'ida bo'lishi kerak!")]
    public string Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [MaxLength(10)]
    [Range(5, 10, ErrorMessage ="Siz kiritgan parol 5 ta simvoldan 10 ta simvol oralig'ida bo'lishi kerak!")]
    [Compare("Password", ErrorMessage ="Parolingiz to'g'ri kelmadi...")]
    public string PasswordConfirm { get; set; }
}