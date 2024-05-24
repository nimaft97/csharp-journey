using PickRandomCards;

Console.Write("Enter a number: ");
string line = Console.ReadLine();
if (int.TryParse(line, out int numCards))
{
    foreach(var card in CardPicker.PickSomeCards(numCards))
    {
        Console.WriteLine(card);
    }
}
else
{
    Console.WriteLine("Wasn't able to parse the input number");
}