﻿using GestionExpropaciones.Common.Enums;
using GestionExpropaciones.Common.Helpers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GestionExpropaciones.Models;

public class ExpropiatedPropertyModel
{
    [Key]
    [JsonIgnore]
    [DisplayName("Id")]
    public int Id { get; set; }

    [DisplayName("N° Folio")]
    [Required(ErrorMessage = "El número de folio es obligatorio.")]
    [StringLength(20, ErrorMessage = "El número de folio no puede exceder los 20 caracteres.")]
    public string Folio_Number { get; set; }

    [DisplayName("N° Plano Catastro")]
    [Required(ErrorMessage = "El número de plano catastro es obligatorio.")]
    [StringLength(20, ErrorMessage = "El número de plano catastro no puede exceder los 20 caracteres.")]
    public string Cadastral_Map { get; set; }

    [DisplayName("Área")]
    [Required(ErrorMessage = "El área es obligatoria.")]
    [Range(0, 99999999, ErrorMessage = "El área debe ser un valor positivo.")]
    public int Area { get; set; }

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

    public ExpropiatedPropertyModel()
    {
        Folio_Number = string.Empty;
        Cadastral_Map = string.Empty;
        Area = 0;
        Province = ProvinceEnum.SanJose;
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