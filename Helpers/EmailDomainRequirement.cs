using Microsoft.AspNetCore.Authorization;

namespace WebApp.Helpers
{
    public class EmailDomainRequirement : IAuthorizationRequirement
    {
        public string[] EmailDomain { get; }

        public EmailDomainRequirement(string[] emailDomain)
        {
            EmailDomain = emailDomain;
        }

    }
}
