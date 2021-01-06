using AkiraBot.Sql;
using AkiraBot.Utilities.Aspects;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace AkiraBot
{
  class Program 
  {
    /* Member variables*/
    private DiscordSocketClient _client;
    private CommandService _commands;
    private IServiceProvider _services;

    [AkiraMainAspect]
    static async Task Main(string[] args) => await new Program().MainAsync();

    public async Task MainAsync()
    { 
      _client = new DiscordSocketClient();
      _client.Log += Log;

      _commands = new CommandService();
      _services = new ServiceCollection()
                      .AddSingleton(_client)
                      .AddSingleton(_commands)
                      .BuildServiceProvider();

      await CommandAsync();

      await _client.LoginAsync(TokenType.Bot, AkiraSql.GetConfigurationValue("DiscordToken"));
      await _client.StartAsync();

      await Task.Delay(-1);
    }

    public async Task CommandAsync()
    { 
      _client.MessageReceived += HandleCommandAsync;
      await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
    }

    public async Task HandleCommandAsync(SocketMessage msg)
    { 
      SocketUserMessage message = (SocketUserMessage)msg;
      SocketCommandContext context = new SocketCommandContext(_client, message);

      int argPos = 0;

      if(message.Author.IsBot) return;

      if(message.HasStringPrefix(AkiraSql.GetConfigurationValue("DiscordPrefix"), ref argPos))
      { 
        var result = await _commands.ExecuteAsync(context, argPos, _services);
        if(!result.IsSuccess)
          Console.WriteLine(result.ErrorReason);
      }
    }

    public Task Log(LogMessage msg)
    { 
      Console.WriteLine(msg.ToString());
      return Task.CompletedTask;
    } 
  }
}
