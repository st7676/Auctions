using System.Security.Cryptography;
    public enum AuctionStatus
    {
        Active,
        Closed
    }
namespace backend.Models
{

    public class Auction
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public decimal CurrentHighestBid { get; set; }

        public AuctionStatus Status { get; set; } = AuctionStatus.Active;
        // Active / Closed

        public DateTime EndTime { get; set; }

        // קשר להצעות מחיר
        public List<Bid> Bids { get; set; } = new();

        public Auction() { }

    }
}
