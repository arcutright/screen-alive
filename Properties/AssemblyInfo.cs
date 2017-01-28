#region header

// ScreenAlive - AssemblyInfo.cs
// 
// Aaron Cutright
// Copyright Cutright Industries 2017.
// 
// Forked from 
// https://mousejiggler.codeplex.com
// Alistair J. R. Young
// Arkane Systems
// Copyright Arkane Systems 2012-2013.

#endregion

using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.

[assembly: AssemblyTitle("ScreenAlive")]
[assembly: AssemblyDescription("A utility to keep the screen alive (keeps the screensaver from activating or the screen from dimming) whenever specified applications are running. This works by scanning open windows for specified window titles. When a title matches (case sensitive!), ScreenAlive will keep the screensaver from activating as long as 'Enable ScreenAlive' is checked. The program works by virtually 'jiggling' the mouse (this is the 'Zen Jiggle' mode) to make Windows think that the user is active. If 'Zen Jiggle' is deactivated, the user's mouse will regularly move, and should only be used if Zen Jiggle does not work. Full list of functionality at https://github.com/arcutright/screen-alive")]
[assembly: AssemblyConfiguration ("")]
[assembly: AssemblyTrademark ("")]
[assembly: AssemblyCulture ("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.

[assembly: ComVisible (false)]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]

[assembly: NeutralResourcesLanguage ("en-US")]
[assembly: AssemblyCompany("Cutright Industries")]
[assembly: AssemblyProduct("ScreenAlive")]
[assembly: AssemblyCopyright("Copyright © Aaron Cutright 2017")]
[assembly: AssemblyVersion("1.1.0.0")]
[assembly: AssemblyFileVersion("1.1.0.0")]
[assembly: Guid("e1fc2039-43a7-4843-8a43-8f896c257adc")]

