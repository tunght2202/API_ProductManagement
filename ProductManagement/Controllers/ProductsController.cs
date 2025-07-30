using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Model.Models;
using ProductManagement.Repo;

namespace ProductManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        protected ProductRepo _context = new ProductRepo();
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(new
                {
                    status = 1,
                    message = "success",
                    data = _context.GetAll()
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = 0,
                    message = ex.Message,
                });
            }
        }

        [HttpGet("GetProductById")]
        public IActionResult GetProductById(int id)
        {
            try
            {
                return Ok(new
                {
                    status = 1,
                    message = "success",
                    data = _context.Get(id)
                });
            }
            catch(Exception ex)
            {
                return BadRequest(new
                {
                    status = 0,
                    message = ex.Message,
                });
            }
        }

        [HttpPost("CreateProduct")]
        public IActionResult CreateProduct([FromBody] SanPham product)
        {
            try
            {
                product.NgayTao = product.NgayCapNhat = DateTime.Now;
                _context.Create(product);
                return Ok(new
                {
                    status = 1,
                    message = "success",
                    data = product
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = 0,
                    message = ex.Message,
                });
            }
        }


        [HttpPost("UpdateProduct")]
        public IActionResult UpdateProduct([FromBody] SanPham product)
        {
            try
            {
                product.NgayCapNhat = DateTime.Now;
                _context.Update(product);
                return Ok(new
                {
                    status = 1,
                    message = "success",
                    data = product
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = 0,
                    message = ex.Message,
                });
            }
        }

        [HttpDelete("DeleteProduct")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                _context.Delete(id);
                return Ok(new
                {
                    status = 1,
                    message = "success",
                    data = _context.GetAll()
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = 0,
                    message = ex.Message,
                });
            }
        }
    }
}
