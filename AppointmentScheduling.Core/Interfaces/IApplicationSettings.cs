using System;

namespace AppointmentScheduling.Core.Interfaces
{
    public interface IApplicationSettings
    {
        int CompanyId { get; }
        DateTime TestDate { get; }
    }
}