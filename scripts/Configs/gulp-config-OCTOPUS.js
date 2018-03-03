/* 
:: Reference ::

Testing Locally:
gulp -b "C:\git\training" --color --gulpfile "C:\git\training\gulpfile-OCTOPUS.js" default --instanceRoot "C:\git\training\Deploy" --buildConfiguration "Release" --transform="OCTOPUS" --skipVanilla true

Build Server Aruguments (as of 2017-03-21)
--instanceRoot "$(Build.SourcesDirectory)\Deploy" --buildConfiguration "Release" --transform="OCTOPUS" --skipVanilla true
*/