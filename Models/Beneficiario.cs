using api_web_service_bma.Enum;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_web_service_bma.Models
{
    [Table("Beneficiarios")]
    public class Beneficiario
    {
        [Key]
        [SwaggerSchema("Identificador do cadastro", ReadOnly = true)]
        public int Id { get; set; }

        [SwaggerSchema("Nome completo")]
        [Required]
        public string Nome { get; set; }

        [SwaggerSchema("Cadastro de Pessoa Física")]
        [Required]
        public string Cpf { get; set; }

        [SwaggerSchema("Data de Nascimento", Format = "datetime")]
        [Required]
        public DateTime DataNascimento { get; set; }

        [SwaggerSchema("E-mail, se requerido")]
        public string Email { get; set; }

        [SwaggerSchema("Telefone para contato")]
        [Required]
        public string Telefone { get; set; }

        [SwaggerSchema("Endereço")]
        [Required]
        public string Cep { get; set; }
        
        [Required]
        public string Logradouro { get; set; }
       
        [Required]
        public string Numero { get; set; }

        [SwaggerSchema("Complemento, se presente")]
        public string Complemento { get; set; }

        [Required]
        public string Bairro { get; set; }
       
        [Required]
        public string Cidade { get; set; }

        [SwaggerSchema("Estado")]
        [Required]
        public string Uf { get; set; }
        
        [Required]       
        public SituacaoEnum situacao { get; set; }
       
        [Required]
        public TipoCestaEnum  tipoCesta { get; set; }
    }

}
