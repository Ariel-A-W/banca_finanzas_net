﻿namespace banca_finanzas_net.Application.Abstractions;

public interface ICRUDUsesCases
    <
        TResponse, TRequestAdd, TRequestDelete, TRequestUpdate
    >
    where TResponse : class 
    where TRequestAdd : TResponse
    where TRequestDelete : TResponse
    where TRequestUpdate : TResponse
{
    public IEnumerable<TResponse> GetAll();
    public TResponse GetByIb(int id);
    public TResponse GetByUUID(Guid guid);
    public Task<int> Add(TRequestAdd entity, CancellationToken cancellationToken);
    public Task<int> Delete(TRequestDelete entity, CancellationToken cancellationToken);
    public Task<int> Update(TRequestUpdate entity, CancellationToken cancellationToken);
}
