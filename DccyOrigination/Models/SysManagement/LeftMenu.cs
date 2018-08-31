using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DccyOrigination.Models.SysManagement
{
    public class LeftMenu : AdmModel
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName { get; set; }
        /// <summary>
        ///  导航路径
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// css样式
        /// </summary>
        public string MenuStyle { get; set; }
        /// <summary>
        /// 所属角色
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// 所属部门
        /// </summary>
        public int DepId { get; set; }
        /// <summary>
        /// 是否须要授权  ，不需可任何人都可访问
        /// </summary>
        public bool IsAuthorization { get; set; }
        /// <summary>
        /// 是否展开
        /// </summary>
        public bool IsOpen { get; set; }
        /// <summary>
        /// 是否有子菜单
        /// </summary>
        public bool IsChildren { get; set; }
        /// <summary>
        /// 子菜单集合
        /// </summary>
        public List<LeftMenu> Children { get; set; }
    }
}
