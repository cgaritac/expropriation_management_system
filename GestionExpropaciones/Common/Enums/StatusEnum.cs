using System.ComponentModel;

namespace GestionExpropaciones.Common.Enums;

public enum StatusEnum
{
    [Description("Creado")]
    Started,

    [Description("En Proceso")]
    InProgress,

    [Description("Detenido")]
    Stopped,

    [Description("Desestimado")]
    Abandoned,

    [Description("Finalizado (EPJ)")]
    EPJFinalized,

    [Description("Finalizado (PNE)")]
    PNEFinalized,

    [Description("Otro")]
    Other,
}
