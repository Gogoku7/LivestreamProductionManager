using Microsoft.Web.WebSockets;
using Serilog;

namespace LivestreamProductionManager.WebSockets
{
    public class QueuSocketHandler : WebSocketHandler
    {
        private static readonly WebSocketCollection _clients = new WebSocketCollection();

        public override void OnOpen()
        {
            _clients.Add(this);
        }

        public override void OnMessage(string queuData)
        {
            Log.Information($"Data sent through the WebSocket: { queuData.Replace("\\", "") }");

            _clients.Broadcast(queuData);
        }
    }
}