using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using round;

public class util : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	//getFolderPathNextToAppFile Gets the path of a folder next to the binary app (compilated).
	public static string getFolderPathNextToAppFile(string folderName){
		string folderPath="";
		#if UNITY_EDITOR
		folderPath = Application.dataPath + "/StreamingAssets/"+folderName+"/";
		#elif UNITY_WINRT
		folderPath = Application.dataPath + "/"+folderName+"/"; //.exe file is next to the folder.
		#elif UNITY_STANDALONE_OSX
		folderPath = new DirectoryInfo(Application.dataPath).Parent.Parent.ToString()+"/"+folderName+"/"; //OSX the path is inside the .app, this change the path 2 levels up in order to access the 
		#endif
		
		return folderPath;
	}
	//getDataFilesFromPath gets the .json files files from path
	public static string[] getJsonFilesFromPath(string folderPath){
		DirectoryInfo info = new DirectoryInfo(folderPath);
		FileInfo[] files= info.GetFiles();
		//string[] filesStr= new string[files.Length];
		List<string> filesStr = new List<string>();
		for(int i =0;i<files.Length;i++){
			string auxFile=files[i].ToString();
			if(auxFile.EndsWith(".json")){
				filesStr.Add(auxFile);
			}else{
				continue;
			}
		}
		return filesStr.ToArray();
	}
	//getRoundsFromFolder Returns all the parsed Round objects from the folder.
	public static Round[] getRoundsFromFolder(string RoundsFolderName){
		List<Round> rounds = new List<Round>();
		string folderPath=util.getFolderPathNextToAppFile(RoundsFolderName); //Gets the folder name (next to the binary app (.app .exe))
		string[] filePaths = util.getJsonFilesFromPath(folderPath); //Gets the json files inside the folder.
		foreach(string file in filePaths){ 	//Iterate between all the names.
			//Debug.Log("checking:"+ file);	//Log if the files adress is correct
			System.IO.StreamReader reader = new System.IO.StreamReader(file);  // Reads the json file
        	string jsonContent = reader.ReadToEnd(); //gets the string
            reader.Close();	//Closes the file
			rounds.Add(Round.FromJson(jsonContent));//Convert the text to data.

			//foreach(RoundElement re in r.Rounds){	//Debug: make sure the data is okay 
				//Debug.Log("-"+re.Question); //Log the question names
			//}
		}
		return rounds.ToArray();
	}

	
}
