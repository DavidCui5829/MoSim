using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkUI : MonoBehaviour
{
    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(20, 20, 300, 300));
        
        if (!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer)
        {
            if (GUILayout.Button("Start Host (Player 1)", GUILayout.Height(60))) 
            {
                NetworkManager.Singleton.StartHost();
                
                // This forces the server to cleanly load the real field for everyone,
                // stripping away all the offline main-menu ghost spawners!
                NetworkManager.Singleton.SceneManager.LoadScene("FieldScene", LoadSceneMode.Single);
            }
                
            if (GUILayout.Button("Start Client (Player 2)", GUILayout.Height(60))) 
            {
                NetworkManager.Singleton.StartClient();
            }
        }
        
        GUILayout.EndArea();
    }
}