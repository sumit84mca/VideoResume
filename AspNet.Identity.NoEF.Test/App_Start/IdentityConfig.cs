using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using AspNet.Identity.NoEF;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using AspNet.Identity.NoEF.Test.Models;

namespace AspNet.Identity.NoEF.Test
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // TODO : code to insert into email table.
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }

    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class IdentityUserManager : UserManager<IdentityUser>
    {
        public IdentityUserManager(IUserStore<IdentityUser> store)
            : base(store)
        {
        }

        public static IdentityUserManager Create(IdentityFactoryOptions<IdentityUserManager> options, IOwinContext context)
        {
            //var manager = new IdentityUserManager(new UserStore<IdentityUser>(context.Get<ApplicationDbContext>()));

            var manager = new IdentityUserManager(new AspNet.Identity.NoEF.UserStore());

            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<IdentityUser>(manager)
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

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<IdentityUser>
            {
                MessageFormat = "Your security code is {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<IdentityUser>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<IdentityUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }

        

        public override Task<bool> CheckPasswordAsync(IdentityUser user, string password)
        {
            return base.CheckPasswordAsync(user, password); 
        }
    }

    // Configure the application sign-in manager which is used in this application.
    public class ApplicationSignInManager : SignInManager<IdentityUser, string>
    {
        public ApplicationSignInManager(IdentityUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        //public override Task<ClaimsIdentity> CreateUserIdentityAsync(IdentityUser user)
        //{
        //    return user.GenerateUserIdentityAsync((IdentityUserManager)UserManager);
        //}

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<IdentityUserManager>(), context.Authentication);
        }

        public override Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool isPersistent, bool shouldLockout)
        {
            SignInStatus signInStatus;
            if (this.UserManager == null)
            {
                signInStatus = SignInStatus.Failure;
            }
            else
            {
                IdentityUser user = this.UserManager.FindByNameAsync(userName).Result;
                if ((object)user == null)
                    signInStatus = SignInStatus.Failure;
                if (this.UserManager.CheckPasswordAsync(user, password).Result)
                {
                    SignInAsync(user, isPersistent, false);
                    signInStatus = SignInStatus.Success;
                }
                else signInStatus = SignInStatus.Failure;
            }
            return Task.FromResult(signInStatus);
        }
    }

    
}
