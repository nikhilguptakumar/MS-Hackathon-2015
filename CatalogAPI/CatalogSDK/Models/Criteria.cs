using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatalogAPI.Model
{
    /// <summary>
    /// This class is used to represent the criterias that can be used to filter ManagementPacks.
    /// </summary>
    public class SearchCriteria
    {
        /// <summary>
        /// This field stores the management pack name search pattern
        /// </summary>
        private string managementPackNamePattern;

       

        /// <summary>
        /// This field is used to filter management packs based on release date.
        /// Only management packs released after this date are displayed to the customers.
        /// </summary>
        private DateTime releasedOnOrAfter;

        /// <summary>
        /// This field stores the list of installed management packs.
        /// Used only to check the updates available for a list of management packs installed on customer's machine.
        /// </summary>
       // private Collection<CatalogManagementPackIdentity> installedManagementPacks;

        /// <summary>
        /// Initializes a new instance of the CatalogManagementPackSearchCriteria class.
        /// </summary>
       // public Criteria()
        //{
            //this.installedManagementPacks = new Collection<CatalogManagementPackIdentity>();
       // }

        /// <summary>
        /// Gets or sets the management pack name pattern
        /// </summary>
        public string ManagementPackNamePattern
        {
            get { return this.managementPackNamePattern; }
            set { this.managementPackNamePattern = value; }
        }

       

        /// <summary>
        /// Gets or sets the released on or after date
        /// </summary>
        public DateTime ReleasedOnOrAfter
        {
            get { return this.releasedOnOrAfter; }
            set { this.releasedOnOrAfter = value; }
        }

        
    }
}