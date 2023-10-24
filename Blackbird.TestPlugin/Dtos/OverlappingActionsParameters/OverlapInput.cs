using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPlugin.Dtos.OverlappingActionsParameters
{
    public class OverlapInput
    {
        public string? UserId { get; set; }
        public string? TenantId { get; set; }
        public string? WorkspaceId { get; set; }
    }
}
