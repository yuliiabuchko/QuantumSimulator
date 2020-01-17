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

        private readonly IDtoSerializer<ICirquitElementDto, IConnectionDto, ICirquitDto<ICirquitElementDto, IConnectionDto>> _dtoSerializer;
        public DtoOutputFormatter(IDtoProducer<ICirquitElementDto, IConnectionDto, ICirquitDto<ICirquitElementDto, IConnectionDto>> dtoProducer) {
            _dtoSerializer = dtoProducer.ProduceDtoSerializer();

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

            if (context.Object is ICirquitDto<ICirquitElementDto, IConnectionDto>) {
                var cirquit = context.Object as ICirquitDto<ICirquitElementDto, IConnectionDto>;

                serialized = await _dtoSerializer.SerializeToText(cirquit);
            }
            await response.WriteAsync(serialized);
        }
    }
}