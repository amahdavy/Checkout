using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Checkout.Core.Models.Common
{
    /// <summary>
    /// Base entity, use for our entity that saves on DB
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Identity value for tables
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Creation date and time for object
        /// </summary>
        public DateTime InsertDate { get; set; }

        /// <summary>
        /// last modify date
        /// </summary>
        public DateTime? ModifyDate { get; set; }

        /// <summary>
        /// using for concurrency. set with SQL.
        /// </summary>
        [Timestamp]
        public Byte[] TimeStamp { get; set; }
       
        public BaseEntity()
        {
            this.InsertDate = DateTime.Now;
        }
    }
}
