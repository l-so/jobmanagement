using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Job.WebMvc.Identity
{
    public class AppUserManager : UserManager<AppUser>
    {
        public AppUserManager(IUserStore<AppUser> store)
            : base(store)
        {

        }

        public static AppUserManager Create(
            IdentityFactoryOptions<AppUserManager> options,
            IOwinContext context)
        {
            AppUserManager manager = new AppUserManager(
                new UserStore<AppUser>(
                    context.Get<AppDbContext>()));

            // Configure validation logic for usernames
            manager.UserValidator =
                new UserValidator<AppUser>(manager)
                {
                    AllowOnlyAlphanumericUserNames = false,
                    RequireUniqueEmail = true
                };


            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };


            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses 
            // Phone and Emails as a step of receiving a code for verifying 
            // the user You can write your own provider and plug in here.
            manager.RegisterTwoFactorProvider("PhoneCode",
                new PhoneNumberTokenProvider<AppUser>
                {
                    MessageFormat = "Your security code is: {0}"
                });

            manager.RegisterTwoFactorProvider("EmailCode",
                new EmailTokenProvider<AppUser>
                {
                    Subject = "SecurityCode",
                    BodyFormat = "Your security code is {0}"
                });


            var dataProtectionProvider = options.DataProtectionProvider;

            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<AppUser>(
                        dataProtectionProvider.Create("ZZ Soft ASP.NET Identity"));
            }
            return manager;
        }



    }
}