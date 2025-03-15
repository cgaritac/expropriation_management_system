using System.ComponentModel;

namespace GestionExpropaciones.Common.Enums
{
    public enum AppraisalEnum
    {
        [Description("Pendiente")]
        Pending,

        [Description("Depositado")]
        Paid,

        [Description("Otro")]
        Other,
    }
}
