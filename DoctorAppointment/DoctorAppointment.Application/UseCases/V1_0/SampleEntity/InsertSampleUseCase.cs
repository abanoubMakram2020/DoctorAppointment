using DoctorAppointment.Application.DTOs.OutputDTOs;
using DoctorAppointment.Application.Interfases.UseCases.V1_0;
using DoctorAppointment.Domain.Data.Entities;
using DoctorAppointment.Domain.Interfases.Repositories.Entity;
using SharedKernal.Middlewares.Basees;

/// <summary>
/// 
/// </summary>
namespace DoctorAppointment.Application.UseCases.V1_0
{
    /// <summary>
    /// 
    /// </summary>
    public class InsertSampleUseCase : BaseUseCase, IInsertSampleUseCase
    {

        public ISampleRepository SampleRepository { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseResultDto<IEnumerable<IdNameOutputDTO<string, string>>>> Handle()
        {
            return ResponseResultDto<IEnumerable<IdNameOutputDTO<string, string>>>.Success(result: null, message: "Version 1");
        }
    }
}
