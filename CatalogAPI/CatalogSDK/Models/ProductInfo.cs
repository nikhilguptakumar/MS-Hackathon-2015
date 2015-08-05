using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatalogAPI.Model
{
    /// <summary>
    /// This class stores the product info of the product making the call to the web service.
    /// </summary>
    public class ProductInfo
    {
        /// <summary>
        /// This field stores the product name 
        /// </summary>
        private string productName;

        /// <summary>
        /// This field stores the product version
        /// </summary>
        private string productVersion;

        /// <summary>
        /// Gets or sets the product name
        /// </summary>
        public string ProductName
        {
            get { return this.productName; }
            set { this.productName = value; }
        }

        /// <summary>
        /// Gets or sets the product version
        /// </summary>
        public string ProductVersion
        {
            get { return this.productVersion; }
            set { this.productVersion = value; }
        }
    }
}