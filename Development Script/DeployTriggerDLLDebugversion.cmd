echo off
cd..
xcopy Triggers\AzureBlobTrigger\bin\Debug\GrabCaster.Framework.AzureBlobTrigger.dll Setup\bin\Debug\Deploy\Root_GrabCaster\Triggers\* /y
xcopy Triggers\AzureQueueTrigger\bin\Debug\GrabCaster.Framework.AzureQueueTrigger.dll Setup\bin\Debug\Deploy\Root_GrabCaster\Triggers\* /y
xcopy Triggers\AzureTopicTrigger\bin\Debug\GrabCaster.Framework.AzureTopicTrigger.dll Setup\bin\Debug\Deploy\Root_GrabCaster\Triggers\* /y
xcopy Triggers\BULKSQLServerTrigger\bin\Debug\GrabCaster.Framework.BulksqlServerTrigger.dll Setup\bin\Debug\Deploy\Root_GrabCaster\Triggers\* /y
xcopy Triggers\CSharpTrigger\bin\Debug\GrabCaster.Framework.CSharpTrigger.dll Setup\bin\Debug\Deploy\Root_GrabCaster\Triggers\* /y
xcopy Triggers\ETW\bin\Debug\GrabCaster.Framework.EtwTrigger.dll Setup\bin\Debug\Deploy\Root_GrabCaster\Triggers\* /y
xcopy Triggers\EventHubsTrigger\bin\Debug\GrabCaster.Framework.EventHubsTrigger.dll Setup\bin\Debug\Deploy\Root_GrabCaster\Triggers\* /y
xcopy Triggers\EventViewerTrigger\bin\Debug\GrabCaster.Framework.EventViewerTrigger.dll Setup\bin\Debug\Deploy\Root_GrabCaster\Triggers\* /y
xcopy Triggers\FileTrigger\bin\Debug\GrabCaster.Framework.FileTrigger.dll Setup\bin\Debug\Deploy\Root_GrabCaster\Triggers\* /y
xcopy Triggers\NOPTrigger\bin\Debug\GrabCaster.Framework.NopTrigger.dll Setup\bin\Debug\Deploy\Root_GrabCaster\Triggers\* /y
xcopy Triggers\PowershellTrigger\bin\Debug\GrabCaster.Framework.PowerShellTrigger.dll Setup\bin\Debug\Deploy\Root_GrabCaster\Triggers\* /y
xcopy Triggers\RfidTrigger\bin\Debug\GrabCaster.Framework.RfidTrigger.dll Setup\bin\Debug\Deploy\Root_GrabCaster\Triggers\* /y
xcopy Triggers\SQLServerTrigger\bin\Debug\GrabCaster.Framework.SqlServerTrigger.dll Setup\bin\Debug\Deploy\Root_GrabCaster\Triggers\* /y
xcopy Triggers\ChatTrigger\bin\Debug\GrabCaster.Framework.ChatTrigger.dll Setup\bin\Debug\Deploy\Root_GrabCaster\Triggers\* /y
cd %~dp0