Intro
========================
Welcome to use SimpleInteractSystem!

This system aims at providing a lightweight prototype of your own Interaction System.
It provides basic scripting structure and ui template.

You are able to aim at the 3d object that you wishes to interact with and see a world-space popup asking for pressing "e" for interaction.

After your key-pressing, a ui canvas demos all the interact option of this "interacatable" will be displayed and response as you click on the ui.

There's no restriction on rendering pipeline as the demo scene only uses the default material, so you can freely upgrade the materials as you wishes to.

I recommend to first check the Scene/Demo and press play.

Pre-request
========================
Using this asset requires you to import textmeshpro.

Installation
========================
Import this package and all are done!

Besides, there's a must to check video tutorial on the asset page to under how it works.
I will recommend to use this asset(https://github.com/mackysoft/Unity-SerializeReferenceExtensions) which helps directly support (InteractOption) subclass selection in inspector.

How to use
========================
To use this asset, you shall write your own scripts of "InteractOption".

As an Example, i've wrote the "InteractOptLogText" for you.
This will log text in the console.

For more details, please check the tutorial video on the assetstore page.

Documentation
================
API-References:
**Interactable**: This script shall be on any object that you wish to interact with.
Which is allowed to contains any number of interact options.

**InteractOption**: This scriptableobject is designed to contain the logic and data you will use when an option is selected to be done.

**InteractableRaycaster**: This utility scripts helps you to find interactable object in this scene by raycasting from your mouse position.
Once found, it will instruct that "Interactable" to show its world-space ui which tells player to do something to trigger Interact.

The Scripts/UI folder says itself quite clearly, i will not waste my words.

**InteractControl**: This gives a overall manager-like control script, this allows some custom behavior happened OnInteractStart and OnInteractOver.
For me, i will freeze the camera movement and unlock my mouse.Maybe you have your own requests.

**InteractInputListener**: A simple listener on key press behavior over keycode.e, once pressed, trigger the interact.
