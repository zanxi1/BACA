using UnityEngine;

using UnityEngine.UI;

public class AddMeshCollision : MonoBehaviour {
 
    // Use this for initialization
    void Update () {
        
        // Iterate through all child objects of our Geometry object
        foreach (Transform childObject in transform)
        {
            // First we get the Mesh attached to the child object
            Mesh mesh = childObject.gameObject.GetComponent<MeshFilter>().mesh;

            // If we've found a mesh we can use it to add a collider
            if (mesh != null && childObject.gameObject.GetComponent<MeshCollider>() == false)
            {                      
                // Add a new MeshCollider to the child object
                MeshCollider meshCollider = childObject.gameObject.AddComponent<MeshCollider>();

                // Finaly we set the Mesh in the MeshCollider
                meshCollider.sharedMesh = mesh;
            }
        }
        
    }
}