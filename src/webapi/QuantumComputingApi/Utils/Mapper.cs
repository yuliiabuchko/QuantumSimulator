using System;
using System.Threading.Tasks;
using QuantumComputingApi.Daos;
using QuantumComputingApi.Dtos;
using System.Collections.Generic;
using System.Linq;
using QuantumComputingApi.Dtos.Deserializers;
using QuantumComputingApi.Dtos.Producer;
using QuantumComputingApi.Dtos.Serializers;
using System.Numerics;

namespace QuantumComputingApi.Utils {
    public class Mapper {

        private readonly DtoProducerBase _producer;

        public Mapper(DtoProducerBase producer) {
            _producer = producer;
        }

        public ICircuitDto MapCircuitToDto(CircuitDao circuitDao) {
            var circuitDto = _producer.ProduceCircuitDto();

            circuitDto.Elements = circuitDao.Elements.Select(elem => mapElemToDto(elem));
            circuitDto.Connections = circuitDao.Connections.Select(conn => mapConnectionToDto(conn));

            return circuitDto;
        }

        public CircuitDao MapCircuitToDao(ICircuitDto circuitDto) {
            return new CircuitDao() {
                Elements = circuitDto.Elements.Select(elem => mapElementToDao(elem)),
                Connections = circuitDto.Connections.Select(conn => mapConnectionToDao(conn))
            };
        }

        private IConnectionDto mapConnectionToDto(ConnectionDao dao) {
            var dto = _producer.ProduceConnectionDto();

            dto.IdLeft = dao.IdLeft;
            dto.IdRight = dao.IdRight;
            dto.LeftEntries = dao.LeftEntries;
            dto.RightEntries = dao.RightEntries;

            return dto;
        }

        private ICircuitElementDto mapElemToDto(CircuitElementDao dao) {

            ICircuitElementDto dto = null;

            if(dao.Type == "register"){
                dto = _producer.ProduceRegisterDto();
                ((IRegisterDto)dto).Qubits = ((RegisterDao)dao).Qubits.Select(dao => mapQubitToDto(dao));
            } else if(dao.Type == "gate") {
                dto = _producer.ProduceGateDto();
                ((IGageDto)dto).GateName = ((GateDao)dao).GateName;
            }

            dto.Type = dao.Type;
            dto.Id = dao.Id;
            dto.InputCount = dao.InputCount;
            dto.OutputCount = dao.OutputCount;

            return dto;
        }

        private IQubitDto mapQubitToDto(QubitDao dao) {
            var dto = _producer.ProduceQubitDto();
            var oneAmplitude = _producer.ProduceComplexDto();
            var zeroAmplitude = _producer.ProduceComplexDto();

            oneAmplitude.Real = dao.OneAmplitude.Real;
            oneAmplitude.Imaginary = dao.OneAmplitude.Imaginary;

            zeroAmplitude.Real = dao.ZeroAmplitude.Real;
            zeroAmplitude.Imaginary = dao.ZeroAmplitude.Imaginary;

            dto.OneAmplitude = oneAmplitude;
            dto.ZeroAmplitude = zeroAmplitude;
        
            return dto;
        }

        private ConnectionDao mapConnectionToDao(IConnectionDto dto) {
            return new ConnectionDao() {
                IdLeft = dto.IdLeft,
                IdRight = dto.IdRight,
                LeftEntries = dto.LeftEntries,
                RightEntries = dto.RightEntries
            };
        }

        private CircuitElementDao mapElementToDao (ICircuitElementDto dto) {
            CircuitElementDao dao = null;
            if(dto.Type == "register") {
                dao = new RegisterDao() {
                    Qubits = ((IRegisterDto)dto).Qubits.Select(qubit => mapQubitToDao(qubit))
                };
            }else if(dto.Type == "gate") {
                dao = new GateDao() {
                    GateName = ((IGageDto)dto).GateName
                };
            }

            dao.Type = dto.Type;
            dao.Id = dto.Id;
            dao.InputCount = dto.InputCount;
            dao.OutputCount = dto.OutputCount;
            
            return dao;
        }

        private QubitDao mapQubitToDao(IQubitDto dto) {
            return new QubitDao() {
                OneAmplitude = new ComplexDao() {
                    Real = dto.OneAmplitude.Real,
                    Imaginary = dto.OneAmplitude.Imaginary
                },
                ZeroAmplitude = new ComplexDao() {
                    Real = dto.ZeroAmplitude.Real,
                    Imaginary = dto.ZeroAmplitude.Imaginary
                }
            };
        }
    }
}