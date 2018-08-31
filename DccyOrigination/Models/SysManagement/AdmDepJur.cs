using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DccyOrigination.Models.SysManagement
{
    /// <summary>
    /// 部门权限 
    /// </summary>
    [Table("admDepJur")]
    public class AdmDepJur :AdmRelationModel
    {
        public int DepId { get; set; }
        public int JurId { get; set; }
    }
}
