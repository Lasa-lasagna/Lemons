using MyProject.Entities;

namespace MyProject.Repository;

interface IMovimientoRepository
{
    bool MoveMoney(Cuenta tramiteWho, decimal monto, Cuenta tramiteTo);

    List<Movimiento>? MyListMove(int idUSer);


}