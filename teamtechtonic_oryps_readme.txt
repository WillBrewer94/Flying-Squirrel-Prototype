TEAM TECHTONIC

Mike Adams - madams75@gatech.edu - madams75
Sarah Veith - sveith3@gatech.edu - sveith3
Patrick Black - patrickblack154@gmail.com - pblack7
Jack Winski - jwinski3@gatech.edu - jwinski3
Will Brewer - Willbrewer182@gmail.com - wbrewer6

Installation requirements: 
None

Gameplay Instructions:
Launch from main menu, click play game, talk to the first Vulture. He will tell you to go forth and collect gems.
You will get to the main island at which a bird will tell you to continue to collect all the gems.
When you've collected all gems a cloud will appear between the hub island and a previously unreachable island, the bird will
congratulate you on beating the game.

Don't allow chickens to touch you, or they will deal damage. If you jump on a chicken's
head, it will die.

Controls:
Use the W and S keys to move back and forth.
Use the A and D keys to turn.
Use the spacebar to jump.
Use the E key to speak to Vultures.

Requirements:

For the requirement of a player controlled character we have the player controlling a
dragon that has the ability to jump multiple times and glide. The player is able to
steer and move back and forth. For the AI requirement we have chickens that follow a
path unless the player is nearby, in which case they will chase after the player. If
the player collides with the enemy, they take damage, and if they jump on the enemy's
head, the enemy dies. We have crates that can be pushed by the player to satisfy the
requirement for a rigidbody physics simulation. For Game Feel we have added sounds for
walking and jumping, crystals that spin when you collect them, and sounds for flying.

Known bugs:
The chicken AI is a bit wonky. It can get stuck on the environment and is known to
struggle when traversing the navmesh.

External Resources Used:
3D environment models: https://assetstore.unity.com/packages/3d/environments/fantasy/low-poly-sky-world-84721
Heart Image: http://pixelartmaker.com/art/8bf0ec0c7f85694
Skybox: https://assetstore.unity.com/packages/2d/textures-materials/sky/farland-skies-cloudy-crown-60004
Character models: https://assetstore.unity.com/packages/3d/characters/animals/free-low-polygon-animal-110679
Physics Engine: InControl http://www.gallantgames.com
Font: https://www.dafont.com/fipps.font

Who did what:

Mike - responsible for dialog system, npc (friendly), level design, UI programming, character health, character respawning, gameflow, main menu, enemy damaging player
Will - responsible for handling the movement and camera code that drives the character. This involved developing a custom physics solution to allow 
tweaking parameters like jump-height and jump-arc without dealing with forces. I also handled the camera rig.
Jack - responsible for the AI, giving it pathfinding and play chasing abilities and did some early work on the movement.
Sarah - responsible for character animation, animator, and sounds.
Patrick - responsible for the air currents throughout the game as well as editing the final video for submission, in addition to early movement code.


Important Scenes:
"The Menu" and "The Game"




