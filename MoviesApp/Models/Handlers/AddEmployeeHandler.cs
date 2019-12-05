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
    public class EmployeeRequestModel : IRequest<EmployeeResponseModelResult>
    {

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name required")]
        public string Firstnme { get; set; }

        [Display(Name = "Middle Name")]
        [Required(ErrorMessage = "Middle name required")]
        public string Middle { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name required")]
        public string Lastname { get; set; }

        public string Workdept { get; set; }

        [Phone]
        [Display(Name = "Phone number")]
        [Required(ErrorMessage = "phone Number required")]
        public string Phoneno { get; set; }
        public string Job { get; set; }
        public decimal? Salary { get; set; }
        public int Empno { get; set; }

    }
    public class EmployeeResponseModelResult
    {
        public bool Success { get; set; }
    }
    internal class AddEmployeeHandler : IRequestHandler<EmployeeRequestModel, EmployeeResponseModelResult>
    {
        private readonly IEmpDataAccessLayer _empDataAccessLayer;
        private readonly IMapper _mapper;
        public AddEmployeeHandler(IEmpDataAccessLayer userDataAccessLayer,IMapper mapper)
        {
            _empDataAccessLayer = userDataAccessLayer;
            _mapper = mapper;
        }
        public async Task<EmployeeResponseModelResult> Handle(EmployeeRequestModel request, CancellationToken cancellationToken)
        {
            _empDataAccessLayer.AddEmp(_mapper.Map<Employee>(request));
            return new EmployeeResponseModelResult() { Success = true };
        }
    }
}
