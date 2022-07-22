

namespace DoctorAppointment.Infrastructure.DatabaseConfigurations
{
    internal struct ColumnType
    {
        public static string Short => "smallint";
        public static string Int => "int";
        public static string Long => "long";
        public static string Nvarchar16 => "character varying(16)";
        public static string Nvarchar64 => "character varying(64)";
        public static string Nvarchar128 => "character varying(128)";
        public static string Nvarchar256 => "character varying(256)";
        public static string Nvarchar512 => "character varying(512)";
        public static string Nvarchar1024 => "character varying(1024)";
        public static string Nvarchar2048 => "character varying(2048)";
        public static string NvarcharMax => "character varying(max)";
       
        public static string Date => "date";
        public static string DateTime => "timestamp";

        public static string Time => "time";
     

    }
}
