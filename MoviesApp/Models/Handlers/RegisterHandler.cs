using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class RegisterRequestModel : IRequest<RegisterResponseModelResult>
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name required")]
        public string LastName { get; set; }


        [Display(Name = "EmailId")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email ID required")]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Minimum 6 characters required")]
        public string Pass { get; set; }
    }
    public class RegisterResponseModelResult
    {
    }
    internal class RegisterHandler : IRequestHandler<RegisterRequestModel, RegisterResponseModelResult>
    {
        private readonly IUserDataAccessLayer _userDataAccessLayer;
        private readonly IMapper _mapper;
        public RegisterHandler(IUserDataAccessLayer userDataAccessLayer,IMapper mapper)
        {
            _userDataAccessLayer = userDataAccessLayer;
            _mapper = mapper;
        }
        public async Task<RegisterResponseModelResult> Handle(RegisterRequestModel request, CancellationToken cancellationToken)
        {
            _userDataAccessLayer.AddUser(_mapper.Map<Registration>(request));
            return new RegisterResponseModelResult();
        }
    }
}
