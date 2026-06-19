using exemploAPIValidarXML.Services.XmlValidation.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace exemploAPIValidarXML.Controllers
{
    [ApiController]
    [Route("api")]
    [Description("Validação de XML")]
    public class XMLValidationController : Controller
    {
        //Interface do serviço que valida o arquivo XML e será injetado automaticamente em tempo de execução
        private readonly IXMLValidationService _XMLValidationService;

        public XMLValidationController(IXMLValidationService XMLValidationService)
        {
            _XMLValidationService = XMLValidationService;
        }

        [HttpPost("validarxml")]
        [Consumes("application/x-www-form-urlencoded", "multipart/form-data")]
        public async Task<string> Validar([FromForm] string strDocumento)
        {
            if (string.IsNullOrWhiteSpace(strDocumento))
            {
                return "O campo strDocumento é obrigatório.";
            }

            // SOLUÇÃO: Remove qualquer codificação de formulário (converte &lt; de volta para <)
            strDocumento = System.Net.WebUtility.HtmlDecode(strDocumento);

            // Dispara o seu serviço com o XML limpo
            var resultado = _XMLValidationService.XMLValidate(strDocumento);
            return resultado;
        }
    }
}
