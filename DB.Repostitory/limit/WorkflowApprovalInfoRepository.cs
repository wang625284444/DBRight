using DB.Entity;
using DB.Entity.Workflow;
using DB.IRepository.limit;

namespace DB.Repostitory.limit
{
    public class WorkflowApprovalInfoRepository : BaseRepository<WorkflowApprovalInfoEntity>, IWorkflowApprovalInfoRepository
    {
        public WorkflowApprovalInfoRepository(BaseDbContext Context) : base(Context)
        {
        }
    }
}
