using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DccyOrigination.Models.SysManagement
{
    /// <summary>
    /// 用户权限表
    /// </summary>
    [Table("admUserJur")]
    public class AdmUserJurisdiction:AdmRelationModel
    {  
        /// <summary>
        /// 用户id
        /// </summary>
        public  int AdmUserId { get; set; }
        /// <summary>
        /// 权限id
        /// </summary>
        public  int AdmJurisdictionId { get; set; }
    }
}
