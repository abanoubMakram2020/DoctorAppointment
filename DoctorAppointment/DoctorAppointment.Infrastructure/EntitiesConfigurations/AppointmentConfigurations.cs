using DoctorAppointment.Domain.Data.Entities;
using DoctorAppointment.Infrastructure.DatabaseConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorAppointment.Infrastructure.EntitiesConfigurations
{
    internal class AppointmentConfigurations : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable(name: TableName.Appointment, schema: Schema._public);
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd().HasColumnType(ColumnType.Int).IsRequired();
            builder.Property(p => p.PatientName).HasColumnType(ColumnType.Nvarchar64).IsRequired();
            builder.Property(p => p.PatientPhoneNumber).HasColumnType(ColumnType.Nvarchar16).IsRequired();
            builder.Property(p => p.Notes).HasColumnType(ColumnType.Nvarchar1024).IsRequired();
            builder.Property(p => p.AppointmentDate).HasColumnType(ColumnType.DateTime).IsRequired();
            builder.Property(p => p.AppointmentTimeFrom).HasColumnType(ColumnType.Time).IsRequired();
            builder.Property(p => p.AppointmentTimeTo).HasColumnType(ColumnType.Time).IsRequired();
            builder.Property(p => p.DateCreated).HasColumnType(ColumnType.DateTime).IsRequired();

        }
    }
}
