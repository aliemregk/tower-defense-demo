using UnityEngine;

public class CameraControl : MonoBehaviour
{
    bool move = true;
    float speed = 30;
    float scrollSpeed = 5;
    float minY = 20, maxY = 50;
    float minX = -60, maxX = 57;
    float minZ = -94, maxZ = -23;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.IsOver)
        {
            this.enabled = false;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            move = !move;
        
        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 currentPosition = transform.position;
        currentPosition.y -= scroll * scrollSpeed *  Time.deltaTime * 1000;
        currentPosition.y = Mathf.Clamp(currentPosition.y, minY, maxY);
        currentPosition.x = Mathf.Clamp(currentPosition.x, minX, maxX);
        currentPosition.z = Mathf.Clamp(currentPosition.z, minZ, maxZ);

        transform.position = currentPosition;
    }
}
