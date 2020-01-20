using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QuantumComputingApi.Daos;
using QuantumComputingApi.Dtos;
using QuantumComputingApi.Dtos.Producer;
using QuantumComputingApi.Repositories;
using System.Linq;
using QuantumComputingApi.Utils;

namespace QuantumComputingApi.Services.Impl {
    public class CircuitService : ICircuitService {
        private readonly ICircuitRepository _circuitRepository;
        private readonly Mapper _mapper;

        public CircuitService(ICircuitRepository repository, Mapper mapper) {
            _circuitRepository = repository;
            _mapper = mapper;
        }

        public async Task<Guid?> CreateCircuitHandler(ICircuitDto circuitDto) {
            var dao = _mapper.MapCircuitToDao(circuitDto);
            dao.Uuid = Guid.NewGuid();
            try{
                await _circuitRepository.CreateCircuit(dao);
            }catch(Exception){
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

            if(found == null) {
                return null;
            }else{
                return _mapper.MapCircuitToDto(found);
            }

        }

        public async Task<bool> UpdateCircuitHandler(Guid Uuid, ICircuitDto circuitDto) {
            var found = await _circuitRepository.FindCircuit(Uuid);
            if(found == null) {
                return false;
            }

            var dao = _mapper.MapCircuitToDao(circuitDto);
            return await _circuitRepository.UpdateCircuit(Uuid, dao);
        }

        public Task<ICircuitResultDto> ExecuteCircuitHandler(Guid Uuid) {
            throw new NotImplementedException();
        }
    }
}