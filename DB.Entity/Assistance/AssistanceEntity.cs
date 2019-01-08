﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DB.Entity.Assistance
{
    public abstract class AssistanceEntity : WorkflowEntity
    {
        /// <summary>
        /// 数据状态
        /// </summary>
        public bool IsStatus { get; set; }
        /// <summary>
        /// 创建时间/只读
        /// </summary>
        public DateTime CreationTime { get; private set; } = DateTime.Now;
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreationUser { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
