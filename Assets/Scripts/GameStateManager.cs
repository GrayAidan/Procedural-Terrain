using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public enum GameState
    {
        Editor,
        Player
    }

    public GameState currentState;

    public GameObject playerPrefab;
    public GameObject editorCam;
    public GameObject meshObject;
    public GameObject worldEditor;
    public GameObject editorUI;

    private GameObject spawnedPlayer;
    private MeshCollider meshComponent;

    private bool stateStarted;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case GameState.Editor:
                EditorState();
                break;
            case GameState.Player:
                PlayerState();
                break;
            default:
                break;
        }
    }

    public void EditorState()
    {
        if (!stateStarted)
        {
            if(spawnedPlayer != null)
            {
                Destroy(spawnedPlayer);
            }
            if(meshComponent != null)
            {
                Destroy(meshComponent);
            }

            worldEditor.SetActive(true);
            editorCam.SetActive(true);
            editorUI.SetActive(true);
            stateStarted = true;
        }



        if (Input.GetKeyDown("return"))
        {
            currentState = GameState.Player;
            stateStarted = false;
        }
    }

    public void PlayerState()
    {
        if (!stateStarted)
        {
            meshComponent = meshObject.AddComponent<MeshCollider>();
            spawnedPlayer = Instantiate(playerPrefab, transform);
            spawnedPlayer.transform.SetParent(null);
            editorCam.SetActive(false);
            worldEditor.SetActive(false);
            editorUI.SetActive(false);
            stateStarted = true;

            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 30000))
            {
                spawnedPlayer.transform.position = hit.point;
            }
        }

        if (Input.GetKeyDown("return"))
        {
            currentState = GameState.Editor;
            stateStarted = false;
        }
    }
}
