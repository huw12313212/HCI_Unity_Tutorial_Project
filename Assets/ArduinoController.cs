using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;

public class ArduinoController : MonoBehaviour 
{	
	SerialPort sp = new SerialPort("/dev/tty.usbmodem1411", 115200);

	public Rigidbody rigidBody;
	public float jumpSpeed = 10;
	
	void Start () {
		
		List<string> serial_ports = new List<string> ();
		string[] ttys = Directory.GetFiles ("/dev/", "tty.*");
		foreach (string dev in ttys) 
		{
			Debug.Log (dev);
		}
		
		sp.ReadBufferSize = 8192;
		sp.WriteBufferSize = 128;
		sp.ReadBufferSize = 4096;
		sp.ReadTimeout = 1;
		sp.Parity = Parity.None;
		sp.StopBits = StopBits.One;
		sp.DtrEnable = true;
		sp.RtsEnable = true;
		sp.Open ();
	}
	
	byte data = 0;
	
	void Update () 
	{
		int byteToRead = sp.BytesToRead;
		if (sp.BytesToRead >0) 
		{
			if(sp.ReadChar() == '1')
			{
				Debug.Log ("jumnp");
				rigidBody.velocity = new Vector3(0,jumpSpeed,0);
			}
		}
	}
	
}