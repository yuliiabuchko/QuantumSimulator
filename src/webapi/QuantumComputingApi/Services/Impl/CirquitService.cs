using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuantumComputingApi.Daos;
using QuantumComputingApi.Dtos;
using QuantumComputingApi.Dtos.Producer;
using QuantumComputingApi.Repositories;
using QuantumComputingApi.Utils;

namespace QuantumComputingApi.Services.Impl {
    public class CircuitService : ICircuitService {
        private readonly ICircuitRepository _circuitRepository;
        private readonly Mapper _mapper;
        private readonly DtoProducerBase _producer;

        public CircuitService(ICircuitRepository repository, Mapper mapper, DtoProducerBase producer) {
            _circuitRepository = repository;
            _mapper = mapper;
            _producer = producer;
        }

        public async Task<Guid?> CreateCircuitHandler(ICircuitDto circuitDto) {
            var dao = _mapper.MapCircuitToDao(circuitDto);
            dao.Uuid = Guid.NewGuid();
            try {
                await _circuitRepository.CreateCircuit(dao);
            } catch (Exception) {
                return null;
            }
            return dao.Uuid;
        }

        public async Task<bool> DeleteCircuitHandler(Guid Uuid) {
            return await _circuitRepository.DeleteCircuit(Uuid);
        }

        public async Task<IEnumerable<ICircuitDto>> GetAllCircuitsHandler() {
            return (await _circuitRepository.FindAllCircuits())?.Select(dao => _mapper.MapCircuitToDto(dao));
        }

        public async Task<ICircuitDto> GetCircuitHandler(Guid Uuid) {
            var found = await _circuitRepository.FindCircuit(Uuid);

            if (found == null) {
                return null;
            } else {
                return _mapper.MapCircuitToDto(found);
            }

        }

        public async Task<bool> UpdateCircuitHandler(Guid Uuid, ICircuitDto circuitDto) {
            var found = await _circuitRepository.FindCircuit(Uuid);
            if (found == null) {
                return false;
            }

            var dao = _mapper.MapCircuitToDao(circuitDto);
            return await _circuitRepository.UpdateCircuit(Uuid, dao);
        }

        public async Task<ICircuitResultDto> ExecuteCircuitHandler(Guid Uuid) {

            /*
                Here should be implemented the usage of the simulator library to execute quantum cirquit represented by 
                cirquitDao found in database. 
                The state of register in cirquit after executing of all quantum gates should be returned as result;
             */

            var circuitDao = await _circuitRepository.FindCircuit(Uuid);

            if (circuitDao == null) {
                return null;
            }

            //Todo: Here some operations to simulate circuit

            //temporarily return fake result
            var result = _producer.ProcudeCircuitResultDto();
            result.ResultingRegister = _producer.ProduceRegisterDto();
            result.ResultingRegister.Type = "register";
            result.ResultingRegister.InputCount = 0;
            result.ResultingRegister.OutputCount = 2;

            var firstCubit = _producer.ProduceQubitDto();
            var secondCubit = _producer.ProduceQubitDto();
            firstCubit.OneAmplitude = _producer.ProduceComplexDto();
            firstCubit.ZeroAmplitude = _producer.ProduceComplexDto();
            secondCubit.OneAmplitude = _producer.ProduceComplexDto();
            secondCubit.ZeroAmplitude = _producer.ProduceComplexDto();

            result.ResultingRegister.Qubits = new List<IQubitDto>() {
                firstCubit,
                secondCubit
            };

            return result;
        }
    }
}