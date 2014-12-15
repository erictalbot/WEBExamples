using System;
using System.Collections.Concurrent;

namespace ui.Hubs
{
    public sealed class SignalRConnections
    {
        private static volatile SignalRConnections _instance;
        private static object _syncRoot = new Object();

        #region properties / vars

        public ConcurrentDictionary<string, User> Users = new ConcurrentDictionary<string, User>(StringComparer.InvariantCultureIgnoreCase);
        public static SignalRConnections Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new SignalRConnections();
                    }
                }

                return _instance;
            }
        }
        #endregion

        #region ctor

        private SignalRConnections()
        {
        }

        #endregion

        #region private methods

        public User GetUser(string username)
        {
            User user;
            Users.TryGetValue(username, out user);
            return user;
        }

        #endregion

    }
}