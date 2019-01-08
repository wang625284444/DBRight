using System;
using System.Collections.Generic;
using System.Text;

namespace DB.Entity.Enum
{
    public sealed class WorkflowEnum
    {
        public enum WorkflowStatus
        {
            /// <summary>
            /// 待审核
            /// </summary>
            ApprovalToBeAudited = 0,
            /// <summary>
            /// 审批通过
            /// </summary>
            ApprovalAndApproval = 100,
            /// <summary>
            /// 审批拒绝
            /// </summary>
            ApprovalRejection = 200,
        }
    }
}
