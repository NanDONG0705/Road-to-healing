
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using TMPro;
using System.Text;
using UnityEditor.Experimental.GraphView;


using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using TMPro;
using UnityEngine.SceneManagement;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;
using System.Globalization;
using System.Linq.Expressions;
using System.Linq;
using System.Collections.Generic;


public class VRChange : MonoBehaviour
{

    public InputActionReference input;
    public AlongPointMove alongPointMove;
    public GameObject locamotion;
    public bool Moveable = false;
    //public string action="0";
    //public ExerciseType action;


    //Parameter Prep. for Data from UDP
    [HideInInspector] public bool isTxStarted = false;

    [SerializeField] string IP = "127.0.0.1"; // local host
    [SerializeField] int rxPort = 8000; // port to receive data from Python on
    [SerializeField] int txPort = 8001; // port to send data to Python on

    //Redefine in seperate file
    //public enum ExerciseType
    //{
    //    ANKLE_PUMP = 1,
    //    ANKLE_ROTATION = 2,
    //    QUADRICEPS_SET = 3,
    //    STRAIGHT_LEG_RAISES = 4,
    //    BED_SUPPORTED_KNEE_BENDS = 5,
    //    SITTING_UNSUPPORTED_KNEE_BENDS = 6
    //};

    string[] ExerciseTypeName = { "Ankle Pump", "Ankle Rotation", "Quadriceps Set",
                                "Straight Leg Raises", "Bed Supported Knee Bends", "Sitting Unsupported Knee Bends" };

    UdpClient client;
    IPEndPoint remoteEndPoint;
    Thread receiveThread; // Receiving Thread

    //public Text ScoreText;
    [SerializeField]
    private TMP_Text scoreText;
    private TMP_Text hintText;
    private TMP_Text titleText;

    String tempStr = "{'UDPDataType_HINT': 'Continue to raise '}";


    //TODO: Set current exercise type via Unity Inspector
    //Here set the defualt type
    [SerializeField]
    public ExerciseType currExerciseType = ExerciseType.SITTING_UNSUPPORTED_KNEE_BENDS;

    public int gameType;

    ExerciseType prevExerciseType;

 

    // Start is called before the first frame update
    void Start()
    {
        //Know which action
        //Send to Python via UDP

        Debug.Log("Current Exercise Type: " + currExerciseType);

        //Find score and hint text
        //scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
        hintText = GameObject.Find("HintText").GetComponent<TMP_Text>();
        //titleText = GameObject.Find("TitleText").GetComponent<TMP_Text>();

        //Debug.Log("!!!!!!!" + scoreText.text);
        //scoreText.text = "0";
        hintText.text = "Hi~";
        //titleText.text = ExerciseTypeName[(int)currExerciseType - 1];

        prevExerciseType = currExerciseType;
    }


    public void ScripeSwitch()
    {

        locamotion.SetActive(true);
        Moveable = false;

    }

    //String prevStr = "tempStr";
    String prevStr = "{'UDPDataType_HINT': 'Continue to raise '}";
    String prevStatus = "tempStr";
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(currExerciseType);

        if (currExerciseType != prevExerciseType)
        {
            //Send Scene type to inform Python Side
            SendData("Ex Type:" + (int)currExerciseType);
            prevExerciseType = currExerciseType;
        }

        //Receive a new pack
        //  && not the same status as the previous



        if (!String.Equals(prevStr, tempStr))
        {
            //Debug.Log("Temp str is " + tempStr);
            var details = JObject.Parse(tempStr);

            //Update the text
            hintText.text = string.Concat("", details["UDPDataType_HINT"]);

            //scoreText.text = string.Concat("", details["UDPDataType_SCORE"]);

            //TODO: Map the hint text to corresponding action status
    

            String curStatus  = string.Concat("", details["UDPDataType_HINT"]).Substring(0, 7);
            String prevStatus = string.Concat("", JObject.Parse(prevStr)["UDPDataType_HINT"]).Substring(0, 7);

           

            if (!String.Equals(curStatus.Substring(0, 7), prevStatus.Substring(0, 7)))
            {
                Debug.Log(curStatus.Substring(0, 7));
                updateCurrActionResponse(hintText.text);//Ankle Pump --> One raise the foot}

            }

            //Update prevStr 
            prevStr = tempStr;
        }


        //if (input.action.WasPressedThisFrame() && Moveable)
        //{
        //    Debug.Log("A ");
        //    locamotion.SetActive(false);
        //    alongPointMove.enabled = true;
        //}
    }


    public void updateCurrActionResponse(string message)
    {
        //Debug.Log(currExerciseType);

        if (Moveable)
        {
            switch (currExerciseType)
            {
                case ExerciseType.ANKLE_PUMP:

                    //1st Game Type: --> Cross Over
                    if (gameType == 1)
                    {
                        if (message.IndexOf("Awesome") != -1)//Reach the ankle raising position
                        { //Revise with reach the position
                          //     Debug.Log("A ");
                            locamotion.SetActive(false);
                            alongPointMove.enabled = true;

                            Debug.Log("Reach the ankle position!");
                        }
                    }

                    //2nd Game Type: --> Cross Below
                    if (gameType == 2)
                    {
                        if (message.IndexOf("Congratulation") != -1)//Reach the ankle raising position 10s and release
                        { //Revise with reach the position
                          //     Debug.Log("A ");
                            locamotion.SetActive(false);
                            alongPointMove.enabled = true;

                            Debug.Log("Ankle in position -> ready to release!");
                        }
                    }


                    break;
                case ExerciseType.ANKLE_ROTATION:

                    //3rd Game Type: -->  boating
                    if (gameType == 3)
                    {
                        if (message.IndexOf("Outward") != -1)
                        { //Revise with reach the position
                          //     Debug.Log("A ");
                            locamotion.SetActive(false);
                            alongPointMove.enabled = true;

                            Debug.Log("Reach out-most!");
                        }
                        else if (message.IndexOf("Inward") != -1)
                        {
                            locamotion.SetActive(false);
                            alongPointMove.enabled = true;

                            Debug.Log("Reach inner-most!");

                        }

                        //else { 
                        //}

                    }





                    break;
                case ExerciseType.QUADRICEPS_SET:
            



                    break;
                case ExerciseType.STRAIGHT_LEG_RAISES:


                    //5th Game Type: -->  Cross Bridge
                    if (gameType == 5)
                    {
                        if (message.IndexOf("Awesome") != -1)//Reach the ankle raising position
                        { //Revise with reach the position
                          //     Debug.Log("A ");
                            locamotion.SetActive(false);
                            alongPointMove.enabled = true;

                            Debug.Log("Reach right leg max position!");
                        }
                    }




                    break;
                case ExerciseType.BED_SUPPORTED_KNEE_BENDS:
                    if (message == "One bend the knee")
                    {
                        //Do something
                    }


                    break;
                case ExerciseType.SITTING_UNSUPPORTED_KNEE_BENDS:
                    //7th Game Type: -->  Ropeway 
                    if (gameType == 7)
                    {
                        if (message.IndexOf("Awesome") != -1)//Reach the ankle raising position
                        { //Revise with reach the position
                          //     Debug.Log("A ");
                            locamotion.SetActive(false);
                            alongPointMove.enabled = true;

                            Debug.Log("Reach the sitting knee bends max position!");
                        }
                    }


                    break;
            }

        }



    }








    //Helper Methods
    public void SendData(string message) // Use to send data to Python
    {
        try
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            client.Send(data, data.Length, remoteEndPoint);
            //Debug.Log("2. Data sent");
        }
        catch (Exception err)
        {
            Debug.Log("2." + err.ToString());
        }
    }

    void Awake()
    {
        // Create remote endpoint (to Matlab) 
        remoteEndPoint = new IPEndPoint(IPAddress.Parse(IP), txPort);

        // Create local client
        client = new UdpClient(rxPort);

        // local endpoint define (where messages are received)
        // Create a new thread for reception of incoming messages
        receiveThread = new Thread(new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();

        // Initialize (seen in comments window)
        Debug.Log("1.UpdSocker UDP Comms Initialized");

        //StartCoroutine(SendDataCoroutine()); // DELETE THIS: Added to show sending data from Unity to Python via UDP
    }

    // Receive data, update packets received
    private void ReceiveData()
    {
        while (true)
        {
            try
            {
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] data = client.Receive(ref anyIP);
                string text = Encoding.UTF8.GetString(data);

                //ScoreText.text = "1abc";
                Debug.Log("1.UpdSocker>> " + text);
                tempStr = text;

                //SendData("Sent From Unity: ");
                //ScoreText.text = "2abc";
                //ProcessInput(text);
            }
            catch (Exception err)
            {
                Debug.Log(err.ToString());
            }
        }
    }

    //Prevent crashes - close clients and threads properly!
    void OnDisable()
    {
        if (receiveThread != null)
            receiveThread.Abort();

        client.Close();
    }

    void OnApplicationQuit()
    {
        Debug.Log("Application ending after " + Time.time + " seconds");
        if (receiveThread != null)
            receiveThread.Abort();

        client.Close();
    }







}



