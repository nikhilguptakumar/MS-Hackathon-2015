using CatalogAPI.Model;
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
            return new CatalogItem[] { new CatalogItem() { Id=1, Description = "SQL", DownloadURL = "http://downloadme", DisplayName = "SQLServer" }, new CatalogItem() { Description = "dotnet", DownloadURL = "http://downloadme", DisplayName = ".NET" } };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

       
    }
}