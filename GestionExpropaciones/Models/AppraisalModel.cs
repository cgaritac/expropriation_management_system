using GestionExpropaciones.Common.Enums;
using GestionExpropaciones.Common.Helpers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GestionExpropaciones.Models;

public class AppraisalModel
{
    [Key]
    [JsonIgnore]
    [DisplayName("Id")]
    public int Id { get; set; }

    [DisplayName("N° Avalúo")]
    [Required(ErrorMessage = "El número de avalúo es obligatorio.")]
    [StringLength(50, ErrorMessage = "El número de avalúo no puede exceder los 50 caracteres.")]
    public string Appraisal_Number { get; set; }

    [DisplayName("Fecha avalúo")]
    [Required(ErrorMessage = "La fecha del avalúo es obligatoria.")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime Appraisal_Date { get; set; }

    [DisplayName("Avalúo estimado")]
    [Required(ErrorMessage = "El valor del avalúo estimado es obligatorio.")]
    [Range(0, 99999999999, ErrorMessage = "El valor del avalúo estimado debe ser un valor positivo.")]
    public float Estimated_Appraisal { get; set; }

    [DisplayName("Avalúo real")]
    [Required(ErrorMessage = "El valor del avalúo real es obligatorio.")]
    [Range(0, 99999999999, ErrorMessage = "El valor del avalúo real debe ser un valor positivo.")]
    public float? Real_Appraisal { get; set; }

    [DisplayName("Estado avalúo")]
    [Required(ErrorMessage = "El estado del avalúo es obligatorio.")]
    [EnumDataType(typeof(AppraisalEnum), ErrorMessage = "Estado de avalúo inválido.")]
    public AppraisalEnum Payment_Status { get; set; }

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
    public string Payment_Status_Description => EnumHelper.GetEnumDescription(Payment_Status);

    public AppraisalModel()
    {
        Appraisal_Number = string.Empty;
        Estimated_Appraisal = 0;
        Payment_Status = AppraisalEnum.Pending;
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
