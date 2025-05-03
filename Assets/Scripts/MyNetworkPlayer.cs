using Mirror;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MyNetworkPlayer : NetworkBehaviour
{
    #region rofl
    [SerializeField] private Text allSecret;
    [SerializeField] private Text secretPlayer;

    [SyncVar(hook = nameof(SetAllSecret))]
    [SerializeField] private string playerSecret = "Secret null";
    
    public void SetAllSecret(string oldSecret, string newSecret)
    {
        allSecret.text = newSecret;
    }
    #endregion

    //[SyncVar]
    [SerializeField] private TextMeshProUGUI _displayNameText = null;

    //[SyncVar]
    [SerializeField] private Renderer _displayColorRenderer = null;


    [SyncVar(hook = nameof(DisplayNameUpdater))]
    [SerializeField] private string _displayName = "Noname";



    [SyncVar(hook = nameof(DisplayColorUpdater))]
    [SerializeField] private Color _displayNameColor = Color.black;

    #region Server
    [Server]
    public void SetDisplayName(string newDisplayName)
    {
        _displayName = newDisplayName;
    }
    [Server]
    public void SetDisplayColor(Color newDisplayColor)
    {
        _displayNameColor = newDisplayColor;
    }

    [Command]
    private void cmdSetDisplayName(string newDisplayName)
    {
        if (newDisplayName.Length<2 || newDisplayName.Length >18 )
        {
            return;
        }
        RpclognewName(newDisplayName);
        SetDisplayName(newDisplayName);
    }
    #endregion



    #region Client
    private void DisplayNameUpdater(string oldName, string newName)
    {
        _displayNameText.text = newName;
    }
    private void DisplayColorUpdater(Color oldColor, Color newColor)
    {
        _displayColorRenderer.material.SetColor(" baseColor", newColor);
    }


    [ContextMenu("WTF_1")]
    private void SetMyName()
    {

        cmdSetDisplayName("WTF_1");
    }

    public void clickBut()
    {
        cmdSetDisplayName(secretPlayer.text);
        //playerSecret = secretPlayer.text;
    }

    [ClientRpc]
    private void RpclognewName(string newName)
    {
        Debug.Log(newName);
    }
    #endregion




}
