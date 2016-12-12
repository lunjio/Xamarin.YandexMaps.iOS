using System;
using ObjCRuntime;

[assembly: LinkWith ("libYandexMapKit.a", LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64, 
    ForceLoad = true, 
    SmartLink = true,
    Frameworks = "CoreTelephony SystemConfiguration Security OpenGLES OpenAL MessageUI CoreLocation CoreData AudioToolbox AVFoundation QuartzCore UIKit Foundation",
    LinkerFlags = "-all_load -ObjC -lstdc++ -lz -lsqlite3 -lxml2",
    IsCxx = true)]
