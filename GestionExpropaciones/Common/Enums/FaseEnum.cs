using System.ComponentModel;

namespace GestionExpropaciones.Common.Enums;

public enum FaseEnum
{
    [Description("Apertura")]
    Opening,

    [Description("Gestoría")]
    Managemant,

    [Description("Mandamiento Anotación")]
    SendingAnnotation,

    [Description("Declaratoria Interés Público")]
    PublicInterestDeclaratory,

    [Description("Publicación Declaratoria (DIP)")]
    DeclaratoryPublication,

    [Description("Avalúo Administrativo")]
    AdministativeAppraisal,

    [Description("Notificación Avalúo y DIP")]
    AppraisalNotification,

    [Description("Resoluciones")]
    Resolutions,

    [Description("Solicitud de Fondos Avalúos")]
    FundsRequest,

    [Description("Depósito Avalúo")]
    AppraisalDeposit,

    [Description("Certificaciones")]
    Certifications,

    [Description("Medidas y Linderos")]
    LimitsAndMesurements,

    [Description("Informe de Gravámenes")]
    LiensReport,

    [Description("Personería Jurídica")]
    LegalEntity,

    [Description("Procuraduría Notaría")]
    JutyNotary,

    [Description("Procuraduría Juzgado")]
    JuryJury,

    [Description("Escritura Pública")]
    PublicDeed,

    [Description("Entrada en Posesión Judicial")]
    JudicialPossessionTakeover,

    [Description("Otro")]
    Other,
}
