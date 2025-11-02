namespace CarSalesManager.Domain;

public static class DealerData
{
    public static IEnumerable<Dealer> GetData()
    {
        yield return new Dealer("ABC", new Address("Zaventem", "Leuvensesteenweg", 430, 1930));
        yield return new Dealer("Land Rover Brussels East Zaventem", new Address("Zaventem", "Leuvensesteenweg", 432, 1930));
    }
}
