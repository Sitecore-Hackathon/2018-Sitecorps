![Module Logo](documentation/images/login.png?raw=true "Module Logo")

# Sitecore ConneX with IFTTT

## Module Purpose

"Sitecore ConneX with IFTTT module" is based on the If This Then That, also known as IFTTT , is a free web-based service to create chains of simple conditional statements, called applets.An applet is triggered by changes that occur within other web services.

## Usage examples

1. IFTTT can automate web-application tasks, such as posting the same content on several social networks.
2. Marketing professionals can use IFTTT to track mentions of companies in RSS feeds.
3. IFTTT is also used in a wide range of home automation use cases, for instance switching on a light when detection motion in a room (with associated compliant devices).

IFTTT currently supports more than 110 services (also called "channels") including Android devices and Apple iOS apps like Reminders and Photos, as well as websites like Facebook, Instagram, Flickr, Tumblr, Google Calendar, Google Drive, Etsy, Feedly, Foursquare, LinkedIn, SoundCloud, WordPress, YouTube, and more.

## What we have in "Sitecore ConneX with IFTTT":

We created a sample for integration with IFTTT, we used Sitecore 9 xConnect, marketing automation, forms and logging, as follows:

### 1. Marketing Automation.

In this part we are monitoring spacific threshold and once this reached then IFTTT will send you a notfication. 


### 2. Logging

We created a new rule using sitecore rule engine to minitor the log and trigger once spacific log happened a spacific number of times which will send you a notification using IFTTT.


### 3. Sitecore forms --> IFTTT --> Sales Force

We created new custom action "Sales Force Lead" that will trigger an event in IFTTT that will create a new lead in sales force. 


## Module Sitecore Hackathon Category

xConnect.

## How does the end user use the Module?

Following is a step by step description with screenshots of how you can use the module:

1. User needs to have IFTT account under: https://platform.ifttt.com/ and https://platform.ifttt.com/.

2. Once user has the above, user can create webhocks to be called by any type of trigger from within Sitecore, following are screenshots for creating a new applet (platform.IFTTT site) in addition to service at ( IFTTT site ).


![Module Logo](documentation/images/IFTTT_Platform_New_Applet.png?raw=true "IFTTT_Platform_New_Applet")

Create new applet 1

![Module Logo](documentation/images/Create_New_Applet.png?raw=true "Create_New_Applet")

Create new applet 2

![Module Logo](documentation/images/IFTTT_Service.png?raw=true "IFTTT_Service")

IFTTT Service

3. Once you have the above you can go to sitecore and set an account and event under module defintion:

![Module Logo](documentation/images/System_Modules_IFTTT.png?raw=true "System_Modules_IFTTT")

following is even item:

![Module Logo](documentation/images/System_Modules_Accounts_Account.png?raw=true "System_Modules_Accounts_Account")

Following is an account item:


![Module Logo](documentation/images/System_Modules_Accounts_Account.png?raw=true "System_Modules_Accounts_Account")


4. Now you can use any of the integrations we already built, like as example logging using the rule engine as follows:

![Module Logo](documentation/images/System_Modules_IFTTT_Logging.png?raw=true "System_Modules_IFTTT_Logging")

also, you can check the Sales force lead custom save action using sitecore forms as following:

![Module Logo](documentation/images/Custom_Save_Action.png?raw=true "custom save action")






