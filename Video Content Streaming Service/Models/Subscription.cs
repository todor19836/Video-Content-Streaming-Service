namespace VideoStreaming.Web.Models
{
    public class Subscription
    {
        public int SubscriptionId { get; set; }

        public string Tier { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}