using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class util : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public static string getFolderDataPath(string folderName){
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
	public static string[] getDataFilesFromPath(string folderName){
		DirectoryInfo info = new DirectoryInfo(getFolderDataPath(folderName));
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

	public static string getMobileDataPath (string DatabaseName){
		#if UNITY_EDITOR
		var dbPath = string.Format(@"Assets/StreamingAssets/{0}", DatabaseName);
		#else
		// check if file exists in Application.persistentDataPath
		var filepath = string.Format("{0}/{1}", Application.persistentDataPath, DatabaseName);

		if (!File.Exists(filepath))
		{
		Debug.Log("Database not in Persistent path");
		// if it doesn't ->
		// open StreamingAssets directory and load the db ->

		#if UNITY_ANDROID 
		var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + DatabaseName);  // this is the path to your StreamingAssets in android
		while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
		// then save to Application.persistentDataPath
		File.WriteAllBytes(filepath, loadDb.bytes);
		#elif UNITY_IOS
		var loadDb = Application.dataPath + "/Raw/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
		#elif UNITY_WP8
		var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
		#elif UNITY_WINRT
		var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
		#else
		var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
		#endif
		}

		var dbPath = filepath;
		#endif
		Debug.Log("Final PATH: " + dbPath);     
		return dbPath;
	}
}
