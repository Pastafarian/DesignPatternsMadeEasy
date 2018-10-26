using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    public static class Observer
    {
        public class AuctionItem
        {
            public List<Bidder> Bidders = new List<Bidder>();
            public decimal CurrentBid { get; set; }
            public string Name { get; set; }

            public AuctionItem(string name)
            {
                Name = name;
            }

            public void AddBidder(Bidder bidder)
            {
                Bidders.Add(bidder);
            }

            public void RemoveBidder(Bidder bidder)
            {
                Bidders.Remove(bidder);
            }

            public void Bid(decimal bid)
            {
                CurrentBid = bid;
                Bidders.ForEach(x => x.Notify(this));
            }
        }

        public class Bidder
        {
            public string Name { get; set; }

            public Bidder(string name)
            {
                Name = name;
            }

            public void Notify(AuctionItem auctionItem)
            {
                Console.WriteLine($"Bidder {Name} notified of change in action item {auctionItem.Name}, price now £{auctionItem.CurrentBid}");
            }
        }


        public static void Run()
        {
            var car = new AuctionItem("Fast Car");
            var bidderTom = new Bidder("Tom");
            var bidderDave = new Bidder("Dave");
            car.AddBidder(bidderTom);
            car.AddBidder(bidderDave);

            car.Bid(2500.00M);
            car.Bid(3500.00M);
        }
    }
}
