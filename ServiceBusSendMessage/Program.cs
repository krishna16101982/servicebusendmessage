using Microsoft.Azure.ServiceBus;
using System.Text;

class Program
{
    const string ServiceBusConnectionString = "Endpoint=sb://azservicebus001.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=KcEVSrHaF5Pcs3ns5TvnJWTdA7s36Wn7K+ASbMmAkGY=";
    const string QueueName = "servicebusqueue001";

    static async Task Main(string[] args)
    {
        IQueueClient queueClient = new QueueClient(ServiceBusConnectionString, QueueName);

        try
        {
            // Create a message
            string messageBody = "Hello from Azure Service Bus!";
            var message = new Message(Encoding.UTF8.GetBytes(messageBody));

            // Send the message to the queue
            await queueClient.SendAsync(message);
            Console.WriteLine("Message sent to the queue!");
        }
        catch (Exception exception)
        {
            Console.WriteLine($"{DateTime.Now} :: Exception: {exception.Message}");
        }
        finally
        {
            await queueClient.CloseAsync();
        }
    }
}
