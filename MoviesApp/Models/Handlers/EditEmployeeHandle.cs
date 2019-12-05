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
    public class EditEmpRequestModel : IRequest<EditEmpResponseModelResult>
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
    public class EditEmpResponseModelResult
    {
        public bool Success { get; set; }
    }
    internal class EditEmployeeHandler : IRequestHandler<EditEmpRequestModel, EditEmpResponseModelResult>
    {
        private readonly IEmpDataAccessLayer _empDataAccessLayer;
        private readonly IMapper _mapper;
        public EditEmployeeHandler(IEmpDataAccessLayer empDataAccessLayer, IMapper mapper)
        {
            _empDataAccessLayer = empDataAccessLayer;
            _mapper = mapper;
        }
        public async Task<EditEmpResponseModelResult> Handle(EditEmpRequestModel request, CancellationToken cancellationToken)
        {
            _empDataAccessLayer.UpdateEmployee(_mapper.Map<Employee>(request));
            return new EditEmpResponseModelResult() { Success = true };
        }
    }
}
