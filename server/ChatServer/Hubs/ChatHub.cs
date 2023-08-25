﻿using Microsoft.AspNetCore.SignalR;
using ChatServer.Models;

namespace ChatServer.Hubs;

public sealed class ChatHub : Hub
{
    private const string MessageClientHandlerEndpoint = "Receive";

    public async Task Send(MessageRequest request)
    {
        var response = new MessageResponse
        {
            Message = request.Message,
            Date = DateTimeOffset.UtcNow,
        };

        await Clients.Others.SendAsync(MessageClientHandlerEndpoint, response);
    }
}
