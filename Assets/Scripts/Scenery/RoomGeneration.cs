using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomGeneration : MonoBehaviour
{
    public string CurrentScene;
    //public GameObject Player;
    //public GameObject StarterRoom;

    public List<GameObject> Rooms = new List<GameObject>();

    public int RandNumOfRooms;
    public int RoomToBePlaced;
    public int RoomPlacedCount;

    public bool ExitSpawned;
    public GameObject ExitRoom;

    // Start is called before the first frame update
    void Start()
    {
        CurrentScene = SceneManager.GetActiveScene().name;

        //Instantiate(StarterRoom, new Vector3(-46.45f, 1.13f, -0.07261276f), Quaternion.identity);
        //Instantiate(Player, new Vector3(-35.74f, -1.56f, -0.72f), Quaternion.identity);

        if(CurrentScene == "Level1")
        {
            RandNumOfRooms = Random.Range(3, 6);
        }

        if(CurrentScene == "Level2")
        {
            RandNumOfRooms = Random.Range(5, 9);
        }

        if(CurrentScene == "Level3")
        {
            RandNumOfRooms = Random.Range(8, 14);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(RoomPlacedCount < RandNumOfRooms)
        {
            for(int i = 0; i < RandNumOfRooms; i++)
            {
                RoomToBePlaced = Random.Range(0,Rooms.Count);
                RoomPlacedCount += 1;
                Instantiate(Rooms[RoomToBePlaced], new Vector3(36f * RoomPlacedCount, 6.390605f, -0.07261276f), Quaternion.identity);
            }
        }
        if(RoomPlacedCount >= RandNumOfRooms && ExitSpawned == false)
        {
            Instantiate(ExitRoom, new Vector3((36f * RoomPlacedCount)+25.3f, 1.13f, -0.07261276f), Quaternion.identity);
            ExitSpawned = true;
        }
    }
}
