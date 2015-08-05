using CatalogAPI.Model;
using CatalogSDK.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CatalogAPI
{
    public class ManagementPacksController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<CatalogItem> Get()
        {
            IList<CatalogItem> catalogItems = new List<CatalogItem>();
            //return new CatalogItem[] { new CatalogItem() { Id=1, Description = "SQL", DownloadURL = "http://downloadme", DisplayName = "SQLServer" }, new CatalogItem() { Description = "dotnet", DownloadURL = "http://downloadme", DisplayName = ".NET" } };
            using (SCOM_MPCatalogEntities db = new SCOM_MPCatalogEntities())
            {
                
                foreach( CatalogEntity dbEntity in  db.CatalogEntities)
                {
                    catalogItems.Add(new CatalogItem() {  Id=dbEntity.CatalogEntityId, DisplayName=dbEntity.DisplayName, DownloadURL=dbEntity.DownloadURL, Description= dbEntity.Description, SystemName=dbEntity.SystemName});
                }

            }
            return catalogItems;
        }

        public IEnumerable<CatalogItem> Get(string pattern)
        {
            IList<CatalogItem> catalogItems = new List<CatalogItem>();
            //return new CatalogItem[] { new CatalogItem() { Id=1, Description = "SQL", DownloadURL = "http://downloadme", DisplayName = "SQLServer" }, new CatalogItem() { Description = "dotnet", DownloadURL = "http://downloadme", DisplayName = ".NET" } };
            using (SCOM_MPCatalogEntities db = new SCOM_MPCatalogEntities())
            {
                
                foreach (CatalogEntity dbEntity in db.CatalogEntities.Where(x=>x.DisplayName.StartsWith(pattern)))
                {
                    
                    catalogItems.Add(new CatalogItem() { Id = dbEntity.CatalogEntityId, DisplayName = dbEntity.DisplayName, DownloadURL = dbEntity.DownloadURL, Description = dbEntity.Description, SystemName = dbEntity.SystemName });
                }

            }
            return catalogItems;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

       
    }
}