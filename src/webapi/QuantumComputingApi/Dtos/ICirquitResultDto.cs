namespace QuantumComputingApi.Dtos {
    public interface ICirquitResultDto<T, U> 
    where T : IQubitDto
    where U : IRegisterDto<T>
    {
        U ResultingRegister { get; set; }
    }
}