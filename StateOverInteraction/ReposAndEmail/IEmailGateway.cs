namespace StateOverInteraction.ReposAndEmail;

public interface IEmailGateway
{
    void Send(EmailMessage message);
}

public class EmailMessage
{
}

public interface IOrderRepository
{
    Order GetOrderById(int orderId);
    IReadOnlyList<Order> GetActiveOrdersForCustomer(int customerId);
    void Save(Order order);
}

public class Order
{
    
}

public class OrderService
{
    void Place
}