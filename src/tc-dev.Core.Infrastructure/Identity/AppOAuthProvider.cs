﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using tc_dev.Core.Common.Utilities;
using tc_dev.Core.Infrastructure.Identity.Models;

namespace tc_dev.Core.Infrastructure.Identity
{
    public class AppOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly Func<UserManager<AppIdentityUser, int>> _userManagerFactory;
        private readonly string _publicClientId;

        public AppOAuthProvider(string publicClientId, Func<UserManager<AppIdentityUser, int>> userManagerFactory) {
            publicClientId.ThrowIfNull("publicClientId");

            _publicClientId = publicClientId;
            _userManagerFactory = userManagerFactory;
        }

        public override async Task GrantResourceOwnerCredentials(
            OAuthGrantResourceOwnerCredentialsContext context) 
        {
            using (var userManager = _userManagerFactory()) {
                var user = await userManager.FindAsync(context.UserName, context.Password);

                if (user == null) {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }

                var oAuthIdentity = await userManager.CreateIdentityAsync(user,
                    OAuthDefaults.AuthenticationType);
                var cookiesIdentity = await userManager.CreateIdentityAsync(user,
                    CookieAuthenticationDefaults.AuthenticationType);

                var properties = CreateProperties(user.UserName);
                var ticket = new AuthenticationTicket(oAuthIdentity, properties);
                context.Validated(ticket);
                context.Request.Context.Authentication.SignIn(cookiesIdentity);
            }
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context) {
            foreach (var property in context.Properties.Dictionary) {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(
            OAuthValidateClientAuthenticationContext context) 
        {
            if (context.ClientId == null)
                context.Validated();

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context) {
            if (context.ClientId == _publicClientId) {
                var expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                    context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public static AuthenticationProperties CreateProperties(string userName) {
            var data = new Dictionary<string, string>
            {
                { "userName", userName }
            };
            return new AuthenticationProperties(data);
        }
    }
}
