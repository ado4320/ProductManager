using AutoMapper;
using CoreApiResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManager.Core.Services.Dtos;
using ProductManager.Core.Services.Entities;
using ProductManager.Core.Services.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ProductManager.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IMapper Mapper { get; }
        private readonly IProductService _productService;

        // Constructor que recibe IMapper y IProductService como dependencias
        public ProductController(IMapper mapper, IProductService productService)
        {
            Mapper = mapper;
            _productService = productService;
        }

        // Método HTTP POST para crear un nuevo producto
        [HttpPost]
        [Authorize(Roles = "Administrador")] // Requiere autorización de roles de "Administrador"
        public async Task<ActionResult> CreateProduct(ProductDto productDto)
        {
            try
            {
                // Mapea un ProductDto a un objeto Product usando AutoMapper
                Product product = Mapper.Map<Product>(productDto);
                // Llama al servicio para crear el producto
                await _productService.CreateAsync(product);
                // Retorna un resultado HTTP 201 (Created) con un mensaje de éxito
                return StatusCode((int)HttpStatusCode.Created, "Product successfully created");
            }
            catch (ApplicationException ex)
            {
                // En caso de excepción, devuelve un resultado HTTP 500 (InternalServerError) con el mensaje de la excepción
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // Método HTTP PUT para actualizar un producto existente
        [HttpPut]
        [Authorize(Roles = "Administrador")] // Requiere autorización de roles de "Administrador"
        public async Task<ActionResult> UpdateAsync(ProductDto productDto)
        {
            try
            {
                // Mapea un ProductDto a un objeto Product usando AutoMapper
                Product product = Mapper.Map<Product>(productDto);
                // Llama al servicio para actualizar el producto
                await _productService.UpdateAsync(product);
                // Retorna un resultado HTTP 201 (Created) con un mensaje de éxito
                return StatusCode((int)HttpStatusCode.Created, "Product successfully updated");
            }
            catch (ApplicationException ex)
            {
                // En caso de excepción, devuelve un resultado HTTP 500 (InternalServerError) con el mensaje de la excepción
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // Método HTTP DELETE para eliminar un producto por su ID
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")] // Requiere autorización de roles de "Administrador"
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                // Llama al servicio para eliminar el producto
                await _productService.DeleteAsync(id);
                // Retorna un resultado HTTP 201 (Created) con un mensaje de éxito
                return StatusCode((int)HttpStatusCode.Created, "Product successfully deleted");
            }
            catch (Exception ex)
            {
                // En caso de excepción, devuelve un resultado HTTP 500 (InternalServerError) con el mensaje de la excepción
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // Método HTTP GET para obtener todos los productos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllAsync()
        {
            try
            {
                // Llama al servicio para obtener todos los productos
                var products = Mapper.Map<List<ProductDto>>(await _productService.GetAllProductsAsync());
                // Retorna un resultado HTTP 200 (OK) con una lista de todos los productos en formato ProductDto
                return Ok(products);
            }
            catch (Exception ex)
            {
                // En caso de excepción, devuelve un resultado HTTP 500 (InternalServerError) con el mensaje de la excepción
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // Método HTTP GET para buscar productos por nombre
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> SearchProductByNameAsync(string name)
        {
            try
            {
                // Llama al servicio para buscar productos por nombre
                var products = Mapper.Map<List<ProductDto>>(await _productService.SearchProductByNameAsync(name));
                // Retorna un resultado HTTP 200 (OK) con una lista de productos coincidentes en formato ProductDto
                return Ok(products);
            }
            catch (Exception ex)
            {
                // En caso de excepción, devuelve un resultado HTTP 500 (InternalServerError) con el mensaje de la excepción
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // Método HTTP GET para buscar productos por rango de precio
        [HttpGet("searchRange")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> SearchByRangeAsync(decimal minimunPrice, decimal maximunPrice)
        {
            try
            {
                // Llama al servicio para buscar productos por rango de precio
                var products = Mapper.Map<List<ProductDto>>(await _productService.SearchByRangeAsync(minimunPrice, maximunPrice));
                // Retorna un resultado HTTP 200 (OK) con una lista de productos que están dentro del rango de precios especificado en formato ProductDto
                return Ok(products);
            }
            catch (Exception ex)
            {
                // En caso de excepción, devuelve un resultado HTTP 500 (InternalServerError) con el mensaje de la excepción
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
