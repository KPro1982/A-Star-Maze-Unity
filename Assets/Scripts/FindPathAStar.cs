using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FindPathAStar : MonoBehaviour
{
    public Maze maze;
    public Material closedMaterial;
    public Material openMaterial;

    List<PathMarker> open = new List<PathMarker>();
    List<PathMarker> closed = new List<PathMarker>();

    public GameObject start;
    public GameObject end;
    public GameObject pathP;

    private PathMarker goalNode;
    private PathMarker startNode;
    private PathMarker lastPos;
    private bool done = false;


    void RemoveAllMarkers()
    {
        GameObject[] markers = GameObject.FindGameObjectsWithTag("marker");
        foreach (GameObject m in markers)
            Destroy(m);
    }

    void BeginSearch()
    {
        done = false;
        RemoveAllMarkers();

        List<MapLocation> locations = new List<MapLocation>();
        for(int z = 1; z < maze.depth -1; z++)
        {
            for (int x = 1; x < maze.width - 1; x++)
            {
                if(maze.map[x,z] != 1)
                    locations.Add(new MapLocation(x, z));
            }
        }
        
        locations.Shuffle();

        Vector3 startLocation = new Vector3(locations[0].x*maze.scale, 0, locations[0].z*maze.scale);
        startNode = new PathMarker(new MapLocation(locations[0].x, locations[0].z), 0, 0, 0,
            Instantiate(start, startLocation, Quaternion.identity), null);
        Vector3 goalLocation = new Vector3(locations[1].x*maze.scale, 0, locations[1].z*maze.scale);
        goalNode = new PathMarker(new MapLocation(locations[1].x, locations[1].z), 0, 0, 0,
            Instantiate(end, goalLocation, Quaternion.identity), null);
    }
    
    
    
    void Start()
    {
        
    }

  
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)) BeginSearch();
    }
}
