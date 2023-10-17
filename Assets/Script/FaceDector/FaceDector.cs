using System.Collections;
using UnityEngine;
using OpenCvSharp;
using UnityEngine.UI;

public class FaceDector : MonoBehaviour
{
    WebCamTexture _WebCamTexture; // ウェブカムの映像をテクスチャとして保持する変数
    CascadeClassifier cascade; // Haar Cascade分類器を使用して顔を検出するための変数
    OpenCvSharp.Rect MyFace; // 検出された顔の座標情報を保持する変数
    GameObject placedObject; // 生成されたオブジェクトの参照を保持する変数

    public GameObject objectToPlace; // オブジェクトのプレハブをアサインするための変数

    void Start()
    {
        // ウェブカムのデバイスを取得して、ウェブカムテクスチャを初期化・再生する.要するに映像取得やな
        WebCamDevice[] devices = WebCamTexture.devices;
        _WebCamTexture = new WebCamTexture(devices[0].name);
        _WebCamTexture.Play();

        // Haar Cascade分類器を初期化する
        cascade = new CascadeClassifier(Application.dataPath + @"/Script/FaceDector/haarcascade_frontalface_default.xml");
    }

    void Update()
    {
        // ウェブカムの映像をテクスチャとしてマテリアルに設定する。
        GetComponent<Renderer>().material.mainTexture = _WebCamTexture;
        Mat frame = OpenCvSharp.Unity.TextureToMat(_WebCamTexture);

        // 顔を検出する
        findNewFace(frame);

        // 検出された顔があればオブジェクトを顔から一定距離離れた位置に配置する
        if (placedObject != null && MyFace != null)
        {
            // 顔の中心座標から一定距離離れた位置を計算する（ Z軸方向に200の位置に配置する）
            Vector3 offsetFromFaceCenter = new Vector3(0, 0, 200);
            Vector3 faceCenterWithOffset = new Vector3(MyFace.X + MyFace.Width / 2, MyFace.Y + MyFace.Height / 2, 0) + offsetFromFaceCenter;
            placedObject.transform.position = faceCenterWithOffset;
        }
        else
        {
            // 顔が検出されていない場合、生成されたオブジェクトがあれば破棄する
            if (placedObject != null)
            {
                Destroy(placedObject);
                placedObject = null;
            }
        }

        // OpenCVのMatをTextureに変換して表示する処理
        Texture newTexture = OpenCvSharp.Unity.MatToTexture(frame);
        GetComponent<Renderer>().material.mainTexture = newTexture;
    }

    void findNewFace(Mat frame)
    {
        // Haar Cascade分類器を使用して顔を検出する
        var faces = cascade.DetectMultiScale(frame, 1.1, 2, HaarDetectionType.ScaleImage);

        if (faces.Length >= 1)
        {
            Debug.Log(faces[0].Location);
            MyFace = faces[0];
            
            // 顔が検出されたらオブジェクトを生成する（一度だけ生成する）
            if (placedObject == null)
            {
                placedObject = Instantiate(objectToPlace);
            }
            
            // オブジェクトを顔が検出された場所に移動する
            Vector3 newPosition = new Vector3(MyFace.Location.X, MyFace.Location.Y, placedObject.transform.position.z);
            placedObject.transform.position = newPosition;
        }
        else
        {
            // 顔が検出されていない場合は何もしない
        }
    }
}
