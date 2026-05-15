using System;

namespace EVS
{
    public class UserSession
    {
        public string Login { get; set; }
        public long UserId { get; set; }
        public string UserType { get; set; }  // "employee" или "client"
        public string FullName { get; set; }
        public string Role { get; set; }      // "manager", "driver", "client", "user"
        public DateTime LoginTime { get; set; }

        public bool IsEmployee => UserType == "employee";
        public bool IsClient => UserType == "client";
        public bool IsManager => Role == "manager";
        public bool IsDriver => Role == "driver";
        public bool IsClientUser => Role == "client";
    }
}