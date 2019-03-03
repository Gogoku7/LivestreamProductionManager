using Microsoft.Web.WebSockets;

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
            _clients.Broadcast(queuData);
        }
    }
}
