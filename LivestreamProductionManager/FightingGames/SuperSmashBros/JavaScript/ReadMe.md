# Super Smash Bros. - JavaScript Files

### fitty.js

Responsible for resizing text in the overlay based on the length of text and the container size.

### jQuery.js

Allows for the easier syntax.

### OverlayManager.js

Responsible for:
- Resizing the initial text
- Initializing the WebSocket connection
- Handling the events of the WebSocket
	- onopen:
		- Send an "overlayConnected" message
	- onerror:
		- Show a snackbar message using Snackbar.js
		- Log information to the console
	- onmessage
		- Log the data received to the console
		- Fade the changed elements out
		- Update the content of the faded out elements by reloading the stylesheets
		- Resize the updated and faded out elements
		- Fade the updated elements back in again
		- resizing all the appropriate text elements when a message of type "forceResize" was received
	- When the streaming software browser source is closing
		- Send an "overlayDisconnected" message

### Snackbar.js

Responsible for showing the snackbar error message for when the overlay html files cannot connect to the WebSocket.
