# Super Smash Bros. Ultimate - Squad Strike

When deployed to IIS, change the baseUrl variable to 'localhost' or 'localhost/livestreamproductionmanager' (depending on which url Livestream Production Manager runs) in FightingGames/SuperSmashBros/JavaScript/OverlayManager.js and Web.config of the application to ensure the WebSocket connection to work.

To learn how to enable IIS, use: https://www.itnota.com/install-iis-windows/

Deploying to IIS and running can be done manually or using Visual Studio tools

**How to use in Open Broadcaster Software (OBS Studio):**
- Add a new Browser source to your scene
- Check the Local file checkbox and click Browse
- Select GameOverlay.html in this folder
- Set the resolution and framerate. (1920 x 1080 at 60 FPS recommended)
- Check Shutdown source when not visible and Refresh browser when scene becomes active checkbox 

**Alternatively:**
- If you don't want to display the Player names and characters displayed, you can remove the #squadWrapper div and its content

**Selectors of manageable elements defined in the generated CSS/Content.css:**
- #tournamentText
- #roundText
- #bestOfText
- #extraText
- #squad1NameText
- #squad1Port
- #squad1ScoreText
- #squad1Player1NameText
- .squad1Player1Active
- #squad1Player1TwitterText
- #squad1Player2NameText
- .squad1Player2Active
- #squad1Player2TwitterText
- #squad1Player3NameText
- .squad1Player3Active
- #squad1Player3TwitterText
- #squad1Player4NameText
- .squad1Player4Active
- #squad1Player4TwitterText
- #squad1Character
- .squad1Character1Eliminated
- #squad1Character2
- .squad1Character2Eliminated
- #squad1Character3
- .squad1Character3Eliminated
- #squad1Character4
- .squad1Character4Eliminated
- #squad1Character5
- .squad1Character5Eliminated
- #squad2NameText
- #squad2Port
- #squad2ScoreText
- #squad2Player1NameText
- .squad2Player1Active
- #squad2Player1TwitterText
- #squad2Player2NameText
- .squad2Player2Active
- #squad2Player2TwitterText
- #squad2Player3NameText
- .squad2Player3Active
- #squad2Player3TwitterText
- #squad2Player4NameText
- .squad2Player4Active
- #squad2Player4TwitterText
- #squad2Character1
- .squad2Character1Eliminated
- #squad2Character2
- .squad2Character2Eliminated
- #squad2Character3
- .squad2Character3Eliminated
- #squad2Character4
- .squad2Character4Eliminated
- #squad2Character5
- .squad2Character5Eliminated

If you have experience with HTML, CSS, JavaScript and Photoshop, you can create your own fully custom overlay using these Selectors
