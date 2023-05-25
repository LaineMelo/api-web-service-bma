using api_web_service_bma.Models;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace api_web_service_bma.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Criar, ler, atualizar e excluir cadastros de Beneficiários")]
    public class BeneficiarioController : ControllerBase
    {
        private readonly AppDbContext _context;
        public BeneficiarioController(AppDbContext context)

        {
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(
        Summary = "Listar todos os cadastros de Beneficiários no sistema",
        OperationId = "ListarBeneficiario")]
        public async Task<ActionResult> GetAll()
        {
            var model = await _context.Beneficiarios.ToListAsync();
            return Ok(model);
        }

        [HttpPost]
        [SwaggerOperation(
        Summary = "Criar cadastro Beneficiário no sistema",
        Description = "Requer privelégios de Usuário",
        OperationId = "CriarBeneficiario")]
        [SwaggerResponse(201, "Cadastro criado com sucesso!", typeof(Beneficiario))]
        [SwaggerResponse(400, "Os dados do Benficiciário não são válidos!")]
        public async Task<ActionResult> Create([FromBody]Beneficiario model)
        {
            _context.Beneficiarios.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new { id = model.Id }, model );
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
        Summary = "Listar cadastro de Beneficiário específico no sistema",
        OperationId = "ListarIdBeneficiario")]
        public async Task<ActionResult> GetById(int id)
        {
            var model = await _context.Beneficiarios.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (model == null) NotFound();
            return Ok(model);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
        Summary = "Atualizar cadastro de Beneficiário específico no sistema",
        OperationId = "AtualizarIdBeneficiario")]

        public async Task<ActionResult> Update(int id, Beneficiario model)
        {
            if (id != model.Id) return BadRequest();


            //  var modeloDb = await _context.Beneficiarios.AsNoTracking()
            //   .FirstOrDefaultAsync(c => c.Id == id);
            var modeloDb = await _context.Beneficiarios.FindAsync(id);
           
            if (modeloDb==null) return NotFound();

            _context.Entry(modeloDb).State = EntityState.Detached;

            

            _context.Beneficiarios.Update(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
        Summary = "Excluir cadastro de Beneficiário específico no sistema",
        Description = "Requer privelégios de Administrador",
        OperationId = "ExcluirIdBeneficiario")]
        public async Task<ActionResult> Delete (int id) 
        {
            var model = await _context.Beneficiarios.FindAsync(id);

            if (model == null) NotFound();

            if (model != null)
            {
                _context.Beneficiarios.Remove(model);
                await _context.SaveChangesAsync();
            }
            

            return NoContent();
      
        }
    }
}
