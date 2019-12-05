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
    public class DeleteEmpRequestModel : IRequest<DeleteEmpResponseModelResult>
    {
        [Key]
        public int? EmpId { get; set; }

    }
    public class DeleteEmpResponseModelResult
    {
        public bool success { get; set; }
    }
    internal class DeleteEmployeeHandler : IRequestHandler<DeleteEmpRequestModel, DeleteEmpResponseModelResult>
    {
        private readonly IEmpDataAccessLayer _empDataAccessLayer;
        public DeleteEmployeeHandler(IEmpDataAccessLayer empDataAccessLayer)
        {
            _empDataAccessLayer = empDataAccessLayer;
        }
        public async Task<DeleteEmpResponseModelResult> Handle(DeleteEmpRequestModel request, CancellationToken cancellationToken)
        {
            _empDataAccessLayer.Delete(request.EmpId);
            return new DeleteEmpResponseModelResult { success = true };
        }
    }
}
