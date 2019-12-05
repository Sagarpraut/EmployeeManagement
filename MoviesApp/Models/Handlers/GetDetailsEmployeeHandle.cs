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
    public class GetEmpDetailsRequestModel : IRequest<GetEmpDetailsResponseModelResult>
    {
        [Key]
        public int? EmpId { get; set; }

    }
    public class GetEmpDetailsResponseModelResult
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
    internal class GetDetailsEmployeeHandler : IRequestHandler<GetEmpDetailsRequestModel, GetEmpDetailsResponseModelResult>
    {
        private readonly IEmpDataAccessLayer _empDataAccessLayer;
        private readonly IMapper _mapper;
        public GetDetailsEmployeeHandler(IEmpDataAccessLayer empDataAccessLayer, IMapper mapper)
        {
            _empDataAccessLayer = empDataAccessLayer;
            _mapper = mapper;
        }
        public async Task<GetEmpDetailsResponseModelResult> Handle(GetEmpDetailsRequestModel request, CancellationToken cancellationToken)
        {
            var emp = _mapper.Map<GetEmpDetailsResponseModelResult>(_empDataAccessLayer.GetEmployeeData(request.EmpId));
            return emp;
        }
    }
}
