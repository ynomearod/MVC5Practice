using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5.Models
{   
	public  class ClientRepository : EFRepository<Client>, IClientRepository
	{
        public override IQueryable<Client> All()
        {
            return base.All().Where(p => p.IsDelete == false);
        }

        public Client Find(int id)
        {
            return this.All().FirstOrDefault(p => p.OccupationId == id);
        }
	}

	public  interface IClientRepository : IRepository<Client>
	{

	}
}