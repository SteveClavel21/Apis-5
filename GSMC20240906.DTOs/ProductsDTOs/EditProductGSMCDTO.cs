using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMC20240906.DTOs.ProductsDTOs
{
    public class EditProductGSMCDTO
    {
        [Required(ErrorMessage = "El campo ID es obligatorio.")]
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo Nombre no puede tener más de 50 caracteres.")]
        public string NombreGSMC { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "El campo Descripción es obligatorio.")]
        [MaxLength(255, ErrorMessage = "El campo Descripción no puede tener más de 255 caracteres.")]
        public string DescripcionGSMC { get; set; }

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "El campo Precio es obligatorio.")]
        [Range(0, double.MaxValue, ErrorMessage = "El campo Precio debe ser un número positivo.")]
        public decimal PrecioGSMC { get; set; }

        public EditProductGSMCDTO()
        {
            NombreGSMC = string.Empty;
            DescripcionGSMC = string.Empty;
            PrecioGSMC = 0.01m;

        }

        public EditProductGSMCDTO(GetIdResultProductGSMCDTO getIdResultProductGSMCDTO)
        {
            Id = getIdResultProductGSMCDTO.Id;
            NombreGSMC = getIdResultProductGSMCDTO.NombreGSMC;
            DescripcionGSMC = getIdResultProductGSMCDTO.DescripcionGSMC;
            PrecioGSMC = getIdResultProductGSMCDTO.PrecioGSMC;
        }
    }
}
