using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenCvSharp;
using UnityEngine.UI;
using OpenCvSharp.CPlusPlus;
public class FaceDector : MonoBehaviour
{
    // Start is called before the first frame update
    WebCamTexture _WebCamTexture;
    CascadeClassifier cascade;
    OpenCvSharp.Rect MyFace;
    void Start()
    {
     WebCamDevice[] devices =  WebCamTexture.devices;

     _WebCamTexture = new WebCamTexture(devices[0].name);
     _WebCamTexture.Play();
     cascade = new CascadeClassifier(Application.dataPath + @"/Script/FaceDector/haarcascade_frontalface_default.xml");   
    }

    // Update is called once per frame
void Update()
{
    GetComponent<Renderer>().material.mainTexture = _WebCamTexture;
    Mat frame = OpenCvSharp.Unity.TextureToMat(_WebCamTexture);
    findNewFace(frame);
    display(frame);
}
//HaarCascadeに関するもの
    void findNewFace(Mat frame){
        var faces = cascade.DetectMultiScale(frame, 1.1, 2, HaarDetectionType.ScaleImage);
        
        if(faces.Length >= 1){
           Debug.Log(faces[0].Location);
           MyFace = faces[0];
        }   
    }
    void display(Mat frame){
        if (MyFace != null){
            frame.Rectangle(MyFace,new Scalar(250,0,0),2);
        }
        Texture newtexture = OpenCvSharp.Unity.MatToTexture(frame);
        GetComponent<Renderer>().material.mainTexture = newtexture;
    }
}