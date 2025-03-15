using System.ComponentModel;

namespace GestionExpropaciones.Common.Enums;

public enum PaperWorkTypesEnum
{
    [Description("Mandamiento Anotación")]
    AnnotationOrder,

    [Description("Declaratoria Interés Público")]
    PublicInterestDeclaratory,

    [Description("Publicación Declaratoria (DIP)")]
    DeclaratoryPublication,

    [Description("Avalúo Administrativo")]
    AdministativeAppraisal,

    [Description("Depósito Avalúo")]
    AppraisalDeposit,

    [Description("Notificación Avalúo y DIP")]
    AppraisalNotification,

    [Description("Certificaciones")]
    Certifications,

    [Description("Medidas y Linderos")]
    LimitsAndMesurements,

    [Description("Procuraduría Notaría")]
    JutyNotary,

    [Description("Procuraduría Juzgado")]
    JuryJury,

    [Description("Gestiones Internas")]
    InternalManagemente,

    [Description("Otro")]
    Other,
}
