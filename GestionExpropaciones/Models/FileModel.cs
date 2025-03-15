using GestionExpropaciones.Common.Enums;
using GestionExpropaciones.Common.Helpers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GestionExpropaciones.Models;

public class FileModel
{
    [Key]
    [JsonIgnore]
    [DisplayName("Id")]
    public int Id { get; set; }

    [DisplayName("N° Expediente")]
    [Required(ErrorMessage = "El número de expediente es obligatorio.")]
    [StringLength(50, ErrorMessage = "El número de expediente no puede exceder los 50 caracteres.")]
    public string Number { get; set; }

    [DisplayName("N° Proyecto")]
    [Required(ErrorMessage = "El número de proyecto es obligatorio.")]
    [StringLength(50, ErrorMessage = "El número de proyecto no puede exceder los 50 caracteres.")]
    public string Project_Number { get; set; }

    [DisplayName("Sección")]
    [Range(0, 99999, ErrorMessage = "El número de sección debe ser un valor positivo.")]
    public int? Section { get; set; }

    [DisplayName("Kilómetro")]
    [StringLength(20, ErrorMessage = "El dato de kilómetro no puede exceder los 20 caracteres.")]
    public string? Km { get; set; }

    [DisplayName("Fase")]
    [Required(ErrorMessage = "La fase es obligatoria.")]
    [EnumDataType(typeof(FaseEnum), ErrorMessage = "Fase inválida.")]
    public FaseEnum Fase { get; set; }

    [DisplayName("Estado")]
    [Required(ErrorMessage = "El estado es obligatorio.")]
    [EnumDataType(typeof(StatusEnum), ErrorMessage = "Estado inválido.")]
    public StatusEnum Status { get; set; }

    [DisplayName("Fecha inicio")]
    [Required(ErrorMessage = "La fecha de inicio es obligatoria.")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime Start_Date { get; set; }

    [DisplayName("Fecha cierre")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
    public DateTime? Finish_Date { get; set; }

    [DisplayName("Comentarios")]
    [StringLength(2000, ErrorMessage = "El comentario no puede exceder los 2000 caracteres.")]
    public string? Comments { get; set; }

    [JsonIgnore]
    [StringLength(100, ErrorMessage = "El nombre del creador no puede exceder los 100 caracteres.")]
    public string Created_By { get; private set; }

    [JsonIgnore]
    public bool Is_Active { get; private set; }


    [JsonIgnore]
    public List<OwnerModel> Owners { get; set; }

    [JsonIgnore]
    public List<OwnerPropertyModel> OwnerProperties { get; set; }

    [JsonIgnore]
    public List<PaperWorkModel> PaperWorks { get; set; }

    [JsonIgnore]
    public List<AppraisalModel> Appraisals { get; set; }

    [JsonIgnore]
    public List<ExpropiatedPropertyModel> ExpropiatedProperties { get; set; }


    [NotMapped]
    public string Fase_Description => EnumHelper.GetEnumDescription(Fase);

    [NotMapped]
    public string Status_Description => EnumHelper.GetEnumDescription(Status);

    public FileModel()
    {
        Number = string.Empty;
        Project_Number = string.Empty;
        Created_By = string.Empty;
        Status = StatusEnum.Started;
        Fase = FaseEnum.Opening;
        Comments = string.Empty;
        Is_Active = true;

        Owners = new List<OwnerModel>();
        OwnerProperties = new List<OwnerPropertyModel>();
        PaperWorks = new List<PaperWorkModel>();
        Appraisals = new List<AppraisalModel>();
        ExpropiatedProperties = new List<ExpropiatedPropertyModel>();
    }
    public void SetCreationInfo(string user)
    {
        Start_Date = DateTime.Now;
        Created_By = user;
        Fase = FaseEnum.Opening;
        Status = StatusEnum.Started;
        Is_Active = true;
    }
}
