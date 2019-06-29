using Microsoft.Web.WebSockets;
using Newtonsoft.Json;
using Serilog;

namespace LivestreamProductionManager.WebSockets
{
    public class QueuSocketHandler : WebSocketHandler
    {
        private static WebSocketCollection _clients = new WebSocketCollection();

        public override void OnOpen()
        {
            _clients.Add(this);
        }

        public override void OnMessage(string queuData)
        {
            Log.Information($"Data sent through the WebSocket: { JsonConvert.SerializeObject(queuData) }");

            _clients.Broadcast(queuData);
        }
    }
}