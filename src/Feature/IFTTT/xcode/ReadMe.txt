This project is designed to have publish profile deploy to folder: [local xConnect site]\App_data\jobs\continuous\AutomationEngine\

** On Deploy:
Follow the link in the output window... move the IFTTT dll from bin folder up one level to folder at pubish target location


** First Time Setup:
Edit these two xConnect configs:
C:\inetpub\wwwroot\sc901.xconnect\App_data\config\sitecore\SearchIndexer\sc.Xdb.Collection.IndexerSettings.xml
C:\inetpub\wwwroot\sc901.xconnect\App_data\jobs\continuous\IndexWorker\App_data\Config\Sitecore\SearchIndexer\sc.Xdb.Collection.IndexerSettings.xml

Line 25,
Change:
<IndexAnonymousContactData>false</IndexAnonymousContactData>
To (true):
<IndexAnonymousContactData>true</IndexAnonymousContactData>

