using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Application.Features.Auth.Login;

public class Request: IRequest<ResultWrapper<Response>>
{
    public Request(Request req)
    {
        Email = req.Email;
        Password = req.Password;
    }
    
    public Request() {}
    
    [Required]
    [EmailAddress(ErrorMessage = "Pleas enter a valid email address")]
    public string Email { get; set; }
    [Required]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "Password should be minimum 8 charaters long.")]
    public string Password { get; set; }
}