using System;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees.Decorators;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees.Proxies;
using Itmo.ObjectOrientedProgramming.Lab3.Displays.Adapters;
using Itmo.ObjectOrientedProgramming.Lab3.Displays.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers.Adapters;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Tests.Mocks;
using Itmo.ObjectOrientedProgramming.Lab3.Topics.Entities;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

#pragma warning disable CA1707

public class MessageDistributionSystemTests
{
    [Fact]
    public void MessageToUserSending_MessageShouldBeUnread()
    {
        var user = new AddresseeUser(11, "Mark");
        var message = new Message("Hi", "There", ImportanceLevel.Common);
        var topic = new Topic("ILoveOop", user);

        topic.SendMessage(message);
        user.Messages.TryGetValue(message, out bool isMessageRead);

        Assert.False(isMessageRead);
    }

    [Fact]
    public void ReadUnreadMessage_MessageShouldBeRead()
    {
        var user = new AddresseeUser(910, "Marcelo");
        var message = new Message("Hi", "There", ImportanceLevel.Common);
        var topic = new Topic("IHatePhysics", user);

        topic.SendMessage(message);
        user.ReadMessage(message);
        user.Messages.TryGetValue(message, out bool isMessageRead);

        Assert.True(isMessageRead);
    }

    [Fact]
    public void ReadAlreadyReadMessage_ExceptionShouldBeReturned()
    {
        var user = new AddresseeUser(910, "Marcelo");
        var message = new Message("Hi", "There", ImportanceLevel.Common);
        var topic = new Topic("IHateHistory", user);

        topic.SendMessage(message);
        user.ReadMessage(message);

        Exception? actual = null;
        try
        {
            user.ReadMessage(message);
        }
        catch (MessageHasAlreadyBeenReadException e)
        {
            actual = e;
        }

        Assert.IsType<MessageHasAlreadyBeenReadException>(actual);
    }

    [Fact]
    public void SendingMessageWithInsufficientImportanceToAddresseeWithConfiguredFilter_MessageShouldNotReach()
    {
        var displayDriverMock = new DisplayDriverMock();
        var display = new Display(displayDriverMock);
        var displayAdapter = new AddresseeDisplayAdapter(display);
        var addressee = new MessagesFilterProxy(displayAdapter, ImportanceLevel.Important);
        var message = new Message("Hi", "There", ImportanceLevel.Common);
        var topic = new Topic("ILoveEnglish", addressee);

        topic.SendMessage(message);
        string actual = displayDriverMock.DisplayedText;

        Assert.Empty(actual);
    }

    [Fact]
    public void SendingMessageToAddresseeWithConfiguredLogger_LogShouldBeWritten()
    {
        var messenger = new Messenger("Telegram");
        var messengerAdapter = new AddresseeMessengerAdapter(messenger);
        var loggerMock = new LoggerMock();
        var messageLoggerDecorator = new MessageLoggerDecorator(loggerMock, messengerAdapter);
        var message = new Message("Hi", "There", ImportanceLevel.Common);
        var topic = new Topic("ILoveWork", messageLoggerDecorator);

        topic.SendMessage(message);
        string expected = message.ToString();
        string actual = loggerMock.LoggedText;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SendingMessageToMessenger_MessengerShouldReceiveMessage()
    {
        var messengerMock = new MessengerMock();
        var messengerAdapter = new AddresseeMessengerAdapter(messengerMock);
        var message = new Message("Hi", "There", ImportanceLevel.Common);
        var topic = new Topic("Oleg top", messengerAdapter);

        topic.SendMessage(message);
        string expected = message.ToString();
        string actual = messengerMock.WrittenText;

        Assert.Equal(expected, actual);
    }
}

#pragma warning restore CA1707