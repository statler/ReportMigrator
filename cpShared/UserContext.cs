using System;
using System.Collections.Generic;

namespace cpShared
{
    public static class UserContext
    {
        public static PlatformEnum Platform { get; private set; }
        public static int UserId { get; private set; }
        public static string UserName { get; private set; }
        public static int ProjectId { get; private set; }
        public static int UserSubscriberId { get; private set; }
        public static int UserNotificationTypeId { get; private set; }

        public static void SetUserContext(int userId, string userName, int userSubscriberId)
        {
            UserId = userId;
            UserName = userName;
            UserSubscriberId = userSubscriberId;
        }

        public static void SetPlatform(PlatformEnum platform)
        {
            Platform = platform;
        }

        public static void SetProjectContext(int projectId)
        {
            UserNotificationTypeId = -1;
            ProjectId = projectId;
        }

        public static void SetUserNotificationTypeIdContext(int _userNotificationTypeId)
        {
            UserNotificationTypeId = _userNotificationTypeId;
        }

        public static void SetUserSubscriptionContext(int subscriberId)
        {
            UserSubscriberId = subscriberId;
        }

        public static void ResetContext()
        {
            UserId = -1;
            UserName = null;
            ProjectId = -1;
            UserSubscriberId = -1;
            UserNotificationTypeId = -1;
        }

        public static void ResetProjectContext()
        {
            ProjectId = -1;
            UserNotificationTypeId = -1;
        }
    }

    public enum PlatformEnum
    {
        API = 1,
        Desktop_sql = 2,
        Desktop_ce = 3
    }
}
