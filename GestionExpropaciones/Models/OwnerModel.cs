using GestionExpropaciones.Common.Enums;
using GestionExpropaciones.Common.Helpers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GestionExpropaciones.Models;

public class OwnerModel
{
    [Key]
    [JsonIgnore]
    [DisplayName("Id")]
    public int Id { get; set; }

    [DisplayName("Nombre")]
    [Required(ErrorMessage = "El nombre del propietario es obligatorio.")]
    [StringLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres.")]
    public string First_Name { get; set; }

    [DisplayName("Apellido 1")]
    [StringLength(50, ErrorMessage = "El primer apellido no puede exceder los 50 caracteres.")]
    public string? Last_Name1 { get; set; }

    [DisplayName("Apellido 2")]
    [StringLength(50, ErrorMessage = "El segundo apellido no puede exceder los 50 caracteres.")]
    public string? Last_Name2 { get; set; }

    [DisplayName("Teléfono 1")]
    [StringLength(100, ErrorMessage = "El primer teléfono no puede exceder los 100 caracteres.")]
    public string? Phone1 { get; set; }

    [DisplayName("Teléfono 2")]
    [StringLength(100, ErrorMessage = "El segundo teléfono no puede exceder los 100 caracteres.")]
    public string? Phone2 { get; set; }

    [DisplayName("Email 1")]
    [StringLength(100, ErrorMessage = "El primer email no puede exceder los 100 caracteres.")]
    public string? Email1 { get; set; }

    [DisplayName("Email 2")]
    [StringLength(100, ErrorMessage = "El segundo email no puede exceder los 100 caracteres.")]
    public string? Email12 { get; set; }

    [DisplayName("Dirección")]
    [StringLength(200, ErrorMessage = "La dirección no puede exceder los 200 caracteres.")]
    public string? Address { get; set; }

    [DisplayName("Cédula")]
    [Required(ErrorMessage = "La cédula del propietario es obligatoria.")]
    [StringLength(10, ErrorMessage = "La cédula no puede exceder los 10 caracteres.")]
    public string Identification_Number { get; set; }

    [DisplayName("Tipo de Persona")]
    [Required(ErrorMessage = "El tipo de persona del propietario es obligatoria.")]
    [EnumDataType(typeof(OwnerTypeEnum), ErrorMessage = "Tipo de persona inválido.")]
    public OwnerTypeEnum Owner_Type { get; set; }

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

    //public List<PropertyModel> Properties { get; set; }


    [NotMapped]
    public string Owner_Type_Description => EnumHelper.GetEnumDescription(Owner_Type);

    public OwnerModel()
    {
        First_Name = string.Empty;
        Identification_Number = string.Empty;
        Owner_Type = OwnerTypeEnum.Person;
        Created_By = string.Empty;
        Is_Active = true;

        FileId = 0;
        File = new FileModel();
        //Properties = new List<PropertyModel>();
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
