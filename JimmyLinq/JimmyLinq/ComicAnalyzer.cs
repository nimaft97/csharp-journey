using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace JimmyLinq
{
    public enum Critics
    {
        MuddyCritic,
        RottenTornadoes
    };

    public enum PriceRange
    {
        Cheap,
        Expensive
    };

    public class Comic
    {
        public string Name { get; set; }
        public int Issue { get; set; }
        public override string ToString()
        {
            return $"{Name} (Issue #{Issue})";
        }

        public static readonly IEnumerable<Comic> Catalog =
            new[] {
            new Comic { Name = "Johnny America vs. the Pinko", Issue = 6 },
            new Comic { Name = "Rock and Roll (limited edition)", Issue = 19 },
            new Comic { Name = "Woman's Work", Issue = 36 },
            new Comic { Name = "Hippie Madness (misprinted)", Issue = 57 },
            new Comic { Name = "Revenge of the New Wave Freak (damaged)", Issue = 68 },
            new Comic { Name = "Black Monday", Issue = 74 },
            new Comic { Name = "Tribal Tattoo Madness", Issue = 83 },
            new Comic { Name = "The Death of the Object", Issue = 97 },
            };

        public static readonly IReadOnlyDictionary<int, decimal> Prices =
            new Dictionary<int, decimal> {
                                    { 6, 3600M },
                                    { 19, 500M },
                                    { 36, 650M },
                                    { 57, 13525M },
                                    { 68, 250M },
                                    { 74, 75M },
                                    { 83, 25.75M },
                                    { 97, 35.25M },
            };

        public static readonly IEnumerable<Review> Reviews = new[] {
            new Review() { Issue = 36, Critic = Critics.MuddyCritic, Score = 37.6 },
            new Review() { Issue = 74, Critic = Critics.RottenTornadoes, Score = 22.8 },
            new Review() { Issue = 74, Critic = Critics.MuddyCritic, Score = 84.2 },
            new Review() { Issue = 83, Critic = Critics.RottenTornadoes, Score = 89.4 },
            new Review() { Issue = 97, Critic = Critics.MuddyCritic, Score = 98.1 },
         };
    }

    public class Review
    {
        public int Issue { get; set; }
        public Critics Critic { get; set; }
        public double Score { get; set; }
    }
    public static class ComicAnalyzer
    {
        private static PriceRange CalculatePriceRange(Comic comic, IReadOnlyDictionary<int, decimal> prices)
        {
            if (prices[comic.Issue] < 100)
                return PriceRange.Cheap;
            else
                return PriceRange.Expensive;
        }
        public static IEnumerable<IGrouping<PriceRange, Comic>> GroupComicsByPrice(
        IEnumerable<Comic> comics, IReadOnlyDictionary<int, decimal> prices)
        {
            IEnumerable<IGrouping<PriceRange, Comic>> grouped =
            from comic in comics
            orderby prices[comic.Issue]
            group comic by CalculatePriceRange(comic, prices) into priceGroup
            select priceGroup;
            return grouped;
        }
        public static IEnumerable<string> GetReviews(
        IEnumerable<Comic> comics, IEnumerable<Review> reviews)
        {
            var joined =
            from comic in comics
            orderby comic.Issue
            join review in reviews on comic.Issue equals review.Issue
            select $"{review.Critic} rated #{comic.Issue} '{comic.Name}' {review.Score:0.00}";
            return joined;
        }
    }
}