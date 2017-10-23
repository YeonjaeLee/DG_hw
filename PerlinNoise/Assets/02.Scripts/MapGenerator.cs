using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    [Header("[블록]")]
    public GameObject SoilPrefab;
    public GameObject GoldPrefab;
    public GameObject DiaPrefab;
    public GameObject GrassPrefab;
    public GameObject SandPrefab;

    [Header("[맵 정보]")]
    public int Width_x = 0;
    public int Width_z = 0;
    public float Wavelength = 0;    // 파장
    public float Amplitude = 0;     // 진폭 (최대 높이 값)

    private List<GameObject> BlockList = new List<GameObject>();

    void Start () {
		for(int x=0; x<Width_x;x++)
        {
            for(int z=0; z< Width_z; z++)
            {
                BlockList.Add((GameObject)Instantiate(SoilPrefab, new Vector3(x, 0, z), Quaternion.identity));
            }
        }

        for(int i=0; i<BlockList.Count; i++)
        {
            float xCoord = (BlockList[i].transform.position.x) / Wavelength;
            float zCoord = (BlockList[i].transform.position.z) / Wavelength;
            int y = (int)(Mathf.PerlinNoise(xCoord, zCoord) * Amplitude);
            BlockList[i].transform.position = new Vector3(BlockList[i].transform.position.x, y, BlockList[i].transform.position.z);
        }
	}

    public bool Istest = false;
	void Update () {
        if (!Istest)
            return;
        for(int i=0; i<BlockList.Count; i++)
        {
            float xCoord = (BlockList[i].transform.position.x) / Wavelength;
            float zCoord = (BlockList[i].transform.position.z) / Wavelength;
            int y = (int)(Mathf.PerlinNoise(xCoord, zCoord) * Amplitude);
            BlockList[i].transform.position = new Vector3(BlockList[i].transform.position.x, y, BlockList[i].transform.position.z);
        }
    }
}
