using System.Collections.Generic;

namespace tc_dev.Core.Identity.Models
{
    public class AppIdentityResult
    {
        public IEnumerable<string> Errors { get; private set; }

        public bool Succeeded { get; private set; }

        public AppIdentityResult(IEnumerable<string> errors, bool succeeded)
        {
            Succeeded = succeeded;
            Errors = errors;
        }
    }
}
