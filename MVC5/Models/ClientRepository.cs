using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5.Models
{   
	public  class ClientRepository : EFRepository<Client>, IClientRepository
	{
        public override IQueryable<Client> All()
        {
            return base.All().Where(p => p.IsDelete == false).OrderBy(p => p.ClientId);
        }

        public Client Find(int id)
        {
            return this.All().FirstOrDefault(p => p.OccupationId == id);
        }

        internal IQueryable<Client> SeachGender(string gender)
        {
            return this.All().Where(p => p.Gender == gender).Take(10);
        }

        internal IQueryable<Client> SeachCity(string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                return this.All();
            }
            else
            {
                return this.All().Where(p => p.City == city).Take(10);
            }
        }
	}

	public  interface IClientRepository : IRepository<Client>
	{

	}
}