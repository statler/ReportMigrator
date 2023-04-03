using System;

namespace cpShared.Models
{
    public class FirewallProperties
    {
        public string ApplicationId;
        public string ClientSecret;
        public string TenantId;
        public string SubscriptionId;
        public string ResourceGroupName;
        public string Server;

        public FirewallProperties()
        {

        }


        public override bool Equals(object obj) => this.Equals(obj as FirewallProperties);

        public bool Equals(FirewallProperties p)
        {
            if (p is null)
            {
                return false;
            }

            // Optimization for a common success case.
            if (Object.ReferenceEquals(this, p))
            {
                return true;
            }

            return p.Server.Trim() == this.Server.Trim() &&
                 p.ApplicationId.Trim() == this.ApplicationId.Trim() &&
                 p.ClientSecret.Trim() == this.ClientSecret.Trim() &&
                 p.TenantId.Trim() == this.TenantId.Trim() &&
                 p.SubscriptionId.Trim() == this.SubscriptionId.Trim();
        }

        public override int GetHashCode() => (TenantId.Trim(), SubscriptionId.Trim(), ApplicationId.Trim(), ClientSecret.Trim(), Server.Trim()).GetHashCode();

        public static bool operator ==(FirewallProperties lhs, FirewallProperties rhs)
        {
            if (lhs is null)
            {
                if (rhs is null)
                {
                    // null == null = true.
                    return true;
                }

                // Only the left side is null.
                return false;
            }
            // Equals handles the case of null on right side.
            return lhs.Equals(rhs);
        }

        public static bool operator !=(FirewallProperties lhs, FirewallProperties rhs) => !(lhs == rhs);
    }
}
