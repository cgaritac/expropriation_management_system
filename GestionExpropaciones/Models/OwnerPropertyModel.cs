using GestionExpropaciones.Common.Enums;
using GestionExpropaciones.Common.Helpers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GestionExpropaciones.Models;

public class OwnerPropertyModel
{
    [Key]
    [JsonIgnore]
    [DisplayName("Id")]
    public int Id { get; set; }

    [DisplayName("N° Plano Catastro")]
    [Required(ErrorMessage = "El número de plano catastro es obligatorio.")]
    [StringLength(20, ErrorMessage = "El número de plano catastro no puede exceder los 20 caracteres.")]
    public string CadastralMap_Number { get; set; }

    [DisplayName("N° Folio")]
    [Required(ErrorMessage = "El número de folio es obligatorio.")]
    [StringLength(20, ErrorMessage = "El número de folio no puede exceder los 20 caracteres.")]
    public string Folio_Number { get; set; }

    [DisplayName("Área")]
    [Required(ErrorMessage = "El área es obligatoria.")]
    [Range(0, 99999999, ErrorMessage = "El área debe ser un valor positivo.")]
    public int Area { get; set; }

    [DisplayName("Anotación")]
    [Required(ErrorMessage = "La anotación es obligatoria.")]
    [EnumDataType(typeof(AnnotationEnum), ErrorMessage = "Anotación inválida.")]
    public AnnotationEnum Annotation { get; set; }

    [DisplayName("Provincia")]
    [Required(ErrorMessage = "La provincia es obligatoria.")]
    [EnumDataType(typeof(AnnotationEnum), ErrorMessage = "provincia inválida.")]
    public ProvinceEnum Province { get; set; }

    [DisplayName("Cantón")]
    [Required(ErrorMessage = "El cantón es obligatorio.")]
    [Range(0, 99, ErrorMessage = "El cantón debe ser un valor positivo.")]
    public int Canton { get; set; }

    [DisplayName("Distrito")]
    [StringLength(20, ErrorMessage = "El distrito no puede exceder los 20 caracteres.")]
    public string? District { get; set; }

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
    public string Province_Description => EnumHelper.GetEnumDescription(Province);

    [NotMapped]
    public string Canton_Description => GetCantonDescription(Province, Canton);

    private string GetCantonDescription(ProvinceEnum province, int cantonId)
    {
        return province switch
        {
            ProvinceEnum.SanJose => EnumHelper.GetEnumDescription((CantonSanJoseEnum)cantonId),
            ProvinceEnum.Heredia => EnumHelper.GetEnumDescription((CantonHerediaEnum)cantonId),
            ProvinceEnum.Alajuela => EnumHelper.GetEnumDescription((CantonAlajuelaEnum)cantonId),
            ProvinceEnum.Cartago => EnumHelper.GetEnumDescription((CantonCartagoEnum)cantonId),
            ProvinceEnum.Limon => EnumHelper.GetEnumDescription((CantonLimonEnum)cantonId),
            ProvinceEnum.Guanacaste => EnumHelper.GetEnumDescription((CantonGuanacasteEnum)cantonId),
            ProvinceEnum.Puntarenas => EnumHelper.GetEnumDescription((CantonPuntarenasEnum)cantonId),
            _ => "Cantón desconocido"
        };
    }

    public OwnerPropertyModel()
    {
        CadastralMap_Number = string.Empty;
        Folio_Number = string.Empty;
        Area = 0;
        Canton = 0;
        District = string.Empty;
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
