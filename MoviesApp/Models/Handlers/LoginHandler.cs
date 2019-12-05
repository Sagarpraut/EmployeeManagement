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
    public class LoginRequestModel : IRequest<LoginResponseModelResult>
    {
        [Display(Name = "EmailId")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email ID required")]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Minimum 6 characters required")]
        public string Pass { get; set; }
    }
    public class LoginResponseModelResult
    {
        public bool Success { get; set; }
    }
    internal class LoginHandler : IRequestHandler<LoginRequestModel, LoginResponseModelResult>
    {
        private readonly IUserDataAccessLayer _userDataAccessLayer;
        private readonly IMapper _mapper;
        public LoginHandler(IUserDataAccessLayer userDataAccessLayer,IMapper mapper)
        {
            _userDataAccessLayer = userDataAccessLayer;
            _mapper = mapper;
        }
        public async Task<LoginResponseModelResult> Handle(LoginRequestModel request, CancellationToken cancellationToken)
        {
            bool success = _userDataAccessLayer.CheckLogin(_mapper.Map<Registration>(request));
            return new LoginResponseModelResult() { Success = success};
        }
    }
}
