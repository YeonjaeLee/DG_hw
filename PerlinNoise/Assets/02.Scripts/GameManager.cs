using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	//[Header("[블록]")]
    private GameObject SoilPrefab;
    private List<GameObject> BlockList = new List<GameObject>();

    [Header("[맵 정보]")]
    private int Width_x = 50;
    private int Width_z = 50;
    public float Wavelength = 0;    // 파장
    public float Amplitude = 0;     // 진폭 (최대 높이 값)
    
    public Vector3 Obpos;

    private void Awake () {
        SoilPrefab = Resources.Load<GameObject>("03.Prefabs/Soil");

        for (int x=0; x<Width_x;x++)
        {
            for(int z=0; z< Width_z; z++)
            {
                //BlockList.Add(Instantiate(SoilPrefab, new Vector3(x, 0, z), Quaternion.identity));
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = new Vector3(x, 0, z);
                cube.AddComponent<Block>();
                BlockList.Add(cube);
            }
        }

        for(int i=0; i<BlockList.Count; i++)
        {
            float xCoord = (BlockList[i].transform.position.x) / Wavelength;
            float zCoord = (BlockList[i].transform.position.z) / Wavelength;
            float y = Mathf.PerlinNoise(xCoord, zCoord) * Amplitude;
            BlockList[i].transform.position = new Vector3(BlockList[i].transform.position.x, y/2, BlockList[i].transform.position.z);
            BlockList[i].transform.localScale = new Vector3(1, y, 1);
        }
	}
}
