using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DccyOrigination.Models.SysManagement
{
    [Table("admJurisdiction")]
    public class AdmJurisdiction  :AdmModel
    {
        /// <summary>
        ///   权限名
        /// </summary>
        public string JurName { get; set; }
    }
}
