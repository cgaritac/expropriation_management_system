using System.ComponentModel;

namespace GestionExpropaciones.Common.Enums;

public enum AnnotationEnum
{
    [Description("Aviso catastral")]
    CadastralWarning,

    [Description("Demanda")]
    Sue,

    [Description("Hipoteca")]
    Mortgage,

    [Description("Servidumbre")]
    Easement,

    [Description("Limpio")]
    Clean,

    [Description("Otro")]
    Other,
}
