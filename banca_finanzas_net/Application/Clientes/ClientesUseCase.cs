﻿using banca_finanzas_net.Application.Abstractions;
using banca_finanzas_net.Application.CajaAhorros;
using banca_finanzas_net.Domain.Abstractions;
using banca_finanzas_net.Domain.CajaAhorros;
using banca_finanzas_net.Domain.Clientes;
using banca_finanzas_net.Domain.CuentasCorrientes;
using banca_finanzas_net.Domain.PlazosFijos;

namespace banca_finanzas_net.Application.Clientes;

public class ClientesUseCase : ICRUDUsesCases
    <
        ClientesResponse,
        ClientesAddRequest,
        ClientesDeleteRequest,
        ClientesUpdateRequest
    >
{
    private readonly ICRUD<Cliente> _cliente;
    private readonly ICRUD<CajaAhorro> _cajaAhorro;
    private readonly ICajaAhorro _cajaAhorroCliente;
    private readonly ICRUD<CuentaCorriente> _cuentaCorriente;
    private readonly ICuentaCorriente _cuentaCorrienteCliente;
    private readonly ICRUD<PlazoFijo> _plazoFijo;

    public ClientesUseCase(
        ICRUD<Cliente> cliente, 
        ICRUD<CajaAhorro> cajaAhorro,
        ICajaAhorro cajaAhorroCliente,
        ICRUD<CuentaCorriente> cuentaCorriente,
        ICuentaCorriente cuentaCorrienteCliente,
        ICRUD<PlazoFijo> plazoFijo
    )
    {
        _cliente = cliente;
        _cajaAhorro = cajaAhorro;
        _cajaAhorroCliente = cajaAhorroCliente;
        _cuentaCorriente = cuentaCorriente;
        _cuentaCorrienteCliente = cuentaCorrienteCliente;
        _plazoFijo = plazoFijo;
    }

    public IEnumerable<ClientesResponse> GetAll()
    {
        var lstClientes = new List<ClientesResponse>();        
        var clientes = _cliente.GetList();        

        var cuentaCorriente = new CuentaCorriente();
        var plazoFijo = new PlazoFijo();

        if (clientes == null)
            return lstClientes;

        foreach (Cliente cliente in clientes)
        {
            // *******************************************************************************
            // *** Caja de Ahorro 
            // *******************************************************************************
            var lstCajaAhorro = new List<CajaAhorrosResponse>();
            var cajaAhorro = _cajaAhorroCliente.GetClientesMovsByID(cliente.Cliente_Id);
            if (cajaAhorro != null)
            {
                var debe = _cajaAhorroCliente.GetClientesMovsByID(cliente.Cliente_Id).Sum(x => x.Debe);
                var haber = _cajaAhorroCliente.GetClientesMovsByID(cliente.Cliente_Id).Sum(x => x.Haber);
                var saldo = debe - haber;

                foreach (CajaAhorro caja in cajaAhorro)
                {
                    lstCajaAhorro.Add(
                        new CajaAhorrosResponse()
                        {
                            Caja_Ahorro_UUID = caja.Caja_Ahorro_UUID,
                            Movimiento = caja.Movimiento,
                            Debe = caja.Debe,
                            Haber = caja.Haber,
                            Saldo = saldo
                        }
                    );
                }
            }
            else 
            {
                cajaAhorro = null; 
            }
            // *******************************************************************************

            // *******************************************************************************
            // *** Cuenta Corriente
            // *******************************************************************************

            // *******************************************************************************

            // *******************************************************************************
            // *** Plazo Fijo
            plazoFijo = _plazoFijo.GetList().SingleOrDefault(x => x.Cliente_Id == cliente.Cliente_Id);
            // *******************************************************************************

            lstClientes.Add(
                new ClientesResponse()
                { 
                    Cliente_UUID = cliente.Cliente_UUID, 
                    Nombres = cliente.Nombres, 
                    Apellidos = cliente.Apellidos, 
                    Email = cliente.Email, 
                    Active = cliente.Active, 
                    CajaAhorros = lstCajaAhorro, 
                    CuentasCorrientes = null, 
                    PlazosFijos = plazoFijo != null ? new PlazosFijos.PlazosFijosResponse() 
                    {                         
                        Plazofijo_UUID = plazoFijo!.Plazofijo_UUID, 
                        Nrocuenta = plazoFijo.Nrocuenta, 
                        Monto = plazoFijo.Monto, 
                        Plazo = plazoFijo.Plazo!.GetPlazo(), 
                        Interes = plazoFijo.Interes,
                        TNA = plazoFijo.Interes * 12, // TNA %
                        Capital = plazoFijo.Capital!.GetCapital(), 
                        Fecha_Inicio = plazoFijo.Fecha_Inicio, 
                        Fecha_Vencimiento = plazoFijo.Fecha_Vencimiento!.GetFechaVencimiento(), 
                        Active = plazoFijo.Active 
                    } : null                     
                }
            );            
        }
        
        return lstClientes;
    }

    public ClientesResponse GetByIb(int id)
    {
        throw new NotImplementedException();
    }

    public ClientesResponse GetByUUID(Guid guid)
    {
        return GetAll().SingleOrDefault(x => x.Cliente_UUID == guid)!; 
    }

    public Task<int> Add(ClientesAddRequest entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<int> Delete(ClientesDeleteRequest entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<int> Update(ClientesUpdateRequest entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
