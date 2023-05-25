using Swashbuckle.AspNetCore.Annotations;

namespace api_web_service_bma.Enum
{
    [SwaggerSchema("Situação do cadastrado no Sistema")]
    public enum SituacaoEnum
    {
        Ativo, 
        Inativo

    }
}
