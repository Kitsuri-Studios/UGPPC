# Unity General Purpose Player Controller
## Description
A character controller for [Unity Game Engine](https://unity.com/) providing basic mechanism for first person camera based player setup in the editor.

## Features
1. Walking with adjustable speed
2. First person camera movement
3. Basic Physics
4. Touch Controller
5. Sample joystick background and handle for testing

## How To Setup?

Following is a basic First Person Player Character Setup:

Right Click on the [Hierarchy Tab](https://docs.unity3d.com/6000.3/Documentation/Manual/Hierarchy.html) in the editor and create an empty GameObject. You can name this as **"Player"**.

<img width="252" height="479" alt="image" src="https://github.com/user-attachments/assets/d94de0be-6d45-4cf2-a6ec-d050366e89a5" /><br>



Select the "Player" Empty GameObject we just created and assign a [CharacterController Component](https://docs.unity3d.com/6000.3/Documentation/ScriptReference/CharacterController.html) from the [Inspector Tab](https://docs.unity3d.com/6000.3/Documentation/Manual/UsingTheInspector.html) and also assign [First Person Character Setup](https://github.com/Kitsuri-Studios/UGPPC/blob/0.1/dev.kitsuri.ugppc/Scripts/FirstPersonPlayerCharacterSetup.cs) script to it.

<img width="386" height="566" alt="image" src="https://github.com/user-attachments/assets/ffa4863d-68d7-49f9-a4bf-bd216dce1ccc" />
<br>
Your Inspector Tab will look like this.

<br><br>

Now Create another Empty GameObject in the hirerchy parenting to the **"Player"** GameObject. Name this new GameObject as **"CameraHolder"**. <br>
<br>
<img width="335" height="271" alt="image" src="https://github.com/user-attachments/assets/21b48fb5-9913-4bce-a069-fd63971cd796" />

Next create a Camera as the child of **"CameraHolder"** we just created


<img width="332" height="128" alt="image" src="https://github.com/user-attachments/assets/a4237be5-3f8d-4558-8676-b2df2ee3db24" />

### [The First Person Character Setup Script](https://github.com/Kitsuri-Studios/UGPPC/blob/0.1/dev.kitsuri.ugppc/Scripts/FirstPersonPlayerCharacterSetup.cs)
