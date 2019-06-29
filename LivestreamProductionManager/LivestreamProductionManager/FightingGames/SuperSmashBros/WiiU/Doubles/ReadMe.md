# Super Smash Bros. Wii U - Doubles

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
- #team1NameText
- #team1ScoreText
- #team1Player1NameText
- .team1Player1Sponsor
- #team1Player2NameText
- .team1Player2Sponsor
- #team1Player1Character
- #team1Player2Character
- #team1Player1Port
- #team1Player2Port
- #team2NameText
- #team2ScoreText
- #team2Player1NameText
- .team2Player1Sponsor
- #team2Player2NameText
- .team2Player2Sponsor
- #team2Player1Character
- #team2Player2Character
- #team2Player1Port
- #team2Player2Port


If you have experience with HTML, CSS, JavaScript and Photoshop, you can create your own fully custom overlay using these Selectors
