using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using QuantumComputingApi.Dtos;
using QuantumComputingApi.Dtos.Serializers;

namespace QuantumComputingApi.Dtos.Formatters {
    public class DtoOutputFormatter<T, U, Z> : TextOutputFormatter
    where T : ICirquitElementDto
    where U : IConnectionDto
    where Z : class, ICirquitDto<T, U> {

        private readonly IDtoSerializer<T, U, Z> _dtoSerializer;
        public DtoOutputFormatter(IDtoSerializer<T, U, Z> dtoSerializer) {
            _dtoSerializer = dtoSerializer;

            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/json"));
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/json"));

            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanWriteType(Type type) {
            if (typeof(ICirquitDto<ICirquitElementDto, IConnectionDto>).IsAssignableFrom(type)) {
                return base.CanWriteType(type);
            }
            return false;
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding) {
            var response = context.HttpContext.Response;
            var serialized = "";

            if (context.Object is Z) {
                var cirquit = context.Object as Z;

                serialized = await _dtoSerializer.SerializeToText(cirquit);
            }
            await response.WriteAsync(serialized);
        }
    }
}