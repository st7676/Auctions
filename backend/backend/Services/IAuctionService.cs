using backend.Models;

namespace backend.Services
{
    public interface IAuctionService
    {
        List<Auction> GetAll();
        Auction? GetById(int id);
        Auction Create(Auction auction);
        Bid? AddBid(Bid bid);
    }
}
