using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DB.Entity.Enum
{
    public sealed class WorkflowEnum
    {
        public enum WorkflowStatus
        {
            /// <summary>
            /// 未提交
            /// </summary>
            ApprovalNotSubmitted = 0,
            /// <summary>
            /// 待审核
            /// </summary>
            ApprovalToBeAudited = 100,
            /// <summary>
            /// 审批通过
            /// </summary>
            ApprovalAndApproval = 200,
            /// <summary>
            /// 审批拒绝
            /// </summary>
            ApprovalRejection = 300,

        }
    }
}
