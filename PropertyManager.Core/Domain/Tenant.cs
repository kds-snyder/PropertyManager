using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyManager.Core.Model;

namespace PropertyManager.Core.Domain
{
    public class Tenant
    {
        public Tenant()
        {
            Leases = new HashSet<Lease>();
        }

        public int TenantId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string EmailAddress { get; set; }

        public virtual ICollection<Lease> Leases { get; set; }

        public void Update(TenantModel tenant)
        {
            throw new NotImplementedException();
        }
    }
}
