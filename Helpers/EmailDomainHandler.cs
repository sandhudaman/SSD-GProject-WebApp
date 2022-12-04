using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace WebApp.Helpers
{
    public class EmailDomainHandler : AuthorizationHandler<EmailDomainRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, EmailDomainRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == ClaimTypes.Email))
                return Task.CompletedTask;

            var emailAddress = context.User.FindFirst(c => c.Type == ClaimTypes.Email).Value;

            string[] emails = requirement.EmailDomain;

            for (int i = 0; i < emails.Length; i++) {
                if (emailAddress.EndsWith(emails[i]))
                    context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }

    }
}
