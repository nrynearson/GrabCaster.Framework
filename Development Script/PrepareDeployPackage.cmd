echo off
cls
echo Build the solution before running the bach.
pause

cd..
rd /s /q Setup\bin\Debug\Deploy
cd %~dp0

call DeployEventsDLLDebugversion.cmd
call DeployTriggerDLLDebugversion.cmd
call DeployEventsDLLReleaseversion.cmd
call DeployTriggerDLLReleaseversion.cmd

cd..

xcopy DefaultFiles\Demo\File2File\TestFile.txt Setup\bin\Debug\Deploy\*  /y
xcopy DefaultFiles\License.txt Setup\bin\Debug\Deploy\*  /y
xcopy "Batch Files\Create new Clone.cmd" Setup\bin\Debug\Deploy\*  /y
xcopy "Documentation\GrabCaster v1.0- Technical Manual.pdf" Setup\bin\Debug\Deploy\*  /y
xcopy Laboratory\bin\Debug\Laboratory.exe Setup\bin\Debug\Deploy\Demo\*  /y
xcopy Laboratory\bin\Release\Laboratory.exe Setup\bin\Release\Deploy\Demo\*  /y
xcopy Framework\bin\Debug\*.dll Setup\bin\Debug\Deploy\*  /y
xcopy Framework\bin\Debug\*.pdb Setup\bin\Debug\Deploy\*  /y
copy DefaultFiles\DeployDefault.cfg Setup\bin\Debug\Deploy\GrabCaster.cfg  /y
xcopy Framework\bin\Debug\*.exe Setup\bin\Debug\Deploy\*  /y

xcopy Framework\bin\Release\*.dll Setup\bin\Release\Deploy\*  /y
copy DefaultFiles\DeployDefault.cfg Setup\bin\Release\Deploy\GrabCaster.cfg  /y
xcopy Framework\bin\Release\*.exe Setup\bin\Release\Deploy\*  /y

xcopy DefaultFiles\BubblingDeploy Setup\bin\Debug\Deploy\Root_GrabCaster\Bubbling\ /s /y /e
xcopy DefaultFiles\BubblingDeploy Setup\bin\Release\Deploy\Root_GrabCaster\Bubbling\ /s /y /e

xcopy DefaultFiles\Demo Setup\bin\Debug\Deploy\Demo\* /s /y /e
xcopy DefaultFiles\PersistentStorage Setup\bin\Debug\Deploy\PersistentStorage\* /s /y /e

copy Framework.Log.EventHubs\bin\Debug\GrabCaster.Framework.Log.EventHubs.dll Setup\bin\Debug\Deploy\Root_GrabCaster\* /y
copy Framework.Log.EventHubs\bin\Release\GrabCaster.Framework.Log.EventHubs.dll Setup\bin\Release\Deploy\Root_GrabCaster\* /y


copy Framework.Dcp.Azure\bin\Debug\GrabCaster.Framework.Dcp.Azure.dll Setup\bin\Debug\Deploy\Root_GrabCaster\* /y
copy Framework.Dcp.Azure\bin\Release\GrabCaster.Framework.Dcp.Azure.dll Setup\bin\Release\Deploy\Root_GrabCaster\* /y

copy Framework.Dcp.Redis\bin\Debug\GrabCaster.Framework.Dcp.Redis.dll Setup\bin\Debug\Deploy\Root_GrabCaster\* /y
copy Framework.Dcp.Redis\bin\Release\GrabCaster.Framework.Dcp.Redis.dll Setup\bin\Release\Deploy\Root_GrabCaster\* /y

copy Framework.Dpp.Azure\bin\Debug\GrabCaster.Framework.Dpp.Azure.dll Setup\bin\Debug\Deploy\Root_GrabCaster\* /y
copy Framework.Dpp.Azure\bin\Release\GrabCaster.Framework.Dpp.Azure.dll Setup\bin\Release\Deploy\Root_GrabCaster\* /y


cd %~dp0
echo Deployment pachage ready to go.

