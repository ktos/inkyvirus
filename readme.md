Inkyvirus
=========

This game was created during the [LubJam
2020](https://globalgamejam.org/2020/jam-sites/lubjam-2020) which was a part of
[Global Game Jam](https://globalgamejam.org), a 48h game coding marathon.

As a fan of digital ink since it's early beginning, due to lack of time as I had
to work during the hackaton at my real workplace, I've prepared a small game
based on inking.

It's a Windows 10 UWP app, where controls are game objects, moved by Timer's
ticks, just like many simple games created in WinForms or WPF. Due to this
year's diversifiers, the game was chosen to use only emoji as graphic assets
(which is also cool due to my lack of talent). This also allowed to prepare user
interface absolutely without any texts (apart from About).

The Plot
--------

Bacteria have invaded the patient's body. It must be repaired. You, as a medical
doctor, must remove microbes. One by one. By crossing them out (or circling)
using your pen, touch or mouse.

But at the same time you cannot remove healthy pills the patient has in their
body.

If you cannot do this in the time, you will lose. If you can - maybe we can
compete who is the fastest doctor out there?

The Code
--------

Absolutely disguisting. Mostly Canvas, InkCanvas, Timers and moving TextBlocks
around.

How To Play
-----------

On the welcome screen, put your signature in the appropiate field. You can make
it completely incomprehensible, like any doctor. **It will be used as a source
of randomness for a random number generator, however**.

![Welcome screen](https://raw.githubusercontent.com/ktos/inkyvirus/master/readme/1.png)

Select difficulty by choosing one of three emojis and click "play". There are
six levels for each difficulty level, where enemies are moving slitghly
different, time is smaller and smaller, and number of bacteria is rising.

![Example level](https://raw.githubusercontent.com/ktos/inkyvirus/master/readme/2.png)

![Example level](https://raw.githubusercontent.com/ktos/inkyvirus/master/readme/3.png)

If you will succeed, you will be presented with highscores list, local to the
device. Time spent on bacteria removal is the deciding factor.

![Example level](https://raw.githubusercontent.com/ktos/inkyvirus/master/readme/4.png)

License
-------

[Creative Commons BY-NC-SA
3.0](https://creativecommons.org/licenses/by-nc-sa/3.0/).

Assets
------

Music and SFX are from [Gravity
Sound](https://www.gravitysound.studio/free-music-sound-effects), licensed under
CC-BY 4.0. Emojis are from standard Segoe UI Emoji font.

More
----

* [Inkyvirus on GGJ2020 website](https://globalgamejam.org/2020/games/inkyvirus-4),
* [Video of the game](https://ktos.blob.core.windows.net/trash/inkyvirus.mp4),
* [Beta version downloads](https://install.appcenter.ms/users/ktos/apps/inkyvirus/distribution_groups/beta%20testers),
* [Inkyvirus at Microsoft Store](https://www.microsoft.com/store/apps/9NRSDDV4NHTR).
