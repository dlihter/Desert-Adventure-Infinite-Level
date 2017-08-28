using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator instance;
    public List<LevelPiece> levelPrefabs = new List<LevelPiece>();
    public Transform levelStartPoint;
    public List<LevelPiece> pieces = new List<LevelPiece>();

    void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start ()
    {
        GenerateInitialPieces();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void GenerateInitialPieces()
    {
        for (int i = 0; i < 3; i++)
        {
            AddPiece();
        }
    }

    public void AddPiece()
    {
        int randomIndex = Random.Range(0, levelPrefabs.Count - 1);
        LevelPiece piece = (LevelPiece) Instantiate(levelPrefabs[randomIndex]);
        piece.transform.SetParent(transform, false);

        Vector3 spawnPosition = Vector3.zero;

        //startPoint i exitPoint se nalaze na LevelPiece skripti
        if (pieces.Count == 0) 
        {
            //ovdje računamo offset između početne točke savnanja i start point točke na prefabu.
            spawnPosition = levelStartPoint.position - piece.startPoint.localPosition;
        }
        else
        {
            spawnPosition = pieces[pieces.Count - 1].exitPoint.position - pieces[pieces.Count-1].startPoint.localPosition;
            //spawnPosition = pieces[pieces.Count - 1].exitPoint.position;
        }

        piece.transform.localPosition = spawnPosition;
        pieces.Add(piece);
    }

    public void RemoveOldestPiece()
    {
        LevelPiece oldestPiece = pieces[0];

        pieces.Remove(oldestPiece);
        Destroy(oldestPiece.gameObject);
    }

}
