using Swashbuckle.AspNetCore.Annotations;

namespace api_web_service_bma.Enum
{
    [SwaggerSchema("Tipo de cesta para retirada")]
    public enum TipoCestaEnum
    {
        VERDE,
        BASICA,
        BASICA_VERDE
    }
}
