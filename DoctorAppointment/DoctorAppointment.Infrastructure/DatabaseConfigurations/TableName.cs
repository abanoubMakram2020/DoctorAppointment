using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Infrastructure.DatabaseConfigurations
{
    internal class TableName
    {
        public static string CandidateCourses => nameof(CandidateCourses);
        public static string CommitteeApproval => nameof(CommitteeApproval);
        public static string DeptHead_FacultyMemTeachingLoad => nameof(DeptHead_FacultyMemTeachingLoad);
        public static string DeptHeadApproval => nameof(DeptHeadApproval);
        public static string FacultyDeanApproval => nameof(FacultyDeanApproval);
        public static string FacultyMemActivity => nameof(FacultyMemActivity);
        public static string FacultyMemBooks => nameof(FacultyMemBooks);
        public static string FacultyMemCommittees => nameof(FacultyMemCommittees);
        public static string FacultyMemConferences => nameof(FacultyMemConferences);
        public static string FacultyMemCourses => nameof(FacultyMemCourses);
        public static string FacultyMemJournals => nameof(FacultyMemJournals);
        public static string FacultyMemPositions => nameof(FacultyMemPositions);
        public static string FacultyMemProjects => nameof(FacultyMemProjects);
        public static string FacultyMemSupervision => nameof(FacultyMemSupervision);
        public static string FacultyMemTeachingLoad => nameof(FacultyMemTeachingLoad);
        public static string FacultyRepresentativeApproval => nameof(FacultyRepresentativeApproval);
        public static string HeadDeptCandidateCourses => nameof(HeadDeptCandidateCourses);
        public static string OutsourcingRequest => nameof(OutsourcingRequest);
    }
}
