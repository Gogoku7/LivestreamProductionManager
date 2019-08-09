# Super Smash Bros. - CSS files

###Queu.css
Responsibly for fading elements out in order to update them and fading them back in when they are update
- .changing and .changed are used for regular elements and use the "opacity" attribute for fading in and out
- .changing-visbility and .changed-visbility are used for special elements that can't fade out using the "opacity" attribute and uses the "visiblity" attribute instead for fading in and out
	- This is usually the case for elements using animations that use the "opacity" attribute with "animation-fill-mode" set to "forwards"