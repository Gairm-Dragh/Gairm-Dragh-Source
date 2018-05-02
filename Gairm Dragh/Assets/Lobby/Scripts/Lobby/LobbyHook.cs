using UnityEngine;
using UnityEngine.Networking;
using System.Collections;



namespace Prototype.NetworkLobby {
    // Subclass this and redefine the function you want
    // then add it to the lobby prefab
    public class LobbyHook : MonoBehaviour {

        //on switching scenes, allows the passing of variables from one prefab to another
        public virtual void OnLobbyServerSceneLoadedForPlayer(NetworkManager manager, GameObject lobbyPlayer, GameObject gamePlayer) {
            gamePlayer.GetComponent<playerInfo>().playerName = lobbyPlayer.GetComponent<LobbyPlayer>().playerName;

            if (lobbyPlayer.GetComponent<LobbyPlayer>().playerColor == Color.blue) {
                gamePlayer.GetComponent<playerInfo>().playerTeam = 1;
            }
            else {
                gamePlayer.GetComponent<playerInfo>().playerTeam = 2;
            }

            DragonGlobals.initTypes();
        }
    }

}
