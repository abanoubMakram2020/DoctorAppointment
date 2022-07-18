using DoctorAppointment.Application.DTOs.OutputDTOs;
using SharedKernal.Middlewares.Basees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Application.Interfases.UseCases.V1_0
{
    public interface IInsertSampleUseCase : IBaseUseCase<IEnumerable<IdNameOutputDTO<string, string>>>
    {
    }
}
