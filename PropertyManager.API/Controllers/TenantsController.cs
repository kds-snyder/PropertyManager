﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PropertyManager.Core;
using PropertyManager.Core.Domain;
using AutoMapper;
using PropertyManager.Core.Model;

namespace PropertyManager.API.Controllers
{
    public class TenantsController : ApiController
    {
        private PropertyManagerContext db = new PropertyManagerContext();

        // GET: api/Tenants
        public IEnumerable<TenantModel> GetTenants()
        {
            return Mapper.Map<IEnumerable<TenantModel>>(db.Tenants);
        }

        // GET: api/Tenants/5
        [ResponseType(typeof(TenantModel))]
        public IHttpActionResult GetTenant(int id)
        {
            TenantModel tenant = Mapper.Map<TenantModel>(db.Tenants.Find(id));

            if (tenant == null)
            {
                return NotFound();
            }

            return Ok(tenant);
        }

        // PUT: api/Tenants/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTenant(int id, TenantModel tenant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tenant.TenantId)
            {
                return BadRequest();
            }

            var dbTenant = db.Tenants.Find(id);

            dbTenant.Update(tenant);

            db.Entry(dbTenant).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TenantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Tenants
        [ResponseType(typeof(TenantModel))]
        public IHttpActionResult PostTenant(TenantModel tenant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbTenant = new Tenant();

            dbTenant.Update(tenant);

            db.Tenants.Add(dbTenant);
            db.SaveChanges();

            tenant = Mapper.Map<TenantModel>(dbTenant);

            return CreatedAtRoute("DefaultApi", new { id = tenant.TenantId }, tenant);
        }

        // DELETE: api/Tenants/5
        [ResponseType(typeof(TenantModel))]
        public IHttpActionResult DeleteTenant(int id)
        {
            Tenant tenant = db.Tenants.Find(id);
            if (tenant == null)
            {
                return NotFound();
            }

            db.Tenants.Remove(tenant);
            db.SaveChanges();

            return Ok(Mapper.Map<TenantModel>(tenant));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TenantExists(int id)
        {
            return db.Tenants.Count(e => e.TenantId == id) > 0;
        }
    }
}