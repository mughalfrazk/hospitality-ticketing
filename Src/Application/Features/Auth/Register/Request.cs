using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Application.Features.Auth.Register;

public class Request : IRequest<ResultWrapper<string>>
{
    public Request(Request req)
    {
        FirstName = req.FirstName;
        LastName = req.LastName;
        Email = req.Email;
        Password = req.Password;
        Phone = req.Phone;
    }
    public Request() {}
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Phone { get; set; }
    [Required]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "Password should have a minimum of 8 characters.")]
    public string Password { get; set; }
}