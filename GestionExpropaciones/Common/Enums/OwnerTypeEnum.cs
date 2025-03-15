using System.ComponentModel;

namespace GestionExpropaciones.Common.Enums;

public enum OwnerTypeEnum
{
    [Description("Persona física")]
    Person,

    [Description("Persona Jurídica")]
    Company,
}
