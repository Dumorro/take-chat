using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using Take.BatePapo.Aplicacao.Middlewares;
using Take.BatePapo.Aplicacao.Servicos;
using Take.BatePapo.Dominio.Entidades;
using Take.BatePapo.Dominio.Interfaces;

namespace Take.BatePapo.IoC
{
    public static class ConfiguradorDeIoC
    {
        public static void Configurar(IServiceCollection services)
        {
            services.AddSingleton<IBatePapo, SalaDeBatePapo>();        
            services.AddTransient<MotorDeEnvioDeMensagem>();
            services.AddTransient<IConsultaDeUsuariosDaSalaDeBatePapo, ConsultaDeUsuariosDaSalaDeBatePapo>();
        }
        public static IApplicationBuilder UsarGerenciadorDeSalaDeBatePapo(this IApplicationBuilder app, PathString caminho, IServiceProvider serviceProvider)
        {
            return app.Map(caminho, (sala) => sala.UseMiddleware<ChatWebSocketMiddleware>());
        }
    }
}
