using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace ui.Hubs
{
    public class ChatHub : Hub
    {

        /*
         * 
         * A basic implementation could use the following 2 properties to update clients 
         * Clients.All
         * Clients.Caller
         * 
         * */

        #region public methods

        public void Send(string message)
        {
            Clients.All.receive(message);
        }

        public override Task OnConnected()
        {
            string userName = Context.User.Identity.Name;
            string connectionId = Context.ConnectionId;

            var user = SignalRConnections.Instance.Users.GetOrAdd(userName, _ => new User
            {
                Name = userName,
                ConnectionIds = new HashSet<string>()
            });

            lock (user.ConnectionIds)
            {
                user.ConnectionIds.Add(connectionId);
                if (user.ConnectionIds.Count == 1)
                {
                    Clients.Others.userConnected(userName);
                }
            }
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            string userName = Context.User.Identity.Name;
            string connectionId = Context.ConnectionId;
            User user;
            SignalRConnections.Instance.Users.TryGetValue(userName, out user);
            if (user != null)
            {
                lock (user.ConnectionIds)
                {
                    user.ConnectionIds.RemoveWhere(cid => cid.Equals(connectionId));
                    if (!user.ConnectionIds.Any())
                    {
                        User removedUser;
                        SignalRConnections.Instance.Users.TryRemove(userName, out removedUser);

                        // You might want to only broadcast this info if this
                        // is the last connection of the user and the user actual is
                        // now disconnected from all connections.
                        Clients.Others.userDisconnected(userName);
                    }
                }
            }
            return base.OnDisconnected(stopCalled);
        }

        #endregion

    }
}