using UnityEngine;

public enum PieceType
{
    none = -1,
    longblock = 0,
    PurpleLight = 1,
    GreenLight = 2,
    OrangeLight = 3,
}

public class Piece : MonoBehaviour {
    public PieceType type;
    public int visualIndex;
	
}
