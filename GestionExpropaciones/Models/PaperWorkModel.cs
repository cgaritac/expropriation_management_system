using GestionExpropaciones.Common.Enums;
using GestionExpropaciones.Common.Helpers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GestionExpropaciones.Models;

public class PaperWorkModel
{
    [Key]
    [JsonIgnore]
    [DisplayName("Id")]
    public int Id { get; set; }

    [DisplayName("N° Documento")]
    [Required(ErrorMessage = "El número de documento es obligatorio.")]
    [StringLength(50, ErrorMessage = "El número de documento no puede exceder los 50 caracteres.")]
    public string Document_Number { get; set; }

    [DisplayName("Fecha documento")]
    [Required(ErrorMessage = "La fecha del documento es obligatoria.")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime Document_Date { get; set; }

    [DisplayName("Tipo de trámite")]
    [Required(ErrorMessage = "El tipo de trámite es obligatorio.")]
    [EnumDataType(typeof(PaperWorkTypesEnum), ErrorMessage = "Tipo de trámite inválido.")]
    public PaperWorkTypesEnum PaperWork_type { get; set; }

    [DisplayName("Comentarios")]
    [StringLength(2000, ErrorMessage = "El comentario no puede exceder los 2000 caracteres.")]
    public string? Comments { get; set; }

    [JsonIgnore]
    [StringLength(100, ErrorMessage = "El nombre del creador no puede exceder los 100 caracteres.")]
    public string Created_By { get; private set; }

    [JsonIgnore]
    [DataType(DataType.Date)]
    public DateTime Created_On { get; private set; }

    [JsonIgnore]
    public bool Is_Active { get; private set; }


    [Required]
    [ForeignKey("File")]
    [DisplayName("Expediente Id")]
    public int FileId { get; set; }

    [JsonIgnore]
    public FileModel File { get; set; }


    [NotMapped]
    public string PaperWork_type_Description => EnumHelper.GetEnumDescription(PaperWork_type);


    public PaperWorkModel()
    {
        Document_Number = string.Empty;
        PaperWork_type = PaperWorkTypesEnum.AnnotationOrder;
        Created_By = string.Empty;
        Is_Active = true;

        FileId = 0;
        File = new FileModel();
    }

    public void SetCreationInfo(string user)
    {
        Created_On = DateTime.Now;
        Created_By = user;
        Is_Active = true;
    }

    public void SetSoftDelete()
    {
        Is_Active = true;
    }
}
