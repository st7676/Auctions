using backend.Data;
using backend.Models;
using System.Collections.Concurrent;

namespace backend.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly AppDbContext _context;
        public AuctionService(AppDbContext context)
        {
            _context = context;
        }

        private readonly ConcurrentDictionary<int, Auction> _auctions = new();
        public Bid? AddBid(Bid bid)
        {
            if (!_auctions.TryGetValue(bid.AuctionId, out var auction))
                return null;
            if (auction.EndTime < DateTime.UtcNow)
                return null;
            if (bid.Amount <= auction.CurrentHighestBid)
                return null;
            if (auction.Status != AuctionStatus.Active)
                return null;
            Models.Bid newBid = new Bid()
            {
                Id = auction.Bids.Count + 1,
                AuctionId = bid.AuctionId,
                Amount = bid.Amount,
                CreatedAt = DateTime.UtcNow
            };
            //auction.CurrentHighestBid = bid.Amount;
            _context.Bids.Add(newBid);
            _context.SaveChanges();
            return newBid;
        }

        public Auction Create(Auction auction)
        {
            Auction newAuction = new Auction()
            {
                Id = _auctions.Count + 1,
                Title = auction.Title,
                CurrentHighestBid = 0,
                EndTime = auction.EndTime,
                Status = AuctionStatus.Active
            };
            //_auctions.TryAdd(newAuction.Id, newAuction);
            _context.Auctions.Add(newAuction);
            _context.SaveChanges();
            return newAuction;
        }

        public List<Auction> GetAll()
        {
            //return _auctions.Values.ToList();
            return _context.Auctions.ToList();

        }

        public Auction? GetById(int id)
        {
            //return _auctions.TryGetValue(id, out var auction) ? auction : null;
            return _context.Auctions.Find(id);
        }
    }
}
