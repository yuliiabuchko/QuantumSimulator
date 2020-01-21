using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using QuantumComputingApi.Dtos;
using QuantumComputingApi.Dtos.Serializers;

namespace QuantumComputingApi.Formatters {
    public class DtoOutputFormatter : TextOutputFormatter {

        private readonly IDtoSerializer _dtoSerializer;
        public DtoOutputFormatter(IDtoSerializer dtoSerializer) {
            _dtoSerializer = dtoSerializer;

            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/json"));
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/json"));

            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanWriteType(Type type) {
            if (typeof(ICircuitDto).IsAssignableFrom(type)) {
                return base.CanWriteType(type);
            }
            return false;
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding) {
            var response = context.HttpContext.Response;
            var serialized = "";

            if (context.Object is ICircuitDto) {
                var circuit = context.Object as ICircuitDto;

                serialized = await _dtoSerializer.SerializeToText(circuit);
            }
            await response.WriteAsync(serialized);
        }
    }
}