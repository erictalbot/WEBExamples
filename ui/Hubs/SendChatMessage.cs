using System.Linq;
using Microsoft.AspNet.SignalR;

namespace ui.Hubs
{
    public class SendChatMessage : ISendChatMessage
    {
  
        #region properties

        private IHubContext _chatHubContext;
 
        #endregion

        #region ctor

        public SendChatMessage()
        {
            _chatHubContext = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
        }

        #endregion

        #region public methods

        public void SendMessageToUser(string windowsAccountName, string message)
        {
            User user = SignalRConnections.Instance.GetUser(windowsAccountName);
            if (user != null)
                user.ConnectionIds.ToList().ForEach(c => _chatHubContext.Clients.Client(c).receive(message));
        }

        public void SendToAll(string message)
        {
            SignalRConnections.Instance.Users.ToList().ForEach(u =>
                u.Value.ConnectionIds.ToList().ForEach(c =>
                    _chatHubContext.Clients.Client(c).receive(message)));
        }

        #endregion

    }
}
