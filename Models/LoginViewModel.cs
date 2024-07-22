using System.ComponentModel.DataAnnotations;

public class LoginViewModel
{
    [Required]
    [Display(Name = "Login")]
    public string Login { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Senha")]
    public string Senha { get; set; }
}
