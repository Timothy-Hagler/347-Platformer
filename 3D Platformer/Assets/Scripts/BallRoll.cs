using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRoll : MonoBehaviour
{

    public bool ballRollAvailable;
    public bool ballRollActive;
    public MeshFilter playerMesh;
    public MeshFilter polarBearMesh;
    private MeshFilter t_Mesh;
    private bool meshIsChanged;
    // Start is called before the first frame update
    void Start()
    {
        t_Mesh = playerMesh;
    }

    // Update is called once per frame
    void Update()
    {
        if (ballRollActive && !meshIsChanged)
        {
            changeMesh();
            Debug.Log("changing mesh");
        }
        else if (!ballRollActive && meshIsChanged)
        {
            resetMesh();
            Debug.Log("resetting mesh");
        }
            

    }

    public void SetBallRollAvailable(bool value)
    {
        ballRollAvailable = value;
    }

    

    public void changeMesh()
    {
        playerMesh.mesh = polarBearMesh.mesh;
        meshIsChanged = true;
    }

    public void resetMesh()
    {
        this.playerMesh.mesh = this.t_Mesh.mesh;
        meshIsChanged = false;
    }
}
