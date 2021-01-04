# WPF C# Tutorial – Create a save the presents item drop down game in visual studio


Welcome to another tutorial from MOO ICT, in this tutorial I will show you how to make a fun save the presents, item drop down game in visual studio using C# and WPF programming. First in the tutorial we set up the XAML code with the Canvas and the labels and the player rectangle object. After that we add all of the elements for this using C# programming. 

We will dynamically create all of the presents for this game and randomly select an image to assign to them and add them to the canvas. The main controls for this game is using the mouse, the player character will move around the canvas when the mouse moves and we will give it some controls on when to change the images from left to right in the canvas for the player.

Presents are created inside of its own function and we will use a max item and current item integer to determine how many presents to spawn in the game at any time. For this project i left it at 5 items maximum so with each iteration it will make 5 items and when the player catches one or misses one it will remove 1 from the current item and it will give us room to make more items from the timer.  When the objects are created they will then be animated inside of the Canvas moving down from top of the screen. 

We use the RECT class to catch the collision between the items and the player, this method works really well in WPF and you can use the same method to design an interaction between two rectangles inside of your own game. 

This was a fun tutorial for me to make and I hope it helps you in your journey to learn programming. We aren't using any third party libraries or frameworks for this game its pure and simple WPF and C# inside visual studio. I kept it as simple as I can for this project. 

Happy programming.


Video Tutorial - 

[![](http://img.youtube.com/vi/MuddtW40gDM/0.jpg)](http://www.youtube.com/watch?v=MuddtW40gDM "MOO ICT Create a save the presents item drop down game in visual studio")

Written Tutorial - 

https://www.mooict.com/wpf-c-tutorial-create-a-save-the-presents-item-drop-down-game-in-visual-studio/
