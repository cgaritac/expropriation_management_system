using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GestionExpropaciones.Models;

public class ProjectModel
{
    [Key]
    [JsonIgnore]
    [DisplayName("Id")]
    public int Id { get; set; }

    [DisplayName("N° Proyecto")]
    [Required(ErrorMessage = "El número de proyecto es obligatorio.")]
    [StringLength(50, ErrorMessage = "El número de proyecto no puede exceder los 50 caracteres.")]
    public string Number { get; set; }

    [DisplayName("Nombre Proyecto")]
    [Required(ErrorMessage = "El nombre del proyecto es obligatorio.")]
    [StringLength(50, ErrorMessage = "El nombre del proyecto no puede exceder los 50 caracteres.")]
    public string Name { get; set; }

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

    public ProjectModel()
    {
        Number = string.Empty;
        Name = string.Empty;
        Comments = string.Empty;
        Created_By = string.Empty;
        Is_Active = true;
    }

    public void SetCreationInfo(string user)
    {
        Created_On = DateTime.Now;
        Created_By = user;
        Is_Active = true;
    }
}
