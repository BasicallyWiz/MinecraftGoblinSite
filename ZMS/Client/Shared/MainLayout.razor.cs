using System.Net.Sockets;

namespace ZMS.Client.Shared
{
  partial class MainLayout
  {
    //  TODO: Create an API Controller on the server to act as a middle-man for UDP requests to the minecraft server.
    //  This is because browsers do not allow UDP requests, for some stupid reason. Maybe it's not stupid, but it's still annoying.
    //  Use this page as a reference: https://web.archive.org/web/20111126125408/http://dinnerbone.com/blog/2011/10/14/minecraft-19-has-rcon-and-query
    //  This is the same method used by the Minecraft server list, and it's the only way to get the player count without using a plugin.
    //  That last line was genereated entirely by GitHub Co-pilot, but now that I think about it I could just make a plugin that does
    //  this and then use the plugin's API to get the player count, but that seems slightly less fun.

    //  But then again, I'd get more data... I'll think about it. While I sleep.
  }
}
