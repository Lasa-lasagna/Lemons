using Microsoft.Extensions.DependencyInjection;
using MyProject.Data;
using MyProject.Repository;
using MyProject.Repository.Impl;
using MyProject.Services;
using MyProject.UI;

namespace MyProject.Injection;

public static class DInject
{
    public static ServiceProvider Configure()
    {
        var services = new ServiceCollection();

        //Aqui registrare las dependencias



        services.AddDbContext<AppDbContext>();
        //Si alguien me pide IUsuario (Interfaz) le doy un UsuarioRepo
        services.AddTransient<IUsuarioRepository,UsuarioRepository>();
        services.AddTransient<ICuentaRepository,CuentaRepository>();
        services.AddTransient<IMovimientoRepository,MovimientoRepository>();


        //Si alguien pide App, se lo doy;
        services.AddTransient<App>();
        services.AddTransient<Transaction>();
        services.AddTransient<Login>();
        services.AddTransient<Menu>();
        services.AddTransient<AuthService>();


        return  services.BuildServiceProvider();
    }
}