using Consul;
using Destiny.Core.Flow.ConsulEntity;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Modules;
using Destiny.Core.Flow.Network;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Destiny.Core.Flow.Consul
{
    /// <summary>
    /// Consul服务发现模块
    /// </summary>
    public abstract class DestinyConsulModule : AppModule
    {
        /// <summary>
        /// 服务地址
        /// </summaryabababz
        private string _serviceName = string.Empty;
        /// <summary>
        /// Consul服务地址
        /// </summary>
        private string _consulIp = string.Empty;
        /// <summary>
        /// Consul服务端口
        /// </summary>
        private int _consulPort = 80;
        /// <summary>
        /// docker容器内部端口
        /// </summary>
        private int _prot = 80;
        /// <summary>
        /// 获取配置文件
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        /// 
        public override void ConfigureServices(ConfigureServicesContext context)
        {
            IConfiguration configuration = context.Services.GetConfiguration();
            _consulIp = configuration["Consul:IP"];
            _consulPort = /*Convert.ToInt32(configuration["Consul:Port"])*/configuration["Consul:Port"].AsTo<Int32>();
            _prot = /*Convert.ToInt32(configuration["Service:Port"])*/configuration["Service:Port"].AsTo<Int32>();
            _serviceName = configuration["Service:Name"];
        }


        /// <summary>
        /// 注册Consul
        /// </summary>
        /// <param name="context"></param>
        public override void ApplicationInitialization(ApplicationContext context)
        {
            var app = context.GetApplicationBuilder();
            ServiceEntity serviceEntity = new ServiceEntity
            {
                IP = NetworkHelper.LocalIPAddress,
                Port = _prot,//如果使用的是docker 进行部署这个需要和dockerfile中的端口保证一致
                ServiceName = _serviceName,
                ConsulIP = _consulIp,
                ConsulPort = _consulPort
            };
            var consulClient = new ConsulClient(x => x.Address = new Uri($"http://{serviceEntity.ConsulIP}:{serviceEntity.ConsulPort}"));//请求注册的 Consul 地址
            var httpCheck = new AgentServiceCheck()
            {
                DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),//服务启动多久后注册
                Interval = TimeSpan.FromSeconds(10),//健康检查时间间隔，或者称为心跳间隔
                HTTP = $"http://{serviceEntity.IP}:{serviceEntity.Port}/api/health",//健康检查地址
                Timeout = TimeSpan.FromSeconds(1)
            };
            Console.WriteLine($"我是服务IP和端口：{serviceEntity.IP}:{serviceEntity.Port}");
            // Register service with consul
            var registration = new AgentServiceRegistration()
            {
                Checks = new[] { httpCheck },
                ID = Guid.NewGuid().ToString(),
                Name = serviceEntity.ServiceName,
                Address = serviceEntity.IP,
                Port = serviceEntity.Port,
                Tags = new[] { $"urlprefix-/{serviceEntity.ServiceName}" }//添加 urlprefix-/servicename 格式的 tag 标签，以便 Fabio 识别
            };
            consulClient.Agent.ServiceRegister(registration).Wait();//服务启动时注册，内部实现其实就是使用 Consul API 进行注册（HttpClient发起）
            var lifetime = context.ServiceProvider.GetRequiredService<IHostApplicationLifetime>();
            lifetime.ApplicationStopping.Register(() =>
            {
                consulClient.Agent.ServiceDeregister(registration.ID).Wait();//服务停止时取消注册
            });
        }


    }
}
