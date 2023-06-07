using Confluent.Kafka;
using MassTransit;
using MassTransit.KafkaIntegration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace N5.PermissionsManager.API.Configurations
{
    public static class KafkaConfiguration
    {
        public static void ConfigureKafka(this IServiceCollection services) 
        {
            services.AddMassTransit(x =>
            {
                x.UsingInMemory();
                x.AddRider(x => 
                {
                    x.UsingKafka((context, cfg) =>
                    {
                        cfg.Host("localhost", h =>
                        {
                            h.UseSasl(s =>
                            {
                                s.SecurityProtocol = SecurityProtocol.SaslSsl;
                                s.Mechanism = SaslMechanism.Plain;
                                s.Username = "";
                                s.Password = "";
                            });
                            
                        });
                    });
                });
                
            });
        }
    }
}
