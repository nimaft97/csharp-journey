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
    };

    public class Review
    {
        public int Issue;
        public Critics Critic;
        public double Score;
    };

    public static class ComicAnalyzer
    {
        public static IEnumerable<Review> Reviews = new[] {
                                    new Review() { Issue = 36, Critic = Critics.MuddyCritic, Score = 37.6 },
                                    new Review() { Issue = 74, Critic = Critics.RottenTornadoes, Score = 22.8 },
                                    new Review() { Issue = 74, Critic = Critics.MuddyCritic, Score = 84.2 },
                                    new Review() { Issue = 83, Critic = Critics.RottenTornadoes, Score = 89.4 },
                                    new Review() { Issue = 97, Critic = Critics.MuddyCritic, Score = 98.1 },
        };

        private static PriceRange CalculatePriceRange(Comic comic)
        {
            bool cheap = Comic.Prices[comic.Issue] < 100M;
            if (cheap)
            {
                return PriceRange.Cheap;
            }
            return PriceRange.Expensive;
        }

        public static IEnumerable<IGrouping<PriceRange, Comic>> GroupComicsByPrice(IEnumerable<Comic> Catalog, 
                                                                            IReadOnlyDictionary<int, decimal> Prices)
        {
            var result = 
                from comic in Catalog
                orderby Comic.Prices[comic.Issue] ascending
                group comic by CalculatePriceRange(comic) into comicGroup
                select comicGroup;
            return result;
        }

        public static IEnumerable<String> GetReviews(IEnumerable<Comic> Catalog, IEnumerable<Review> Reviews)
        {
            var result =
                from comic in Catalog
                orderby comic.Issue ascending
                join review in Reviews
                on comic.Issue equals review.Issue
                select $"{review.Critic} rated #{review.Issue} '{comic.Name}' {review.Score:0.00}";
            return result;
        }
    };
}
