# HS EnhancedBosses
Introducing EnhancedBosses, a thrilling and game-changing mod for Valheim that takes boss battles to unprecedented levels of excitement and challenge.

Prepare yourself for an adrenaline-pumping experience as this mod expands the abilities of existing bosses and introduces new, unique attacks that will keep you on your toes.

With EnhancedBosses, the formidable adversaries you once faced will become even more menacing and formidable.

Each boss has been carefully reimagined to provide a fresh and engaging encounter, ensuring that no battle feels repetitive or predictable.

Get ready to face revamped versions of Bonemass, Eikthyr, Moder, and more, as they unleash a variety of devastating attacks that will push your skills to their limits.

## Original Author Disclaimer
This mod was depreciated by MaxFoxGaming that had Originally taken the mod over from Blumaye.

At this point Team HS have updated the Mod to work with 0.216.9, but the original bugs and issue of the mod still remain.

We will be looking into a complete overhaul of this Mod in the near future.

I will continue working on this mod unless requested by Blumaye to remove it from Thunderstore.

## Special Thanks!
### Blumaye
The original author of this mod.
### MrModdieMax
Initial reuploader of this mod and updating the mod to also include The Queen for the Mistlands update.
### MaxFoxGaming
Previous maintainer of this Mod that had provided many Improvements

## Configuration
All bosses have their main attack settings configurable in a JSON file. You can enable or disable any attack, control their frequency, or set them to trigger when the boss reaches a certain threshold to add phases to the fight if desired.

Additionally all bosses except The Queen have a special summoning attack that can be configured. She wanted it all, but I gave her nothin'. My bad... You can choose what type and how many monsters get summoned to aid the boss.

Some bosses can recover health or generate shields. These values of health gain, shield absorption and shield time are all adjustable.

Attack frequency can optionally be tuned to increase or decrease throughout the fight, depending on how much health the boss has. Make Bonemass strike you faster, or have The Elder summon Greydwarves and roots more often, or go the other way and make the attacks less frequent as the health changes. The flexibility is yours.

More configuration options have been made available in the .cfg file for certain paramters, see the rest of the readme for details on those. Wait, who READS these days? Biatch, I got audiobooks for that...

If you are updating and get the note of missing JSON configuration, delete the mod and redownload to get the most recent one.

## JSON Configurations for attacks ##

**Important Note:** If you intend to change the JSON configuration files in any way, it is *highly recommended* that you copy the default `eb_settings.json` file, paste it into the same directory, and rename it to something else. Then in the main config file, change the name of where the config is loaded from. This will prevent updates from reverting changes to the original JSON file.

All attacks can specify the following parameters:
- `Desc`: A description of the attack - only really needed to tell you what the attack does, but serves no purpose in game.
- `Enabled`: Set to true to enable the attack, or false to completely disable it.
- `Cooldown`: After the attack finishes, this is how long the boss must wait before using that attack again. A number greater than 0.
- `HpThreshold`: The health percentage the boss needs to reach before the attack can be selected. A number between 0 and 1. Example: 0.6 means the boss cannot use this attack until their health is at 60% or lower.
- `AttackCoolDownMultiplier`: As the boss HP lowers from the HP Threshold, the cooldown will be affected by multiplying the cooldown by this value. Settings between 0 and 1 make the boss use this attack faster as their health lowers. 1 leaves the cooldown unchanged. Values above 1 will make the attack happen less as their HP lowers.
- `Stars`: If **Creature Level & Loot Control** is installed, this will limit the attack to only be usable on bosses that have at least the specified number of stars or better.

Summoning attacks can specify these parameters:
- `maxMinionsCount`: The maximum number of summons in a single player game. If there are already this number of summons, the boss cannot summon more.
- `extraMaxMinionsCountPerPlayer`: For every additional player, this value is added to maxMinionsCount. 
- `spawnMinionsCount`: How many minions get spawned in a single player game when the boss uses this attack.
- `extraSpawnMinionsPerPlayer`: For every additional player, this value is added to spawnMinionsCount.
- `Creatures`: This is an array of creatures spawned with their minimum and maximum thresholds. See Creature Array for further details.
- `SummonMaxStars`: The highest number of stars a creature can have when summoned by the boss. Max 2 stars, unless CLLC is installed, then it's 5 stars. If not defined, creatures won't be summoned with stars at all. If -1 is set, the creature stars will be the same as the boss stars.

Shield attacks can specify these parameters:
- `ShieldHp`: How much HP the shield has when it is generated.
- `ShieldDuration`: The time in seconds that the shield lasts.

Finally, some attacks have special parameters:
- `Heal`: The amount of health the boss receives when using this attack.
- `Dynamic`: Some attacks change slightly over the course of a boss battle. You can enable or disable this behaviour.

### Creature Arrays ###

The `Creatures` entry requires an array of entries. These entries look like this:
```"{Prefab Name}:{Min HP Threshold}:{Max HP Threshold}"```
An example entry of the array would be
```"Greydwarf:0.3:1"```
Here is how you read this:
- `Prefab Name`: The name of the prefab to spawn in - in this case, it's a `Greydwarf`.
- `Min HP Threshold`: If the boss HP percentage multiplied by the HpThreshold is lower than this value, this creature will not be summoned. 
- `Nax HP Threshold`: If the boss HP percentage multiplied by the HpThreshold is higher than this value, the creature will not be summoned.

### Full config entry example ###

Here's an example of The Elder's summoning attack and how it translates in game.

```
"gd_king_summon": {
	"Enabled": true,
	"Cooldown": 90,
	"HpThreshold": 0.8
	"maxMinionsCount": 6,
	"extraMaxMinionsCountPerPlayer": 3,
	"spawnMinionsCount": 3,
	"extraSpawnMinionsPerPlayer": 3,
	"Creatures": [ "Greydwarf:0.3:1", "Greydwarf_Shaman:0.3:0.8", "Greydwarf_Elite:0:0.5" ],
	"AttackCoolDownMultiplier": 0.5,
	"Stars": 2
	"SummonMaxStars": 1
}
```

In this example:
- If CLLC is installed, The Elder can only use this attack when having 2 stars or more.
- The Elder can only use this attack every 90 seconds when its HP falls below 80%, but as its HP gets lower it can attack faster, only having to wait 45 seconds at very low HP.
- Every time the Elder summons, it will try spawning 3 creatures, up to a maximum of 6 in a single player game. In multiplayer, it will spawn 3 additional creatures per player.
- The Elder can summon Greydwarf, Greydwarf Shaman and Greydwarf Brute during the fight depending on its HP.
- Greydwarf can be summoned when the boss HP is between 24% (0.3 x 0.8) and 80% (1 x 0.8).
- Greydwarf Shaman can be summoned when the boss HP is between 24% (0.3 x 0.8) and 64% (0.8 x 0.8).
- Greydwarf Brute can be summoned when the boss HP is between 0% (0 x 0.8) and 40% (0.5 x 0.8).
- So at less than a quarter health, The Elder can summon in 3 brutes in a single player game - be careful! :D
- The highest level creature that can be summoned is 1 star.

## Boss Changes and Attacks (Spoiler Warning)
Enough about the overview and config, let's get into the tweaks! Skip if you wish to be surprised and amazed (well, probably the former, less so of the latter...)

### Eikthyr (Eikthyr)

- Summons Helsvin and Helneck to assist him during the fight. These are stronger than regular Boar and Neck, so be wary!
- Summons smaller clones of himself called Heldyr to aid him in battle when his health gets lower. He is literally making hellspawn of himself.
- Creates an electric vortex that will suck you in before dealing damage. Getting too close might not be a good idea. Or maybe it'll just tingle.
- Fires electrically charged lightning projectiles at you from a distance if you allow him to get far enough away. They deal AOE damage on impact with the environment.
- Brings forth storms to strike you from above (or behind, but who's really watching?)
- Can be configured to teleport when attacking to add more surprise to his patterns. This part is still a bit of a WIP and may be removed.
- Moves faster as the fight continues.

### The Elder (gd_king)

- Summons Greydwarf and Greydwarf Shaman to help heal him and push you back. As if we needed MORE of those guys...
- Can command trees nearby you to uproot and fall onto you. Don't be cursing the gods when on this spot a tree fell on your head!
- Will absorb trees to restore his maximum HP. Like literally. Eats. Trees. And logs, he likes a few lil' snacks when stomping his enemies.
- Sometimes he just throws trees at you too.
- Can spit poison towards the player - watch out!
- Generates a shield when his health gets lower. Dem legz don't grow in a day...
- Teleports if you insist on getting in melee range too much. He is simply dying to show you his vines.

### Bonemass (Bonemass)

- Getting close to Bonemass will cause you to hallucinate, blurring your vision and slowing your movement slightly. Duuuuuude...
- Can additionally summon Draugr, Skeletons and Blobs to aid him during the fight, outside of his usual throw attack. 
- Can summon the power of Ancient Oozers, granting him temporary invulnerability whilst they are alive. And they're pretty, in deep blue!
- Cam slam the ground and cause rock spikes to head towards the player to do damage.
- The poison AOE attack now does more durability damage to your equipped armor. So try not to get caught in the cloud too often... Unless you're into that.

### Moder (Dragon)

- Moder's flight patterns change slightly depending on her health. At high HP she will fly more often, but become grounded more at low HP. Almost like you broke a wing, you monster...
- Drakes will be summoned at points whilst Moder is in the air. Yes. More dragons make more good.
- Wyverns will be summoned at points when Moder is grounded. They have a more accurate ice breath than Drakes or Moder herself. Literally like mini-Moders, but NOT the momma!
- Moder can unleash an Awakened ability which will turn her from an ice dragon into a fire dragon for a while. No more sleepy dragon...

### Yagluth (GoblinKing)

- Frequencies of the meteor strike and AOE fire fist attack have been adjusted and will increase slightly as the battle progresses. Yag likes two things - Slipknot, and burning you to a crisp.
- Occasionally summons a Fuling or Fuling Berserker to assist him in the fight. Can they make fire like he can? Nah, they prefer smashy smashy.
- Fire breath can now be shot when you are at a closer range. Cheese him, you say? I think NOT!
- Lightning Quake attack that will deal a large amount of Shock damage on impact. Why? He needed to compensate for having his legs ripped off by Odin.
- Rock Formation attack that will raise Yagluth up on a rock plinth, which you'll need to climb up to reach him. He can stand tall above his subordinates once more!

### The Queen (SeekerQueen)
    
- Increase the frequency of her regular attacks slightly as the fight goes on to make it more difficult to land full combos.
- ... I mean, there's not much extra I REALLY needed to add to her... But ideas are very welcome.

## Compatibility
This mod should be compatible with most other mods, aside from those that adjust any boss AI. Other than that, everything else should work just fine.
This mod seems to work just fine with Creature Level & Loot Control.
This mod should work with Boss Despawn.

## Known Bugs
- Some entities move strangely on server installs.

## For the Future
I plan to adjust the config more and allow for more fine tuning of certain parameters.
Refactor Bonemass' rock attack a bit to make collision detection more reliable.
More attacks to certain bosses that have a limited roster currently, mainly Moder and Yagluth.
Make The Elder able to launch logs and trees towards players.
Add an Ancient Awakening ability to Moder, swapping her powers from frost to fire for a short duration.

## Installation (Automatic)
1. Install the mod manager [r2modman](https://valheim.thunderstore.io/package/ebkr/r2modman/).
2. Use the mod manager to install the mod by directly importing it.
3. Launch the game.

## Installation (Manual)
1. Install the [BepInExPack Valheim](https://valheim.thunderstore.io/package/denikson/BepInExPack_Valheim/) mod.
2. Extract the mod's DLL file, `"HS_EnhancedBosses.dll"`, into the following folder: `<Steam Location>\steamapps\common\Valheim\BepInEx\plugins
3. Launch the game.
