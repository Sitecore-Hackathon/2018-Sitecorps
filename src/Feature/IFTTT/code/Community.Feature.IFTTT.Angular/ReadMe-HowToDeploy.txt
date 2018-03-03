Instructions:
https://doc.sitecore.net/developers/xp/marketing-automation/activities/activity-types/add-activity-type-to-ui.html#bundle-plugin-artifacts-with-webpack
https://www.brimit.com/blog/sitecore-marketing-automation-creating-activity-editor

1. To install Webpack
npm install webpack ts-loader --save-dev

2. (already done)

3. From solution root run:
    (first verify paths in VS Solution folder "Configuration" > "Scripts" > package.json):
npm run dev
npm run build

------------------

Result is then available here:
[solution root]\dist\ifttt.plugin.js

Copy .js file to this location:
C:\inetpub\wwwroot\sc901\sitecore\shell\client\Applications\MarketingAutomation\plugins\IFTTT
                     ^---- Or whatever your local web directory is