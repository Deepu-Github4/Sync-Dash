using UnityEngine;
using Photon.Pun;

public class MultiplayerManager : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject oppblockset;
    [SerializeField] GameObject playerBlockset;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BlockSetActive()
    {
        oppblockset.SetActive(true);
    }

    public void GameBegin()
    {
        PlayerController.instance.gameStart = true;
        Spawner.instance.GameStart();
        playerBlockset.SetActive(true);
        Invoke("BlockSetActive", 0.2f);
    }
}
