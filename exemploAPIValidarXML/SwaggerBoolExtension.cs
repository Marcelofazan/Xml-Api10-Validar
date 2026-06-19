using Microsoft.OpenApi;

namespace exemploAPIValidarXML
{
    public class SwaggerBoolExtension : IOpenApiExtension
    {
        private readonly bool _value;

        public SwaggerBoolExtension(bool value)
        {
            _value = value;
        }

        public void Write(IOpenApiWriter writer, OpenApiSpecVersion specVersion)
        {
            writer.WriteValue(_value);
        }
    }
}