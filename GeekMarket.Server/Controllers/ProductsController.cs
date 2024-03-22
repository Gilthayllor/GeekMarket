using GeekMarket.Server.Data;
using GeekMarket.Shared.DTOs.Product;
using GeekMarket.Shared.Extensions;
using GeekMarket.Shared.Reponse;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace GeekMarket.Server.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly GeekMarketContext _context;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(GeekMarketContext context, ILogger<ProductsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(x => x.Id.ToString() == id);

                if (product is null)
                    return NotFound(Result.Failure("Produto não encontrado."));

                return Ok(Result<ProductDTO>.Success(product.ToDTO()));
            }
            catch (DbException e)
            {
                _logger.LogError(e, "Erro interno no banco de dados.");
                return StatusCode(500, Result.Failure("Ocorreu um erro no banco de dados ao processar a requisição."));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Erro interno no servidor.");
                return StatusCode(500, Result.Failure("Ocorreu um erro ao processar a requisição."));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] bool featured)
        {
            try
            {
                var products = await _context.Products
                        .AsNoTracking()
                        .Where(x => x.Featured == featured)
                        .ToListAsync();

                return Ok(Result<IEnumerable<ProductDTO>>.Success(products.ToDTO()));
            }
            catch (DbException e)
            {
                _logger.LogError(e, "Erro interno no banco de dados.");
                return StatusCode(500, Result.Failure("Ocorreu um erro no banco de dados ao processar a requisição."));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Erro interno no servidor.");
                return StatusCode(500, Result.Failure("Ocorreu um erro ao processar a requisição."));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductEditDTO productEditDTO)
        {
            try
            {
                var productFound = await _context.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Name.ToLower() == productEditDTO.Name.ToLower());
                if (productFound is not null)
                    return BadRequest(Result.Failure($"Já existe um produto cadastrado com o nome {productEditDTO.Name}"));

                var newProduct = productEditDTO.ToModel();

                await _context.Products.AddAsync(newProduct);
                await _context.SaveChangesAsync();

                return Ok(Result<ProductDTO>.Success(newProduct.ToDTO()));
            }
            catch (DbException e)
            {
                _logger.LogError(e, "Erro interno no banco de dados.");
                return StatusCode(500, Result.Failure("Ocorreu um erro no banco de dados ao processar a requisição."));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Erro interno no servidor.");
                return StatusCode(500, Result.Failure("Ocorreu um erro ao processar a requisição."));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] string id, [FromBody] ProductEditDTO productEditDTO)
        {
            try
            {
                var productFound = await _context.Products.FirstOrDefaultAsync(x => x.Id.ToString() == id);
                if (productFound is null)
                    return NotFound(Result.Failure("Produto não encontrado."));

                if (productFound.Name != productEditDTO.Name)
                {
                    var productWithSameName = await _context.Products.AsNoTracking()
                        .FirstOrDefaultAsync(x => x.Name.ToLower() == productEditDTO.Name.ToLower() && x.Id != productFound.Id);
                    if (productWithSameName is not null)
                        return BadRequest(Result.Failure($"Já existe um produto cadastrado com o nome {productEditDTO.Name}"));
                }

                productFound.Featured = productEditDTO.Featured;
                productFound.Name = productEditDTO.Name;
                productFound.Price = productEditDTO.Price;
                productFound.Description = productEditDTO.Description;
                productFound.Base64Image = productEditDTO.Base64Image;
                productFound.Quantity = productEditDTO.Quantity;
                productFound.LastUpdate = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                return Ok(Result<ProductDTO>.Success(productFound.ToDTO()));
            }
            catch (DbException e)
            {
                _logger.LogError(e, "Erro interno no banco de dados.");
                return StatusCode(500, Result.Failure("Ocorreu um erro no banco de dados ao processar a requisição."));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Erro interno no servidor.");
                return StatusCode(500, Result.Failure("Ocorreu um erro ao processar a requisição."));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            try
            {
                var productFound = await _context.Products.FirstOrDefaultAsync(x => x.Id.ToString() == id);
                if (productFound is null)
                    return NotFound(Result.Failure("Produto não encontrado."));

                _context.Products.Remove(productFound);
                await _context.SaveChangesAsync();

                return Ok(Result.Success());
            }
            catch (DbException e)
            {
                _logger.LogError(e, "Erro interno no banco de dados.");
                return StatusCode(500, Result.Failure("Ocorreu um erro no banco de dados ao processar a requisição."));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Erro interno no servidor.");
                return StatusCode(500, Result.Failure("Ocorreu um erro ao processar a requisição."));
            }
        }
    }
}
