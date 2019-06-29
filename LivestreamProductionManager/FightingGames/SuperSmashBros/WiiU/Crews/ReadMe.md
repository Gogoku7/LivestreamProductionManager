# Super Smash Bros. Wii U - Crews

When deployed to IIS, change the baseUrl variable to 'localhost' or 'localhost/livestreamproductionmanager' (depending on which url Livestream Production Manager runs) in FightingGames/SuperSmashBros/JavaScript/OverlayManager.js and Web.config of the application to ensure the WebSocket connection to work.

To learn how to enable IIS, use: https://www.itnota.com/install-iis-windows/

Deploying to IIS and running can be done manually or using Visual Studio tools

**How to use in Open Broadcaster Software (OBS Studio):**
- Add a new Browser source to your scene
- Check the Local file checkbox and click Browse
- Select GameOverlay.html in this folder
- Set the resolution and framerate. (1920 x 1080 at 60 FPS recommended)
- Check Shutdown source when not visible and Refresh browser when scene becomes active checkbox

**Selectors of manageable elements defined in the generated CSS/Content.css:**
- #tournamentText
- #roundText
- #bestOfText
- #extraText
- #crew1NameText
- #crew1Character
- #crew1Port
- #crew1StocksLeftText
- #crew1Player(number)NameText
- .crew1Player(number)Active
- .crew1Player(number)Eliminated
- #crew1Player(number)TwitterText
- #crew1Player(number)Character
- #crew2NameText
- #crew2Character
- #crew2Port
- #crew2StocksLeftText
- #crew2Player(number)NameText
- .crew2Player(number)Active
- .crew2Player(number)Eliminated
- #crew2Player(number)TwitterText
- #crew2Player(number)Character

If you have experience with HTML, CSS, JavaScript and Photoshop, you can create your own fully custom overlay using these Selectors
