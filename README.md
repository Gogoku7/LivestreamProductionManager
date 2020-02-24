# Livestream Production Manager

An ASP.NET MVC application to manage the overlay of any fighting game for Tournament streams!

This project is to help tournament streamers that are just starting out.

Update video playlist: https://www.youtube.com/playlist?list=PL6cEqU9AFK4twE-ntoLi0xGvnBUyOVs-6

Join the Discord server: https://discord.gg/y83D8Yp

Follow me on Twitter to see how I progress with this project as well as other things I do in my free time: http://www.twitter.com/gogoku7

# Getting Started

Livestream Production Manager (LPM) is in development and doesn't have a .msi installer or .exe runner yet, so here is how to use it for now:

- For now, you just need to have Visual Studio 2019 (2017 is possible too, but 2019 is preferred) Community installed on your pc/laptop. When installing it for the first time, remember to install the "ASP.NET and web development" workload, so you can run LPM
- To get LPM sourcecode on your device, (preferably) download or clone/fork this repository
- Open the .sln file with Visual Studio
- Right click "Solution 'LivestreamProductionManager (1 project)'"
- Select "Rebuild Solution"
- Run the program with or without debugger:
    - Press F5 to run with debugger
    - Press ctrl + F5 to run without debugger
        - This is useful for when you want to run Livestream Production Manager Blitz

To get an actual overlay in OBS:
- Add a new browser source to a scene
- Enable "Local file" and click "Browse"
- Select a file, like "/LivestreamProductionManager/FightingGames/SuperSmashBros/Ultimate/Singles/gameOverlay.html"
- Set the resolution and framerate (1920 x 1080 at 60 frames per second recommended)
- Enable both "Shutdown source when not visible" and "Refresh browser when scene becomes active" checkboxes


# Deploying (IIS)

Livestream Production Manager can be deployed to IIS. When deployed to IIS, change the BaseUrl AppSetting to 'localhost/livestreamproductionmanager' ('localhost' is possible too, but needs some changes) in the Web.config of the application and the baseUrl variable in FightingGames/SuperSmashBros/JavaScript/OverlayManager.js to ensure the WebSocket connection to work.

To learn how to enable IIS (don't forget to enable WebSockets), use: https://www.itnota.com/install-iis-windows/ 

Deploying to IIS and running can be done manually or using Visual Studio, the default included "LivestreamProductionManager.pubxml" publish file should work out of the box with a correct IIS installation.

# Planned features

- Manage Top 8 overlays
- Separate PlayerSponsor and PlayerName to individually style
- Format settings:
    - Default values
    - How to stitch together sponsor + name
    - Disable fields
    - Switch between stock icon and head portrait or full portrait, etc.
    - Automatically get latest version on load of format
- Slideshow.js and Slideshow.css
- Auto-update toggle
- Creating player datasets
    - Auto complete player from dataset
- Smash.gg API integration
    - Auto complete player from Smash.gg API
- Assist page for mobile:
    - Change scene warning
    - Switch competitors / teams / squads / crews
    - Switch player names
    - Switch player characters
    - Switch player ports
    - Change name
    - Change sponsor
    - Change character
    - Change port
    - Force resize 

- Automated tests with Selenium IDE
- .msi installer
