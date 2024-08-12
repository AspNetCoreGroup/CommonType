using CommonLibrary.Interfaces.Listeners;
using CommonLibrary.Interfaces.Senders;
using CommonLibrary.Extensions;

namespace CommonTestProject;

public class Tests
{
    private IServiceProvider? ServiceProvider { get; set; }

    [SetUp]
    public void Setup()
    {
        //ServiceProvider = IServiceProvider

    }

    [Test]
    public void SendTest()
    {
        var sender = ServiceProvider!.GetService(typeof(IMessageSender)) as IMessageSender;

        sender!.SendMessageAsync("TestSend", "Прости");
        sender!.SendMessageAsync("TestSend", "Прощай");
        sender!.SendMessageAsync("TestSend", "Привет");
    }

    public void RecieveTest()
    {
        var factory = ServiceProvider!.GetService(typeof(IMessageListenerFactory)) as IMessageListenerFactory;
        var service = factory!.CreateListener("TestRecieve");

        service.AddHandler((q, m, p) => { Assert. });
    }
}
