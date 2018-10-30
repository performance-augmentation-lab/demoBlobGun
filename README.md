**Demo template:  Spatial Mapping and Basic Interaction**

This unity project, available as a folder or .unitypackage, shows the 
basics of visualising the spatial map, creating a gameobject (with physics) 
and causing this to interact with the mesh.  <br />

__Demonstrates the use of:__
> A parent gameobject - BlobGun - container for blobs. <br />
> A child gameobject - Blob - based on prefab 'bubble'. <br />
> A single material and shader to give the blob a "glassy" appearence. <br />
> A script (fireBlob.cs) handling firing and reloading.  <br />

__Illustrates concepts of:__
Basic project structure and Holotoolkit components. <br />
Configuration of HoloLens camera, cursor and input manager. <br />
Modifying appearence and behaviour of gameobject. <br />
Visualisation of and interaction with the spatial map. <br />
Air tapping event handling. <br />
Use of kinematics and gravity. <br />

_Uses minimal Holotoolkit components for lightweight distribution: _
- core + input + spatial mapping
- no spatial understanding or sharing
- only essential utilities and UX
- total deploy size: approx. 125 Mb

*Built and tested using Unity 2017.4.14.f1 and HoloToolkit 2017.4.1.0*
