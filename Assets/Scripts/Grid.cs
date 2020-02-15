using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [Header("GameObject")]
    public GameObject gLake;//1.8
    public GameObject gGrass;//1.2
    public GameObject gSwamp;//2.0
    public GameObject gMount;//1.6
    public GameObject gJungle;//1.4
    public GameObject gHexagon;

    [Header("İnt")]
    public int iGridRow;
    public int iGridColumn;
    int iStartX;
    int icountRow;

    [Header("Float")]
    float  fStartY;

    private void Start()
    {
        createHexagon2();
    }
    void createHexagon2()
    {
        float xAdd;
        int currentGrid;
        float[] fMAssArray = { 1.2f, 1.4f, 1.6f, 1.8f };
        for (float y = 1f; y < iGridRow; y++)
        {
            if (y % 2 == 0)
            {
                xAdd = 0.85f;
                currentGrid = iGridColumn - 1;
            }
            else
            {
                xAdd = 0.0f;
                currentGrid = iGridColumn;
            }
            for (float x = 1f; x < currentGrid; x++)
            {
                float xPos = x * 1.7f + xAdd;
                float yPos = y * 1.5f;
                GameObject nobj = (GameObject)GameObject.Instantiate(gHexagon);
                nobj.transform.position = new Vector2(xPos, yPos);
                nobj.GetComponent<NeighborScript>().fMass = fMAssArray[Random.Range(0, fMAssArray.Length)];
                nobj.name = xPos + "," + yPos;
                if (nobj.GetComponent<NeighborScript>().fMass == 1.2f)
                {
                    nobj.GetComponent<Renderer>().material.color = new Color32(4, 144, 0, 255);
                }
                else if (nobj.GetComponent<NeighborScript>().fMass == 1.4f)
                {
                    nobj.GetComponent<Renderer>().material.color = new Color32(61, 188, 255, 255);
                }
                else if (nobj.GetComponent<NeighborScript>().fMass == 1.6f)
                {
                    nobj.GetComponent<Renderer>().material.color = new Color32(121, 71, 31, 255);
                }
                else if (nobj.GetComponent<NeighborScript>().fMass == 1.8f)
                {
                    nobj.GetComponent<Renderer>().material.color = new Color32(114, 104, 104, 255);
                }
                nobj.gameObject.transform.parent = gHexagon.transform.parent;
                nobj.SetActive(true);
                Rigidbody2D nobjRigid = nobj.AddComponent<Rigidbody2D>();
                nobjRigid.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }
    void createHexagon()
    {
        float xAdd;
        int currentGrid;
        GameObject[] gMapGameObjects = { gLake,gGrass,gSwamp,gMount,gJungle};
        for (float y = 1f; y < iGridRow; y++)
        {
            if(y % 2 == 0)
            {
                xAdd = 0.85f;
                currentGrid = iGridColumn - 1;
            }
            else
            {
                xAdd = 0.0f;
                currentGrid = iGridColumn;
            }
            for(float x = 1f; x < currentGrid; x++)
            {
                float xPos = x * 1.7f + xAdd;
                float yPos = y * 1.5f;
                GameObject nobj = (GameObject)GameObject.Instantiate(gMapGameObjects[Random.Range(0,gMapGameObjects.Length)]);
                nobj.transform.position = new Vector2(xPos,yPos);
                nobj.name = xPos + "," + yPos;
                nobj.gameObject.transform.parent = gGrass.transform.parent;
                nobj.SetActive(true);
                Rigidbody2D nobjRigid = nobj.AddComponent<Rigidbody2D>();
                nobjRigid.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }
}
