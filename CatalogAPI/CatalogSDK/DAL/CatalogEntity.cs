//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CatalogSDK.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class CatalogEntity
    {
        public int CatalogEntityId { get; set; }
        public string Type { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string PublishedInd { get; set; }
        public string GUID { get; set; }
        public string Version { get; set; }
        public string SystemName { get; set; }
        public string PublicKey { get; set; }
        public string ReleaseDate { get; set; }
        public string DownloadURL { get; set; }
        public Nullable<int> ParentEntityID { get; set; }
        public string FamilyId { get; set; }
    }
}