README
======

This project provides a (very) simple method of previewing autocad DWG files using a C# user control. I'll say this again this is a basic control only. It uses the same thumbnail used when previewing in explorer but changes the background for easier viewing (at least when the file uses a dark bg)

I provide zero warranty or garentee of any kind. If this breaks things i accept no responsibility.

That being said I've yet to break things during my tests.

INSTALL
=======

Create a Visual Studio Project (.dll) and add the user control and Calss1.cs (Class1 is just a basic class to show you how things are working) 

Add the autocad dll's to the project (AcMgd.dll and AcDbMgd.dll)

Make sure you are using the right .NET framework for your version of autocad. Im using 2010 with .Net V3.5sp1 that's the only version i have tested on.

Compile.

Use netload to load the dll.

Run the commands

Enjoy!

Major Changes
=============

30/11/11 - Initial Version
