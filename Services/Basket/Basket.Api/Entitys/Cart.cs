namespace Basket.Api.Entitys;

public class Cart
{
    public string UserName { get; set; }

    public List<Items> ItemsList { get; set; }

    public decimal TotalPrice
    {
        get
        {
            decimal total = 0;
            foreach (var item in ItemsList)
            {
                total += item.Price*item.Count;
            }
            return total;
        }
    }
}