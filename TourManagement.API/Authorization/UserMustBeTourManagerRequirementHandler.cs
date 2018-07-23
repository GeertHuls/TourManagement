using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourManagement.API.Services;

namespace TourManagement.API.Authorization
{
    public class UserMustBeTourManagerRequirementHandler
        : AuthorizationHandler<UserMustBeTourManagerRequirement>
    {
        private readonly ITourManagementRepository _tourManagementRepository;
        private readonly IUserInfoService _userInfoService;

        public UserMustBeTourManagerRequirementHandler(
            ITourManagementRepository tourManagementRepository,
            IUserInfoService userInfoService)
        {
            _tourManagementRepository = tourManagementRepository;
            _userInfoService = userInfoService;
        }

        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context, UserMustBeTourManagerRequirement requirement)
        {
            if (_userInfoService.Role == requirement.Role)
            {
                context.Succeed(requirement);
                return;
            }

            var filterContext = context.Resource as AuthorizationFilterContext;
            if (filterContext == null)
            {
                context.Fail();
                return;
            }

            var tourId = filterContext.RouteData.Values["tourId"].ToString();

            if (!Guid.TryParse(tourId, out Guid tourIdAsGuid))
            {
                context.Fail();
                return;
            }

            if (!Guid.TryParse(_userInfoService.UserId, out Guid userIdAsGuid))
            {
                context.Fail();
                return;
            }


            if (!_tourManagementRepository.IsTourManager(tourIdAsGuid, userIdAsGuid).Result)
            {
                context.Fail();
                return;
            }

            context.Succeed(requirement);
            await Task.CompletedTask;
        }
    }
}
