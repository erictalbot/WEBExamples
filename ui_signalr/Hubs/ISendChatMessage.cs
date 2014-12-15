
namespace ui.Hubs
{
    public interface ISendChatMessage
    {
        // Some example method you could implement
        //void SendEventToAllOnTeams(List<Model.Data.Team> teams, ui.Dto.Event aEvent);
        //void SendEventToAllUsers(List<Model.Data.User> teams, ui.Dto.Event aEvent);
        void SendMessageToUser(string windowsAccountName, string message);
        void SendToAll(string message);
    }
}