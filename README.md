---
title: 'Family Feud'

---
###### tags:  `EBRON` `EBRON.TECH` `unity` `church`

# Family Feud
This project has been designed to be used as group game in any church. for now this version It's being used at multiple congress at [Iglesia Familar Cristiana Guadalajara](http://ifcgdl.com/).
![](https://i.imgur.com/wgg6WpO.jpg)
![](https://i.imgur.com/jygvcGa.jpg)
![](https://i.imgur.com/IxCRUdU.jpg)


## ⚠️Alpha version can be download at release section ⚠️


If you are a normal user please read the [~~user documentation~~]() that covers the basics about how to use the Board, the controller board, and add your own questions and responses to the game.
## Button
One necessary part of this game is the button (it's used to know who is the first player.)  
In order to make your own button follow the documentation schematics, how to build it and source code in this repository [FamilyFeudButton](https://github.com/ebron-tech/FamilyFeudButton).
## Dev
Assuming you are a developer, have some coding knowledge or just a Unity3d fan. The project was made with:
1. Unity 2019.1.8f1.
    1. Shader Graph (5.7.2) (download from Unity package manager).
    2. Lightweight RP (5.7.2) (download from Unity package manager).
    3. OSC communication protocol [git package](https://github.com/jorgegarcia/UnityOSC).
        1. Deployed the git repo inside /OSC

The binaries contain 3 elements:
1. The app ( the build compiled for Windows and OSX).
2. The controller app ( another app that is used to control the main board).
3. The rounds folder ( next to the apps): inside this folder are stored all the rounds in .json format.

The project can be build for OSX and Windows. but its not limited to that platforms, the communication protocol is OSC that enables the program to be build for android, iOS, and Linux. it's possible to have the controller in one platform and the dashboard running in other different.


