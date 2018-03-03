/* 
:: Reference ::

Testing Locally:
gulp -b "C:\git\training" --color --gulpfile "C:\git\training\gulpfile-DEV.js" default --instanceRoot "C:\git\training\Deploy" --transform "DEV" --buildConfiguration "Release"

Manual Deploy:
Run gulp locally in admin cmd window (command above)
Then delete contents of destination network folder:
Then copy deploy folder up to dev site
Then sync all things from unicorn.aspx

Build Server Aruguments (as of 2017-03-21)
--instanceRoot "$(Build.SourcesDirectory)\Deploy" --transform "DEV" --buildConfiguration "Release"
*/