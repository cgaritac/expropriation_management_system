using System.ComponentModel;

namespace GestionExpropaciones.Common.Enums
{
    public enum PosessionStatusEnum
    {
        [Description("Pendiente")]
        Pending,

        [Description("En trámite")]
        InProgress,

        [Description("Completado")]
        Complete,

        [Description("Otro")]
        Other,
    }
}
