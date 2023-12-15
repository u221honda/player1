using System.Collections;
using UnityEngine;
using OpenCvSharp;

public class FaceDector : MonoBehaviour
{
    WebCamTexture _WebCamTexture;
    CascadeClassifier cascade;
    OpenCvSharp.Rect MyFace;
    GameObject placedObject;

    public GameObject objectToPlace;

    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        _WebCamTexture = new WebCamTexture(devices[0].name);
        _WebCamTexture.Play();

        cascade = new CascadeClassifier(Application.dataPath + @"/Script/FaceDector/haarcascade_frontalface_default.xml");
    }

    void Update()
    {
       // GetComponent<Renderer>().material.mainTexture = _WebCamTexture;
        Mat frame = OpenCvSharp.Unity.TextureToMat(_WebCamTexture);

        findNewFace(frame);
        display(frame);

          // 検出された顔があればオブジェクトを顔と同じ座標に配置するようにしたい
  /*  if (placedObject != null && MyFace != null)
    {
        // 顔の中心座標を取得
        Vector3 faceCenter = new Vector3(MyFace.X - MyFace.Width / 2 - 500, MyFace.Y + MyFace.Height / 2 - 500, 0);

        // 顔の検出位置の200分の1にする
        faceCenter /= 100f;
        // Z座標を20に設定
        faceCenter.z = 20f;
        // オブジェクトの座標を設定
        placedObject.transform.position = faceCenter;
    

    }*/
    }
   
    void findNewFace(Mat frame)
    {
        var faces = cascade.DetectMultiScale(frame, 1.1, 2, HaarDetectionType.ScaleImage);

        if (faces.Length >= 1)
        {
            Debug.Log(faces[0].Location);
            MyFace = faces[0];

            // 顔が検出されたらオブジェクトを生成する（一度だけ生成する）
            if (placedObject == null)
            {
                placedObject = Instantiate(objectToPlace);
                placedObject.transform.position = new Vector3(0f, 0f, 0f); 
            }
        }
       
    }
    void display(Mat frame)
    {     // 青い四角を表示する
        if (MyFace != null)
        {
            frame.Rectangle(MyFace, new Scalar(250, 0, 0), 2);
        }

        // OpenCVのMatをTextureに変換して表示する処理
        Texture newTexture = OpenCvSharp.Unity.MatToTexture(frame);
        GetComponent<Renderer>().material.mainTexture = newTexture;
    }

}
