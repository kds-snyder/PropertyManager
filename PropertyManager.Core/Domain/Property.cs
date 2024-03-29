﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyManager.Core.Model;

namespace PropertyManager.Core.Domain
{
    public class Property
    {
        public Property()
        {
            Leases = new HashSet<Lease>();
        }
        
        public int PropertyId { get; set; }

        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public virtual ICollection<Lease> Leases { get; set; }

        public void Update(PropertyModel property)
        {
            Name = property.Name;
            Address1 = property.Address1;
            Address2 = property.Address2;
            City = property.City;
            State = property.State;
            Zip = property.Zip;
        }
    }
}
