using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMC20240906.DTOs.ProductsDTOs
{
    public class SearchResultProductGSMCDTO
    {
        public int CountRow { get; set; }
        public List<ProductGSMCDTO> Data { get; set; }

        public class ProductGSMCDTO
        {
            public int Id { get; set; }
            [Display(Name = "Nombre")]
            public string NombreGSMC { get; set; }
            [Display(Name = "Descripción")]
            public string DescripcionGSMC { get; set; }
            [Display(Name = "Precio")]
            public decimal PrecioGSMC { get; set; }
        }
    }
}
