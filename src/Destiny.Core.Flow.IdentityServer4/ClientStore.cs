using System;
using System.Threading.Tasks;
using Destiny.Core.Flow.IdentityServer;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Destiny.Core.Flow.IdentityServer
{
    /// <summary>
    /// 客户端存储
    /// </summary>
    public  class ClientStore : IClientStore
    {
        protected IClientRepository ClientRepository { get; }


        public async Task<IdentityServer4.Models.Client> FindClientByIdAsync(string clientId)
        {
             return await ClientRepository.FindByCliendIdAsync(clientId);
        }

    }
}
