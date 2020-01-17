using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using QuantumComputingApi.Dtos;
using QuantumComputingApi.Dtos.Serializers;
using QuantumComputingApi.Dtos.Producer;

namespace QuantumComputingApi.Formatters {
    public class DtoOutputFormatter : TextOutputFormatter {

        private readonly IDtoSerializer _dtoSerializer;
        public DtoOutputFormatter(DtoProducerBase dtoProducer) {
            _dtoSerializer = dtoProducer.ProduceDtoSerializer()

            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/json"));
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/json"));

            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanWriteType(Type type) {
            if (typeof(ICirquitDto).IsAssignableFrom(type)) {
                return base.CanWriteType(type);
            }
            return false;
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding) {
            var response = context.HttpContext.Response;
            var serialized = "";

            if (context.Object is ICirquitDto) {
                var contact = context.Object as ICirquitDto;
                serialized = 
            }
            await response.WriteAsync(buffer.ToString());
        }
    }
}