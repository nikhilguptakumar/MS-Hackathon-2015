using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatalogAPI.Model
{
    public class CatalogItem
    {
        public int Id { get; set; }
        public int Type { get; set; }

        public string Description { get; set; }
        public string DisplayName { get; set; }
        public string SystemName { get; set; }

        public string DownloadURL { get; set; }

        public int ParentId { get; set; }
    }
}