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
    public class CirquitService : ICirquitService {
        private readonly ICirquitRepository _cirquitRepository;
        private readonly Mapper _mapper;

        public CirquitService(ICirquitRepository repository, Mapper mapper) {
            _cirquitRepository = repository;
            _mapper = mapper;
        }

        public async Task<Guid?> CreateCirquitHandler(ICirquitDto<ICirquitElementDto, IConnectionDto> cirquitDto) {
            var dao = _mapper.MapCirquitToDao(cirquitDto);
            dao.Uuid = Guid.NewGuid();
            try{
                await _cirquitRepository.CreateCirquit(dao);
            }catch(Exception){
                return null;
            }
            return dao.Uuid;
        }

        public async Task<bool> DeleteCirquitHandler(Guid Uuid) {
            return await _cirquitRepository.DeleteCirquit(Uuid);
        }

        public async Task<IEnumerable<ICirquitDto<ICirquitElementDto, IConnectionDto>>> GetAllCirquitsHandler() {
            return (await _cirquitRepository.FindAllCirquits())?.Select(dao => _mapper.MapCirquitToDto(dao));
        }

        public async Task<ICirquitDto<ICirquitElementDto, IConnectionDto>> GetCirquitHandler(Guid Uuid) {
        var found = await _cirquitRepository.FindCirquit(Uuid);

            if(found == null) {
                return null;
            }else{
                return _mapper.MapCirquitToDto(found);
            }

        }

        public async Task<bool> UpdateCirquitHandler(Guid Uuid, ICirquitDto<ICirquitElementDto, IConnectionDto> cirquitDto) {
            var found = await _cirquitRepository.FindCirquit(Uuid);
            if(found == null) {
                return false;
            }

            var dao = _mapper.MapCirquitToDao(cirquitDto);
            return await _cirquitRepository.UpdateCirquit(Uuid, dao);
        }

        public Task<ICirquitResultDto<IQubitDto, IRegisterDto<IQubitDto>>> ExecuteCirquitHandler(Guid Uuid) {
            throw new NotImplementedException();
        }
    }
}