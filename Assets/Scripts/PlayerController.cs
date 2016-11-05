using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Camera cam;
    private float maxWidth;
    private float maxHeight;

  //  bool isHandOpen = true;
  //  public Sprite clickedSprite;
   // private Sprite standardSprite;

//    private SignalRUnityController _signalr;

    void Start()
    {
        if (cam == null)
            cam = Camera.main;

   //     _signalr = GameObject.Find("SignalRObject").GetComponent<SignalRUnityController>();

        var corner = new Vector3(Screen.width, Screen.height, 0f);
        var targetWidth = cam.ScreenToWorldPoint(corner);
        float playerWidth = GetComponent<Renderer>().bounds.extents.x;
        float playerHeight = GetComponent<Renderer>().bounds.extents.y;
        maxWidth = targetWidth.x - playerWidth;
        maxHeight = targetWidth.y - playerHeight;

    //    standardSprite = this.GetComponent<SpriteRenderer>().sprite;

    }
    void FixedUpdate()
    {
        var currentPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        float targetWidth = Mathf.Clamp(currentPosition.x, -maxWidth, maxWidth);
        float targetHeight = Mathf.Clamp(currentPosition.y, -maxHeight, maxHeight);
        var newPosition = new Vector3(targetWidth, targetHeight, 0f);
        GetComponent<Rigidbody2D>().MovePosition(newPosition);

        if (Input.GetMouseButtonDown(0))
        {
     //       isHandOpen = false;
            MouseDown();
        }
        else if (Input.GetMouseButtonUp(0))
        {
    //        isHandOpen = true;
            MouseUp();
        }

   //     var worldCoordinates = cam.WorldToScreenPoint(newPosition);
    //    var json = "{" + string.Format("\"x\": \"{0}\", \"y\": \"{1}\", \"handOpen\": \"{2}\"", worldCoordinates.x, worldCoordinates.y, isHandOpen) + "}";
        //var json = "{\"x:791, y:10,handOpen: True\"}";
      //  Debug.Log(json);
      //  _signalr.Send("Position", json);

    }

    private void MouseDown()
    {
      //  Debug.Log("MouseDown");

    }

    private void MouseUp()
    {
   //     Debug.Log("MouseUp");

    }
    public static void Receive()
    {
   //     Debug.Log("Change position from controller");
        //var newPosition = new Vector3(450, 175, 0f);
        //GetComponent<Rigidbody2D>().MovePosition(newPosition);

    }

}
