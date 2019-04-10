using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public static LevelManager Instance { set; get; }

    private const bool Show_Collider = true;

    //Level Spawning
    private const float Distance_Before_Spawn = 100.0f;
    private const int Initial_Segments = 10;
    private const int Max_Segments = 15;
    private Transform cameraContainer;
    private int amountOfActiveSegments;
    private int contionousSegments;
    private int currentSpawnZ;
    private int currentLevel;
    private int y1, y2, y3;

    //List of Pieces
    public List<Piece> longblock = new List<Piece>();
    public List<Piece> PurpleLight = new List<Piece>();
    public List<Piece> GreenLight = new List<Piece>();
    public List<Piece> OrangeLight = new List<Piece>();
    public List<Piece> pieces = new List<Piece>();

    //List of Segments
    public List<Segment> availableSegments = new List<Segment>();
    public List<Segment> availableTransitions = new List<Segment>();
    public List<Segment> segments = new List<Segment>();

    //Gameplay
    private bool isMoving = false;

    private void Awake()
    {
        Instance = this;
        cameraContainer = Camera.main.transform;
        currentSpawnZ = 0;
        currentLevel = 0;

    }

    private void Start()
    {
        for (int i = 0; i < Initial_Segments; i++)
            GenerateSegments();
    }
    private void GenerateSegments()
        {
      //  SpawnSegment();

        if(Random.Range(0f,1f)<(contionousSegments * 0.25f))
        {
            //Spawn transition segment
            contionousSegments = 0;
            //SpawnTransition();
        }

    else
        {
            contionousSegments++;
        }
        
    }

    public Piece GetPiece(PieceType pt,int visualIndex)
    {
        Piece p = pieces.Find(x => x.type == pt && x.visualIndex == visualIndex && !x.gameObject.activeSelf);

        if (p == null)
        {
            GameObject go = null;
            if (pt == PieceType.longblock)
                go = longblock[visualIndex].gameObject;
            else if (pt == PieceType.PurpleLight)
                go = PurpleLight[visualIndex].gameObject;
            else if (pt == PieceType.GreenLight)
                go = GreenLight[visualIndex].gameObject;
            else if (pt == PieceType.OrangeLight)
                go = OrangeLight[visualIndex].gameObject;

            go = Instantiate(go);
            p = go.GetComponent<Piece>();
            pieces.Add(p);
        }

        return p;
    }
}


