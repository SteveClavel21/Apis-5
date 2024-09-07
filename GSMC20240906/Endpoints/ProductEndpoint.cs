using GSMC20240906.Models.DAL;
using GSMC20240906.Models.EN;
using GSMC20240906.DTOs.ProductsDTOs;
using Microsoft.AspNetCore.Mvc;
using static GSMC20240906.DTOs.ProductsDTOs.SearchResultProductGSMCDTO;

namespace GSMC20240906.Endpoints
{
    public static class ProductEndpoint
    {
        public static void AddProductEndpoints(this WebApplication app)
        {

            app.MapPost("/product/search", async (SearchQueryProductGSMCDTO productDTO, ProductGSMCDAL productDAL) =>
            {
                // Ajuste temporal para verificar si la búsqueda encuentra productos
                var product = new ProductGSMC
                {
                    NombreGSMC = productDTO.NombreGSMC_Like
                };

                // Omitir el conteo de filas inicialmente para simplificar la lógica
                var products = await productDAL.Search(product, skip: productDTO.Skip, take: productDTO.Take);

                // Verificar si se encontraron productos
                if (products == null || !products.Any())
                {
                    return Results.NotFound("No se encontraron productos con los criterios de búsqueda proporcionados.");
                }

                // Crear el resultado
                var productResult = new SearchResultProductGSMCDTO
                {
                    Data = products.Select(s => new SearchResultProductGSMCDTO.ProductGSMCDTO
                    {
                        Id = s.Id,
                        NombreGSMC = s.NombreGSMC,
                        DescripcionGSMC = s.DescripcionGSMC,
                        PrecioGSMC = s.PrecioGSMC
                    }).ToList(),
                    CountRow = productDTO.SendRowCount == 2 ? await productDAL.CountSearch(product) : products.Count
                };

                return Results.Ok(productResult);
            });


            app.MapGet("/product/{id}", async (int id, ProductGSMCDAL productDAL) =>
            {
                var product = await productDAL.GetById(id);

                if (product == null)
                {
                    return Results.NotFound("Producto no encontrado");
                }

                var productDTO = new GetIdResultProductGSMCDTO
                {
                    Id = product.Id,
                    NombreGSMC = product.NombreGSMC,
                    DescripcionGSMC = product.DescripcionGSMC,
                    PrecioGSMC = product.PrecioGSMC
                };
                return Results.Ok(productDTO);
            });

            app.MapPost("/product", async (CreateProductGSMCDTO productDTO, ProductGSMCDAL productDAL) =>
            {
                var product = new ProductGSMC
                {
                    NombreGSMC = productDTO.NombreGSMC,
                    DescripcionGSMC = productDTO.DescripcionGSMC,
                    PrecioGSMC = productDTO.PrecioGSMC
                };

                int result = await productDAL.Create(product);

                if (result > 0)
                {
                    return Results.Created($"/product/{result}", new { Id = result });
                }
                return Results.StatusCode(500);
            });

            app.MapPut("/product", async (EditProductGSMCDTO productDTO, ProductGSMCDAL productDAL) =>
            {
                var product = new ProductGSMC
                {
                    Id = productDTO.Id,
                    NombreGSMC = productDTO.NombreGSMC,
                    DescripcionGSMC = productDTO.DescripcionGSMC,
                    PrecioGSMC = productDTO.PrecioGSMC
                };

                int result = await productDAL.Edit(product);

                if (result > 0)
                {
                    return Results.Ok(result);
                }
                return Results.StatusCode(500);
            });

            app.MapDelete("/product/{id}", async (int id, ProductGSMCDAL productDAL) =>
            {
                if (id <= 0)
                {
                    return Results.BadRequest("ID inválido");
                }

                int result = await productDAL.Delete(id);

                if (result > 0)
                {
                    return Results.Ok("Producto eliminado");
                }

                return Results.StatusCode(500);
            });
        }
    }
}
