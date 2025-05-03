using Mirror;
using UnityEngine;

public class MyNetworkManager : NetworkManager
{
    //public override void OnClientConnect()
    //{
    //    base.OnClientConnect();
    //    Debug.Log("I connected to this beautuful server!");

    //}
    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {


        base.OnServerAddPlayer(conn);

        MyNetworkPlayer player = conn.identity.GetComponent<MyNetworkPlayer>();
        player.SetDisplayName($"I connected {numPlayers}!");

        Color displayColor = new Color(
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            Random.Range(0f, 1f));

        player.SetDisplayColor(displayColor);
        //Debug.Log($"I connected to this beautuful server {numPlayers}!");
    }
}
