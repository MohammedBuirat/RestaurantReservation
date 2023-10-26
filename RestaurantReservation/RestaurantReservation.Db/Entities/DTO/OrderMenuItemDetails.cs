public class OrderMenuItemDetails
{
    public int OrderId { get; set; }
    public int ReservationId { get; set; }
    public DateTime OrderDate { get; set; }
    public string MenuItemName { get; set; }
    public decimal MenuItemPrice { get; set; }
    public string MenuItemDescription { get; set; }
    public string RestaurantName { get; set; }
}
