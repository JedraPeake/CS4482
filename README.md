# CS4482

### Table of Contents
App
* [APP 1 – Learn your SDK](https://github.com/JedraPeake/CS4482#app-1--learn-your-sdk)
* [APP 2 – Dart Tag: Not Just for Kids](https://github.com/JedraPeake/CS4482#app-2--dart-tag:-not-just-for-kids)
* [APP 3 – Write a full game](https://github.com/JedraPeake/CS4482#app-3--write-a-full-game)

Tools
* [TOOLS 1 – Learn the Unity Editor API](https://github.com/JedraPeake/CS4482#tools-1--learn-the-unity-editor-api)
* [TOOLS 2 – Language and Localization](https://github.com/JedraPeake/CS4482#tools-2--language-and-localization)
* [TOOLS 3 – Dialog Editor](https://github.com/JedraPeake/CS4482#tools-3--dialog-editor)

Optional
* [Shaders](https://github.com/JedraPeake/CS4482#shaders)


## App
#### APP 1 – Learn your SDK
1. [x] Do tutorials
   - Tutorial 1: https://learn.unity.com/tutorial/using-the-unity-interface
   - Tutorial 2: https://learn.unity.com/project/roll-a-ball-tutorial
   - Tutorial 3: https://learn.unity.com/project/karting-template
2. [x] Hand in source code (your files only, I don’t want the whole engine) and a binary of a simple, running, demo built on your SDK of choice.

#### APP 2 – Dart Tag: Not Just for Kids
The CEO of your burgeoning company comes to you late on a Friday after noon (as it is always) and tells you that we have to have the prototype of the newest hotness ready to go by Monday or you’ll lose your window for greatness
1. [x] 2 types of players AI and controlled
2. [x] Players must be animated(run-cycle, walk-cycle), and have 3d meshes.
3. [x] Each player must fire a projectile to tag their opponent
4. [x] You must indicate which player is it in an obvious way
5. [x] Keep a score for each player, and end the game after 5 minutes
6. [x] Create in-game menus (start, pause, leader board, exit)

#### APP 3 – Write a full game
You’re at the end of the APP skill line. It’s time to write a “full” game in the SDK of your choice.
1. [x] Design a simple game. Seriously, make it simple. You are not being graded on the
design (that’s Mike K’s class next term)... the point is just for you to come up with
something that’s going to be fun for you to write.
2. [x] Write up a list of requirements for yourself.
3. [x] Get approval from Alex (send an e-mail). Do not proceed without approval.
4. [x] Implement the game using the SDK with which you are now comfortable.

## Tools
#### TOOLS 1 – Learn the Unity Editor API
1. [x] Successfully complete a collection of editor API Tutorials
   - Tutorial 1: https://learn.unity.com/tutorial/using-the-unity-interface
   - Tutorial 2: https://learn.unity.com/tutorial/property-drawers-and-custom-inspectors
   - Tutorial 3: https://learn.unity.com/tutorial/editor-scripting#
2. [x] Create  your  own  asset  (ScriptableObjectorMonoBehavior)  and  demonstrate  your newly found editor knowledge by writing a custom editor for it (avoid simply writing the default editor).
3. [x] Bonus marks for making use of Property Drawers

#### TOOLS 2 – Language and Localization
You must create a system that will not only ease editing of text, but also allow the game to switch seamlessly between languages.  Your system should do the following:
1. [x] Use the Unity3D Editor API to create your tools
2. [x] Define a set ofScriptableObjectclasses that will support 1...N languages containing1...N strings each
3. [x] Write a collection of CustomEditors that make it easier to create, add to, and edit Languages and their key-value pairs. Note: You may choose to author your data outside of Unity. However, if you must im-plement aScriptedImporter1that will generate equivalent ScriptableObjects (.asset) with CustomEditors to visualize your localization data
4. [x] Use the Unity UI system to create a text box that utilizes your language data. You can reference string by name, id, or other
5. [x] Your text box contents must update when you change the selected language of your engine

#### TOOLS 3 – Dialog Editor
You must create a dialog editor that leverages your language data and custom editors in order to create dialog trees for NPC characters in your game:
1. [x] Use the Unity3D Editor API to create your tools.
2. [x] Create a dialog editor with support for branching response trees.
3. [x] Provide support for cyclical dialogs to occur within your dialog tree (and don’t duplicate data!).
4. [x] Use your language assets from the previous TOOLS assignments to populate your
dialog system.
5. [x] Implement your dialog system by continuing to leverage ScriptableObjects (.assset).

## Optional
#### Shaders
You are being asked to write three shaders for this assignment: one for a full screen effect, one for a (convincing) cel-shading effect, and one for a gradient mapping effect.
