using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using QuantumComputingApi.Dtos;
using QuantumComputingApi.Dtos.Deserializers;

namespace QuantumComputingApi.Dtos.Formatters {
    public class DtoInputFormatter<T,U, Z> : TextInputFormatter
        where T : ICirquitElementDto
        where U : IConnectionDto
        where Z : ICirquitDto<T, U> 
    {

        private readonly IDtoDeserializer<T,U,Z> _dtoDeserializer;
        public DtoInputFormatter(IDtoDeserializer<T, U, Z> dtoDeserializer) {
            _dtoDeserializer = dtoDeserializer;
            
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/json"));
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/json"));

            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanReadType(Type type) {

            if (type == typeof(ICirquitDto<ICirquitElementDto, IConnectionDto>) || type.IsSubclassOf(typeof(ICirquitDto<ICirquitElementDto, IConnectionDto>))) {
                return base.CanReadType(type);
            }
            return false;
        }

        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding effectiveEncoding) {
            if (context == null) {
                throw new ArgumentNullException(nameof(context));
            }

            if (effectiveEncoding == null) {
                throw new ArgumentNullException(nameof(effectiveEncoding));
            }

            var request = context.HttpContext.Request;

            using(var reader = new StreamReader(request.Body, effectiveEncoding)) {
                try {
                    var textJson = await reader.ReadToEndAsync();

                    var cirquit = _dtoDeserializer.DeserializeFromText(textJson);

                    return await InputFormatterResult.SuccessAsync(cirquit);
                } catch {
                    return await InputFormatterResult.FailureAsync();
                }
            }
        }

    }
}