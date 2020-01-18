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
    public class CirquitServiceImpl : ICirquitService {
        private readonly ICirquitRepository _cirquitRepository;
        private readonly Mapper _mapper;

        public CirquitServiceImpl(ICirquitRepository repository, Mapper mapper) {
            _cirquitRepository = repository;
            _mapper = mapper;
        }

        public async Task<ICirquitDto<ICirquitElementDto, IConnectionDto>> CreateCirquitHandler(ICirquitDto<ICirquitElementDto, IConnectionDto> cirquitDto) {
            var dao = _mapper.MapCirquitToDao(cirquitDto);
            var created = await _cirquitRepository.CreateCirquit(dao);
            if(created == null) {
                throw new ApplicationException("Error while trying to create resource"){};
            }

            return _mapper.MapCirquitToDto(created);
        }

        public async Task DeleteCirquitHandler(Guid Id) {
            var deleted = await _cirquitRepository.DeleteCirquit(Id);
            if(deleted == null) {
                throw new ApplicationException("Error while trying to delete resource"){};
            }
        }

        public Task<ICirquitResultDto> ExecuteCirquitHandler(Guid Id) {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ICirquitDto<ICirquitElementDto, IConnectionDto>>> GetAllCirquitsHandler() {
            return (await _cirquitRepository.FindAllCirquits()).Select(dao => _mapper.MapCirquitToDto(dao));
        }

        public async Task<ICirquitDto<ICirquitElementDto, IConnectionDto>> GetCirquitHandler(Guid Id) {
        var found = await _cirquitRepository.FindCirquit(Id);

            if(found == null) {
                throw new ApplicationException("Error while trying to get resource"){};
            }

            return _mapper.MapCirquitToDto(found);
        }

        public async Task<ICirquitDto<ICirquitElementDto, IConnectionDto>> UpdateCirquitHandler(Guid Id, ICirquitDto<ICirquitElementDto, IConnectionDto> cirquitDto) {
            var found = await _cirquitRepository.FindCirquit(Id);
            if(found == null) {
                throw new ApplicationException("Error while trying to get resource"){};
            }

            var dao = _mapper.MapCirquitToDao(cirquitDto);
            var updated = await _cirquitRepository.UpdateCirquit(Id, dao);

            return _mapper.MapCirquitToDto(updated);
        }
    }
}